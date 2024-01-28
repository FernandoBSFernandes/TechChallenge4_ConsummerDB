using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consummer.Service.Interface
{
	public interface IEmailService
	{
		public Task BoasVindas(Usuario usuario);
	}
}
