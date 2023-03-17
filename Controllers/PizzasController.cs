using Microsoft.AspNetCore.Mvc;
using Pizzas.API.Models;
using Pizzas.API.Utils;

namespace Pizzas.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() {
            IActionResult respuesta;
            List<Pizza> ListaPizzas;

            ListaPizzas =  BD.GetAll();
            respuesta = Ok(ListaPizzas);
            return respuesta;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            IActionResult respuesta = null;
            Pizza pizza;

            pizza = BD.GetById(id);
            if (pizza == null) {
                respuesta = NotFound();
            } else {
                respuesta = Ok(pizza);
            }
            return respuesta;
        }
        [HttpPost]
        public IActionResult Create (Pizza pizza) {
            int intRowsAffected;
            intRowsAffected = BD.Insert(pizza);
            return CreatedAtAction(nameof(Create), new {id = pizza.Id}, pizza);
        }
        [HttpPut("{id}")]
        public IActionResult Update (int id, Pizza pizza){
            IActionResult respuesta = null;
            Pizza entity;
            int intRowsAffected;
            if (id != pizza.Id)
            {
                respuesta = BadRequest();
            }else
            {
                entity = BD.GetById(id);
                if (entity == null)
                {
                    respuesta = NotFound();
                }else
                {
                    intRowsAffected = BD.UpdateById(pizza);
                    if (intRowsAffected > 0)
                    {
                        respuesta = Ok(pizza);
                    }else
                    {
                        respuesta = NotFound();
                    }
                }
            }
            return respuesta;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id){
            IActionResult respuesta = null;
            Pizza entity;
            int intRowsAffected;
            entity = BD.GetById(id);
            if (entity == null)
            {
                respuesta = NotFound();
            }else
            {
                intRowsAffected = BD.DeleteById(id);
                if (intRowsAffected > 0)
                {
                    respuesta = Ok(entity);
                }else
                {
                    respuesta = NotFound();
                }
            }
            return respuesta;

        }
    }   
}




