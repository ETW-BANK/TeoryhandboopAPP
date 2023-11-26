using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teori.Model;

namespace Teori.Data
{
    internal class QnAContext:DbContext
    {
        public DbSet<QnA> QnAs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QnADatabase;Integrated Security=True;Pooling=False");
        }
    }
}
