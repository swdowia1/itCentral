using Encrypt;
using ItCentral.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ItCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ItCentralDataContext _dbContext;
        string key = "abcd1234";

        public MessageController(ItCentralDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        [HttpGet("{key}", Name = "GetMessage")]
        public async Task<IActionResult> GetMessage(string key)
        {



            var s = _dbContext.Messages.FirstOrDefault(k => k.Key == key);
            string result = Cipher.Decrypt(s.MessageValue, s.Key);
            return Ok(new MessageResult() { Info = "I'm teapot", Message = result });
        }


        

       
    }
}
