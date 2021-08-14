using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace LotoAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpGet("{sessionId}")]
        public ActionResult<IEnumerable<WinnerModel>> GetWinners(int sessionId)
        {
            var winners = _sessionService.GetWinners(sessionId).ToList();
            if (winners.Count() == 0)
            {
                return NotFound("There is no winner in this session");
            }
            return winners;
        }
        [HttpPost]
        public IActionResult OpenSession()
        {
            var adminId = GetAuthorizedUserId();
            var winners = _sessionService.OpenSession(adminId);
            if (winners == null || winners.Count() == 0)
            {
                return NotFound("There is no winner in this session");
            }
            return Ok(winners);
        }

        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?
                .Value, out var adminId))
            {
                throw new Exception("Name identifier claim does not exist!");
            }
            return adminId;
        }
    }
}