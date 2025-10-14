using Microsoft.AspNetCore.Mvc;
using MyApiApp.Models;

namespace MyApiApp.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { Id = 1, Model = "Honda Civic", Year = 2019 },
            new Car { Id = 2, Model = "Ford Mustang", Year = 2022 }
        };

        [HttpGet]
        public ActionResult<List<Car>> GetAllCars()
        {
            return Ok(cars);
        }


        // GET api/car/1
        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound(new { message = "Car not found" });

            return Ok(car);
        }

        // POST api/car
        [HttpPost]
        public ActionResult<Car> AddCar(Car newCar)
        {
            newCar.Id = cars.Count + 1;
            cars.Add(newCar);
            return CreatedAtAction(nameof(GetCar), new { id = newCar.Id }, newCar);
        }

        // PUT api/car/1
        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, Car updatedCar)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound(new { message = "Car not found for update" });

            car.Model = updatedCar.Model;
            car.Year = updatedCar.Year;
            return NoContent();
        }

        [HttpDelete("{id}")]
public ActionResult DeleteCar(int id)
{
    var car = cars.FirstOrDefault(c => c.Id == id);
    if (car == null)
        return NotFound(new { message = "Car not found for deletion" });

    cars.Remove(car);
    return Ok(new { message = $"Car with ID {id} deleted" });
}
    }
}
