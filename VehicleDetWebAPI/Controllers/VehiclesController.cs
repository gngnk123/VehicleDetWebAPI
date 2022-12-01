using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleDetWebAPI.Data;
using VehicleDetWebAPI.Model;

namespace VehicleDetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehiclesDbContext dbContext;

        public VehiclesController(VehiclesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetVehicles()
        {
            return Ok(dbContext.Vehicles.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetVehicles([FromRoute]Guid id)
        {
            var Vehicle = dbContext.Vehicles.Find(id);
            if (Vehicle == null)
            {
                return NotFound();
            }
            else
                return Ok(Vehicle);
        }

        [HttpPost]
        public IActionResult AddVehicles(Requests rec)
        {
            var Vehicle = new Vehicle()
            {
                Id = Guid.NewGuid(),
                Make = rec.Make,
                Model= rec.Model
            };
            dbContext.Vehicles.Add(Vehicle);
            dbContext.SaveChanges();
            return Ok(Vehicle);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateVehicles([FromRoute]Guid id, Requests rec)
        {
            var Vehicle = dbContext.Vehicles.Find(id);
            if (Vehicle == null)
            {
                return NotFound();
            }
            else
            {
                Vehicle.Make = rec.Make;
                Vehicle.Model = rec.Model;        
                dbContext.SaveChanges();
                return Ok(Vehicle);
            }
            
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteVehicles([FromRoute] Guid id)
        {
            var Vehicle = dbContext.Vehicles.Find(id);
            if (Vehicle == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Remove(Vehicle);
                dbContext.SaveChanges();
                return Ok("Vehicle is Deleted");
            }

        }

    }
}
