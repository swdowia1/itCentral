using Encrypt;
using ItCentral.Model;
using ItCentral.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ItCentral.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _IMessageService;

        public MessageController(IMessageService iMessageService)
        {
            _IMessageService = iMessageService;
        }

        [HttpGet("{key}", Name = "GetMessage")]
        public async Task<IActionResult> GetMessage(string key)
        {



           

            string result = _IMessageService.GetMessage(key);
            return Ok(new MessageResult() { Info = "I'm teapot", Message = result });
        }


        

       
    }
}
