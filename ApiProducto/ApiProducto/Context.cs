using ApiProducto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProducto
{
    public class Context:DbContext
    {

        public DbSet<Producto> Producto { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

    }
}
