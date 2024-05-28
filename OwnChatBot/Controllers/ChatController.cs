using Microsoft.AspNetCore.Mvc;

namespace OwnChatBot.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatbotService _chatbotService;

        public ChatController(ChatbotService chatbotService)
        {
            _chatbotService = chatbotService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Chat(string userInput)
        {
            string response = _chatbotService.Respond(userInput);
            return Json(new { response });
        }
    }
}
