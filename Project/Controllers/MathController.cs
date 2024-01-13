using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers

{
    public class MathController : Controller
    {

        [HttpGet]
        public IActionResult Add(int a, int b)
        {
            int result = a + b;
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Subtract(int a, int b)
        {
            int result = a - b;
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Multiply(int a, int b)
        {
            int result = a * b;
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Divide(int a, int b)
        {
            if (b == 0)
            {
                return BadRequest("Cannot divide by zero.");
            }

            int result = a / b;
            return Ok(result);
        }

            //public IActionResult Index()
            //{
            //    return View();
            //}
        }
}
