using Core.TableModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consummer.Context
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> dbContextOptions) : base(dbContextOptions) { }
    }
}
