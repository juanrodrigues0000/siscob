using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using siscob;

namespace WebApplication1.Context
{
    public class ImagemDbContext : DbContext
    {
        public ImagemDbContext(DbContextOptions<ImagemDbContext> options) : base(options) { }

        public DbSet<Documento> DocumentoSet { get; set; }
    }
}