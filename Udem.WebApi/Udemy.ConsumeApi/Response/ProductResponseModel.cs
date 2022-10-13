using System;

namespace Udemy.ConsumeApi.Response
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
     
        public string ImagePath { get; set; }

    }
}
