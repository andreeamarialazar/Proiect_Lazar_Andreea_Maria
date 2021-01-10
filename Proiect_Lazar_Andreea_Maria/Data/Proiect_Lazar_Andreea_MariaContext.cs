using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Lazar_Andreea_Maria.Models;

namespace Proiect_Lazar_Andreea_Maria.Data
{
    public class Proiect_Lazar_Andreea_MariaContext : DbContext
    {
        public Proiect_Lazar_Andreea_MariaContext (DbContextOptions<Proiect_Lazar_Andreea_MariaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Lazar_Andreea_Maria.Models.Game> Game { get; set; }

        public DbSet<Proiect_Lazar_Andreea_Maria.Models.Publisher> Publisher { get; set; }

        public DbSet<Proiect_Lazar_Andreea_Maria.Models.Category> Category { get; set; }
    }
}
