using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using Projeto.DAL.Mapeamentos;
using Projeto.Entidades;

namespace Projeto.DAL.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext() : base(ConfigurationManager.ConnectionStrings["estudo"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
