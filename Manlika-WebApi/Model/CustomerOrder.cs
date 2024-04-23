using System.ComponentModel.DataAnnotations;

namespace Manlika_WebApi.Model
{
    public class CustomerOrder
    {
        [Key]
        public int OrderID { get; set; }
        public string? OrderNo { get; set; }
        public int CustomerID { get; set; }
        public int TotalQty { get; set; }
        public int TotalPrice { get; set; }
        public List<CustomerFood>? CustomerFoods { get; set; }
    }

    public class CustomerOrderSummary
    {
        [Key]
        public int OrderID { get; set; }
        public string? OrderNo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int TotalQty { get; set; }
        public int TotalPrice { get; set; }
        public List<CustomerFoodSummary>? CustomerFoodSummary { get; set; }
    }

    public class CustomerFoodSummary
    {
        public string? FoodName { get; set; }
        public int FoodQty { get; set; }
        public int FoodPrice { get; set; }
    }
}
