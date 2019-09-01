using System;

namespace API.Models
{
    public class Address
    {
        public int Id { get; set; }
				public String Street { get; set; }
				public int Number { get; set; }
				public String Neighborhood { get; set; }
				public String City { get; set; }
				public String State { get; set; }
				public String Zip { get; set; }
    }
}