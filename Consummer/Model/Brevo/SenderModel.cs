using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consummer.Model.Config
{
	public class SenderModel : Pessoa
	{
		public SenderModel()
		{

		}

		public SenderModel(string email, string nome) : base(email, nome)
		{
		}
	}
}