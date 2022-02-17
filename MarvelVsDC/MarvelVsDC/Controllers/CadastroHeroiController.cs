using MarvelVsDC.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Libmongocrypt;

namespace MarvelVsDC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroHeroiController : ControllerBase
    {
        private readonly ILogger<CadastroHeroiController> _logger;
        private MongoClient mongoClient;

        public CadastroHeroiController(ILogger<CadastroHeroiController> logger, MongoClient mongoClient)
        {
            this.mongoClient = mongoClient;
            _logger = logger;
        }

        [HttpPost("cadastrar")]
        public IActionResult  Controller([FromBody] Heroi heroi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (IsEmptyPower(heroi.Power)) 
                        throw new ArgumentException("Deve conter no minimo um poder.");
                    if (IsEmptyWeakPoint(heroi.PontoFraco))
                        throw new ArgumentException("Deve conter no minimo um ponto fraco.");
                    if (heroi.IsMarvel && heroi.IsDC)
                        throw new ArgumentException("O personagem deve pertencer apenas em um universo. (Marvel ou DC)");
                    
                    heroi.Id = Guid.NewGuid().ToString();
                    mongoClient.GetDatabase("UniversoHeroisAberto").GetCollection<Heroi>("Heroi")
                        .InsertOne(heroi);
                    return Ok(heroi.Id);
                }
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, argumentException.Message);
            }
            
            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }

        [HttpPost("cadastrar-vilao")]
        public IActionResult Controller2([FromBody] Vilao vilao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (IsEmptyPower(vilao.Power))
                        throw new ArgumentException("Deve conter no minimo um poder.");
                    if (IsEmptyWeakPoint(vilao.PontoFraco))
                        throw new ArgumentException("Deve conter no minimo um ponto fraco.");

                    vilao.Id = Guid.NewGuid().ToString();
                    mongoClient.GetDatabase("UniversoHeroisAberto").GetCollection<Vilao>("Vilao")
                        .InsertOne(vilao);
                    return Ok(vilao.Id);
                }
            }
            catch (ArgumentException argumentException)
            {
                _logger.LogError(argumentException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, argumentException.Message);
            }
        

            return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
        }

        public bool IsEmptyPower(List<Poder> values)
        {
            return values.Count == 0;
        }

        public bool IsEmptyWeakPoint(List<WeakPoint> values)
        {
            return values.Count == 0;
        }
    }
}

