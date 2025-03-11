using Microsoft.AspNetCore.Mvc;
using TicTacToeOnlineApi.Models;
using TicTacToeOnlineApi.Services;

namespace TicTacToeOnlineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        // POST: api/session
        [HttpPost]
        public ActionResult<string> CreateSession()
        {
            var sessionId = _sessionService.CreateSession();
            return Ok(sessionId);
        }

        // POST: api/session/{sessionId}/join?playerName=Alice
        [HttpPost("{sessionId}/join")]
        public ActionResult JoinSession(string sessionId, [FromQuery] string playerName)
        {
            var success = _sessionService.JoinSession(sessionId, playerName);
            if (!success)
            {
                return BadRequest("Session is full or does not exist.");
            }
            return Ok("Joined session successfully.");
        }

        // POST: api/session/{sessionId}/move
        [HttpPost("{sessionId}/move")]
        public ActionResult MakeMove(string sessionId, [FromBody] MoveRequest move)
        {
            var result = _sessionService.MakeMove(sessionId, move);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        // GET: api/session/{sessionId}
        [HttpGet("{sessionId}")]
        public ActionResult<Session> GetSession(string sessionId)
        {
            var session = _sessionService.GetSession(sessionId);
            if (session == null)
            {
                return NotFound("Session not found.");
            }
            return Ok(session);
        }
    }
}
