using Microsoft.AspNetCore.Mvc;

namespace PuzzleServer.Controllers
{
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string n)
        {
            return Ok(new List<int> { 1,2,3});
        }
    }
}
