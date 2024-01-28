using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consummer.Model.Brevo
{
    public class ToModel : Pessoa
    {
        public ToModel()
        {

        }

        public ToModel(string email, string nome) : base(email, nome)
        {
        }
    }