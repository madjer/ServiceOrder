using System;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }
				public String Brand { get; set; }
				public Provider Provider { get; set; }
    }
}