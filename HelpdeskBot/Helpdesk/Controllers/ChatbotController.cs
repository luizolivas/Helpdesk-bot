using ChamadoDataAccessLibrary.Models;
using HelpdeskBot.Services.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpdeskBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
        private readonly IChatbotService _chatbotService;

        public ChatbotController(IChatbotService chatbotService)
        {
            _chatbotService = chatbotService;
        }

        [HttpPost]
        public IActionResult Post(Message message)
        {
            var response = _chatbotService.GetResponse(message);
            return Ok(response);
        }
    }
}
