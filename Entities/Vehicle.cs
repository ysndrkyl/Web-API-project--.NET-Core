using WebApiApp.Enums;

namespace WebApiApp.Entities
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public int Capasity { get; set; }
        public ColorType Color { get; set; }
    }
}
