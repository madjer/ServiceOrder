using System;
using System.Collections.Generic;

namespace API.Models
{
    public class ServiceOrder
    {
        public int Id { get; set; }
				public Client Client { get; set; }
				public List<Product> UsedProducts { get; set; }
    }
}