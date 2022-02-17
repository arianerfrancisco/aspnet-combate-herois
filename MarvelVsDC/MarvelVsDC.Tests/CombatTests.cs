using MarvelVsDC.Controllers;
using MarvelVsDC.Dominio;
using MarvelVsDC.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelVsDC.Tests
{
    [TestClass]
    public class CombatTests
    {
        private MongoClient mongoClient;

        [TestInitialize]
        public void Initialize()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
        }

        [TestMethod]
        public async Task TESTA_COMBATE_E_QUEM_TIVER_VIDA_DEVE_RETORNAR_TAVIVO_TRUE()
        {
            var combatController = new ControllerCombate();

            var database = mongoClient.GetDatabase("UniversoHeroisAberto");

            var heroiCollection = database.GetCollection<Heroi>("Heroi");

            var vilaoCollection = database.GetCollection<Vilao>("Vilao");

            await heroiCollection.InsertOneAsync(new Heroi
            {
                Id = "5272",
                IsMarvel = true,
                Nome = "Homem-Aranha",
                Power = new List<Poder> { new() { Nome = "Teia elétrica", Value = 5 }, new() { Nome = "Chute giratório", Value = 8 } },
                Life = 20
            });

            await vilaoCollection.InsertOneAsync(new Vilao
            {
                Id = "5273",
                IsMarvel = true,
                Nome = "Kraven",
                Power = new List<Poder> { new() { Nome = "Teia elétrica", Value = 5 } },
                Life = 13
            });

            dynamic combatResult = await combatController._ControllerCombate(new RequisicaoCombate { IdHeroi = "5272", idVilao = "5273", local = "Nova York" });

            var heroi = combatResult.GetType().GetProperty("heroi").GetValue(combatResult, null);
            var vilao = combatResult.GetType().GetProperty("vilao").GetValue(combatResult, null);


            var heroiTaVivo = heroi.GetType().GetProperty("taVivo").GetValue(heroi, null);
            var vilaoTaVivo = vilao.GetType().GetProperty("taVivo").GetValue(vilao, null);

            Assert.IsTrue(heroiTaVivo);
            Assert.IsFalse(vilaoTaVivo);
        }
    }
}