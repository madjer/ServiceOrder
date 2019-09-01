using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Provider
    {
        public int Id { get; set; }
				public string Name { get; set; }
				public List<Address> Addresses { get; set; }
				public List<Telephone> Telephones { get; set; }
    }
}