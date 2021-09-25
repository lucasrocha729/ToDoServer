using Microsoft.AspNetCore.Mvc;
using ToDoServer.Data;

namespace ToDoServer.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }
    }
}
