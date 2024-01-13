    using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>(new[]
        {
            new Product() {id = 1, name = "Console", price = 1000000},
            new Product() {id = 2, name = "Progammer", price = 2000000},
            new Product() {id = 3, name = "Apple", price = 500},
        });

        [HttpGet]
        public IEnumerable<Product>Get()=>products;

        [HttpGet("{id}")]       //параметр для маршутизация
        public IActionResult Get(int id)
        {
            var product = products.SingleOrDefault(p =>p.id == id);
            if(product == null)
            {
                return NotFound();
            }    
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            products.Remove(products.SingleOrDefault(p =>p.id == id));
            return Ok(new { Message = "Delete Successfuly!" });
        }

        private int NextProductId => products.Count() == 0 ? 1 : products.Max(x => x.id) + 1;
        [HttpGet("GetNextProductId")]    //проверка: /api/GetNextProductId/
        public int GetNextProductId()
        {
            return NextProductId;
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            product.id = NextProductId;
            products.Add(product);
            return CreatedAtAction(nameof(Get), new {id = product.id}, product);
        }
        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] Product product) => Post(product);


        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storedProduct = products.SingleOrDefault(p => p.id == product.id);
            if (storedProduct == null)
                return NotFound();
            storedProduct.name = product.name;  
            storedProduct.price = product.price;
            return Ok(storedProduct);
        }

        [HttpPut("UpdateProduct")]
        public IActionResult PutBody([FromBody] Product product) => Put(product);

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
