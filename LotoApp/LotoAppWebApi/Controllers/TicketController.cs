using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace LotoAppWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TicketModel>> GetUserTickets()
        {
            var userId = GetAuthorizedUserId();

            var tickets = _ticketService.GetUserTickets(userId);
            if (tickets == null)
            {
                return NotFound("there is no tickets");
            }
            return Ok(tickets);
        }
        [HttpPost]
        public IActionResult Post([FromBody] TicketModel model)
        {
            model.UserId = GetAuthorizedUserId();
            _ticketService.AddTicket(model);
            return Ok();
        }

        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?
                .Value, out var userId))
            {
                throw new Exception("Name identifier claim does not exist!");
            }
            return userId;
        }
    }
}