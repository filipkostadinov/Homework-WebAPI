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
        public ActionResult<SessionModel> GetWinners(int sessionId)
        {
            var sessionModel = _sessionService.GetWinners(sessionId);
            if (sessionModel == null)
            {
                return NotFound("There is no winner in this session");
            }
            return sessionModel;
        }
        [HttpPost]
        public IActionResult OpenSession()
        {
            var adminId = GetAuthorizedUserId();
            var sessionModel = _sessionService.OpenSession(adminId);
            if (sessionModel == null || sessionModel.Winners.Count() == 0)
            {
                return NotFound("There is no winner in this session");
            }
            return Ok(sessionModel);
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