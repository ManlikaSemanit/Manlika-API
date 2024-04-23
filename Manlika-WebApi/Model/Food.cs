using System.ComponentModel.DataAnnotations;

namespace Manlika_WebApi.Model
{
    public class Food
    {
        [Key]
        public int FoodID { get; set; }
        public string? FoodName { get; set; }
        public int FoodPrice { get; set; }
    }
}
