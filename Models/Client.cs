using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Client
    {
			public int Id { get; set; }
			public string Name { get; set; }
			public String Document { get; set; }
			public List<Telephone> Telephones { get; set; }
			public List<Address> Addresses { get; set; }
    }
}