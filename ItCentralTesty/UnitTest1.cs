using Encrypt;
using ItCentral.Controllers;
using ItCentral.Model;
using ItCentral.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItCentralTesty
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public  async Task Test1()
        {
            var options = new DbContextOptionsBuilder<ItCentralDataContext>()
           .UseInMemoryDatabase(databaseName: "MovieListDatabase")
           .Options;

            ItCentralDataContext db = new ItCentralDataContext(options);
            string klucz = "abcd12345";
            string wiadomosc = "ala ma kota";
            string szyfr= Cipher.Encrypt(wiadomosc, klucz); ;


         db.Messages.Add(new Message { Key=klucz,MessageValue=szyfr});
            db.SaveChanges();

            IMessageService i = new MessageService(db);
            MessageController c = new MessageController(i);
     

            var resultController = await c.GetMessage(klucz) as ObjectResult;
            var res = resultController.Value as MessageResult;

            Assert.AreEqual(wiadomosc, res.Message);
        }

        [Test]
        public  void Test2()
        {
            var options = new DbContextOptionsBuilder<ItCentralDataContext>()
           .UseInMemoryDatabase(databaseName: "MovieListDatabase")
           .Options;

            ItCentralDataContext db = new ItCentralDataContext(options);
            string klucz = "abcd12345";
            string wiadomosc = "panie janie panie janie";
            string szyfr = Cipher.Encrypt(wiadomosc, klucz); ;


            db.Messages.Add(new Message { Key = klucz, MessageValue = szyfr });
            db.SaveChanges();

            IMessageService i = new MessageService(db);
            string result= i.GetMessage(klucz);
            Assert.AreEqual(wiadomosc, result);
        }
    }
}