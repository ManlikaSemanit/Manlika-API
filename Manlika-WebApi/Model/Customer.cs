using System.ComponentModel.DataAnnotations;

namespace Manlika_WebApi.Model
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class CustomerFood
    {
        [Key]
        public int CustomerFoodID { get; set; }
        public int CustomerID { get; set; }
        public int FoodID { get; set; }
        public int FoodQty { get; set; }
    }
}
