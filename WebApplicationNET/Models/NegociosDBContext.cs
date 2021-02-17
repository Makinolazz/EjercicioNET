using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNET.Models
{
    public class NegociosDBContext :DbContext
    {
        public NegociosDBContext(DbContextOptions<NegociosDBContext> options)
            : base(options)
        {
        }

        public DbSet<Negocio> Negocios { get; set; }
    }
}
