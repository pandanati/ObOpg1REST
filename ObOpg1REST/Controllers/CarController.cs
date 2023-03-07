using CarLibraryClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatoriskOpg1_4REST.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ObligatoriskOpg1_4REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        CarManager carManager = new CarManager();

        // GET: api/<CarController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            IEnumerable<Car> cars = carManager.GetAllCars();

            if (cars == null || !cars.Any())
            {
                return NotFound("No cars found");
            }

            return Ok(cars);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> GetById(int id)
        { 
            Car car = carManager.GetCarById(id);
            if (car == null) 
            { 
                return NotFound("The car with the following ID was not found."); 
            }
            return Ok(car);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car value)
        {
            Car car = carManager.Add(value);
            if (car == null)
            {
                return BadRequest("Cannot add car");
            }

            return Ok(car);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car newValue)
        {
            Car car = carManager.Update(id, newValue);
            if (car == null)
            {
                return BadRequest("Cannot Update Car");
            }
            return Ok(car);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car car = carManager.Delete(id);
            if (car == null)
            {
                return BadRequest("Data could not be deleted. Maybe the car wasn't found?");
            }
            return Ok(car);
        }


    }
}