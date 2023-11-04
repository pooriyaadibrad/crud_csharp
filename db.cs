using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace WindowsFormsApp21
{
    public class db:DbContext
    {
        public db():base("rt")
        {

        }
        public DbSet<laptop> laptops { get; set; }
    }
}
