using Almacen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.DataMapper
{
    public class AlmacenDBContext : DbContext
    {
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<Imagen> Imagenes { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<ProductoCategoria> ProductoCategorias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-R5Q31NR;Initial Catalog=AlmacenDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoCategoria>().HasKey(x => new { x.CategoriaId, x.ProductoId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
