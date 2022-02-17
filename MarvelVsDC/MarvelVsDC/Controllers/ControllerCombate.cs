using MarvelVsDC.Dominio;
using MarvelVsDC.DTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MarvelVsDC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerCombate : ControllerBase
    {
        public MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        [HttpPost("combater")]
        public async Task<dynamic> _ControllerCombate(RequisicaoCombate objeto)
        {
            var database = mongoClient.GetDatabase("UniversoHeroisAberto");

            var item1 = (await database.GetCollection<Heroi>("Heroi")
                .FindAsync(x => x.Id == objeto.IdHeroi)).FirstOrDefault();
            var item2 = (await database.GetCollection<Vilao>("Vilao")
                .FindAsync(x => x.Id == objeto.idVilao)).FirstOrDefault();

            if (item1 == null || item2 == null)
            {
                return "Personagens devem estar previamente cadastrados.";
            }

            int contadorDeRound = 0;

            if ((item1.IsMarvel && item2.IsMarvel) || (item1.IsDC && item2.IsDC))
            {
                do
                {
                    contadorDeRound  += 1;
                    int forcaTotal1 = 0;
                    var forcaTotal2 = 0;
                    
                    foreach (var dano in item1.Power)
                        forcaTotal1 += dano.Value;
                    
                    foreach (var dano in item2.Power)
                        forcaTotal2 += dano.Value;
                    
                    item1.Life = item1.Life < forcaTotal2 ? item1.Life = 0 : item1.Life -=  forcaTotal2;
                    item2.Life = item2.Life < forcaTotal1 ? item2.Life = 0 : item2.Life -=  forcaTotal1;
                    
                } while (item1.Life > 0 && item2.Life > 0);
                
                return new {
                    heroi = new
                    {
                        heroiId = item1.Id,
                        life = item1.Life,
                        taVivo = item1.Life > 0
                    },
                    vilao = new
                    {
                        iD = item2.Id,
                        life = item2.Life,
                        taVivo = item2.Life > 0
                    },
                    rounds = contadorDeRound 
                };

            }
            
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Personagens de universos diferentes não poderão batalhar entre si.");
        }
    }
}
