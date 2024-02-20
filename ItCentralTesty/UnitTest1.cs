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
        ItCentralDataContext db;
        string klucz = "abcd123";
        string wiadomosc = "ala ma kota";
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ItCentralDataContext>()
          .UseInMemoryDatabase(databaseName: "MovieListDatabase")
          .Options;
            if (db == null)
            {


                db = new ItCentralDataContext(options);


                string szyfr = Cipher.Encrypt(wiadomosc, klucz); ;


                db.Messages.Add(new Message { Key = klucz, MessageValue = szyfr });
                db.Messages.Add(new Message { Key = "gg", MessageValue = "ggg" });
                db.SaveChanges();
            }

        }

        [Test]
        public  async Task Test1()
        {
           
         
            IMessageService i = new MessageService(db);
            MessageController c = new MessageController(i);
     

            var resultController = await c.GetMessage(klucz) as ObjectResult;
            var res = resultController.Value as MessageResult;

            Assert.AreEqual(wiadomosc, res.Message);
        }



        [Test]
        public  void Test2()
        {
           

            IMessageService i = new MessageService(db);
            string result= i.GetMessage(klucz);
            Assert.AreEqual(wiadomosc, result);
        }
        [Test]
        public void BrakKLucza()
        {


            

            KeyNotExistException ex = Assert.Throws<KeyNotExistException>(() => {
                IMessageService i = new MessageService(db);
                string result = i.GetMessage("aaa");
            });
            Assert.AreEqual("Brak klucza", ex.Message);
        }
    }
}