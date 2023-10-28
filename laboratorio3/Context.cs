using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<evaluaciones> evaluaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=CC1PC59-60;Database=lab3;Trusted_Connection=True;");
    }
}
