using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Consummer.Model
{
	public class Pessoa
	{
		public Pessoa()
		{

		}

		public Pessoa(string email, string name)
		{
			Email = email;
			Name = name;
		}

		[JsonPropertyName("email")]
		[Required]
		public string Email { get; set; }
		[JsonPropertyName("name")]
		[Required]
		public string Name { get; set; }
	}
}
