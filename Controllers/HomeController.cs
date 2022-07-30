using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Entities;
using WebApiApp.Enums;
using WebApiApp.Manager.UnitOfWorks;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetCars/{color}")]
        public async Task<List<Car>> GetCarsByColorType(ColorType color)
        {
            var cars = await _unitOfWork.GetService<Car>().GetAllAsync(x => x.Color==color);
          
            return cars;
        }

        [HttpGet("GetBuses/{color}")]
        public async Task<List<Bus>> GetBusesByColorType(ColorType color)
        {
            var buses = await _unitOfWork.GetService<Bus>().GetAllAsync(x => x.Color == color);
           
            return buses;
        }

        [HttpGet("GetBoats/{color}")]
        public async Task<List<Boat>> GetBoatsByColorType(ColorType color)
        {
           var boats = await _unitOfWork.GetService<Boat>().GetAllAsync(x => x.Color == color);
        
            return boats;
        }

        [HttpDelete("DeleteCar/{id}")]
        public async Task DeleteCar(int id)
        {
            var car = await _unitOfWork.GetService<Car>().FindAsync(id);
            _unitOfWork.GetService<Car>().Remove(car);
            await _unitOfWork.SaveChangesAsync();
        }

        [HttpPost("TurnonoffHeadLights/{id}")]
        public async Task TurnonoffHeadLights(int id)
        {
            var car =await _unitOfWork.GetService<Car>().FindAsync(id);
            car.HeadLights = !car.HeadLights;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
