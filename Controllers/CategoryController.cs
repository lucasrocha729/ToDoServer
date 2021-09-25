using Microsoft.AspNetCore.Mvc;
using ToDoServer.Data;

namespace ToDoServer.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase {
       private readonly DataContext _context;
        public CategoryController(DataContext context){
            _context = context;
        }

     }
}
