using Manlika_WebApi.App_Start;
using Manlika_WebApi.Model;
using System;
using System.Diagnostics.Metrics;

namespace Manlika_WebApi.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService()
        {
            using (var context = new ApiContext())
            {
                var customerOrders = new List<CustomerOrder>
                {
                    new CustomerOrder
                    {
                        OrderID = 1,
                        OrderNo = "ORD0001",
                        CustomerID = 1,
                        TotalQty = 4,
                        TotalPrice = 600
                    },
                    new CustomerOrder
                    {
                        OrderID = 2,
                        OrderNo = "ORD0002",
                        CustomerID = 2,
                        TotalQty = 3,
                        TotalPrice = 450
                    }
                };
                context.CustomerOrders?.AddRange(customerOrders);

                var customers = new List<Customer>
                {
                    new Customer
                    {
                        CustomerID = 1,
                        FirstName ="Manlika",
                        LastName ="Semanit"
                    },
                    new Customer
                    {
                        CustomerID = 2,
                        FirstName ="Somchai",
                        LastName ="Suwan"
                    }
                };
                context.Customers?.AddRange(customers);

                var foods = new List<Food>
                {
                    new Food
                    {
                        FoodID = 1,
                        FoodName = "Hamberger",
                        FoodPrice = 40
                    },
                    new Food
                    {
                        FoodID = 2,
                        FoodName = "Spaghetti",
                        FoodPrice = 120
                    },
                    new Food
                    {
                        FoodID = 3,
                        FoodName = "Lobster",
                        FoodPrice = 400
                    },
                    new Food
                    {
                        FoodID = 4,
                        FoodName = "French fries",
                        FoodPrice = 40
                    },
                    new Food
                    {
                        FoodID = 5,
                        FoodName = "Roast Chicken",
                        FoodPrice = 150
                    },
                    new Food
                    {
                        FoodID = 6,
                        FoodName = "Steamed Crat",
                        FoodPrice = 150
                    }
                };
                context.Foods?.AddRange(foods);

                var customerFood = new List<CustomerFood>
                {
                    new CustomerFood { CustomerFoodID = 1, CustomerID = 1 , FoodID = 1, FoodQty = 1},
                    new CustomerFood { CustomerFoodID = 2, CustomerID = 1 , FoodID = 2, FoodQty = 1},
                    new CustomerFood { CustomerFoodID = 3, CustomerID = 1 , FoodID = 3, FoodQty = 1},
                    new CustomerFood { CustomerFoodID = 4, CustomerID = 1 , FoodID = 4, FoodQty = 1},
                    new CustomerFood { CustomerFoodID = 5, CustomerID = 2 , FoodID = 5, FoodQty = 1},
                    new CustomerFood { CustomerFoodID = 6, CustomerID = 2 , FoodID = 6 , FoodQty = 2},
                    new CustomerFood { CustomerFoodID = 7, CustomerID = 2 , FoodID = 6 , FoodQty = 2}
                };
                context.CustomerFood?.AddRange(customerFood);

                context.SaveChanges();
            }
        }

        public List<CustomerOrderSummary> GetCustomerOrderSummary()
        {
            using (var context = new ApiContext())
            {

                var results = from order in context.CustomerOrders
                                join cus in context.Customers on order.CustomerID equals cus.CustomerID
                                select new CustomerOrderSummary
                                {
                                    OrderID = order.OrderID,
                                    OrderNo = order.OrderNo,
                                    FirstName = cus.FirstName,
                                    LastName = cus.LastName,
                                    TotalQty = order.TotalQty,
                                    TotalPrice = order.TotalPrice,
                                    CustomerFoodSummary = (from cusFood in context.CustomerFood
                                                           join food in context.Foods on cusFood.FoodID equals food.FoodID
                                                           where cusFood.CustomerID == order.CustomerID
                                                           select new CustomerFoodSummary
                                                            {
                                                                FoodName = food.FoodName,
                                                                FoodPrice = food.FoodPrice,
                                                                FoodQty = cusFood.FoodQty
                                                            }).ToList()
                                };


                return results.ToList();
            }
        }
        
    }
}
