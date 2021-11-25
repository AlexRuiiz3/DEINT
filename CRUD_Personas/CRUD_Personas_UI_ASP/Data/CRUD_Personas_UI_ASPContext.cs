using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_Personas_UI_ASP.Models;

namespace CRUD_Personas_UI_ASP.Data
{
    public class CRUD_Personas_UI_ASPContext : DbContext
    {
        public CRUD_Personas_UI_ASPContext (DbContextOptions<CRUD_Personas_UI_ASPContext> options)
            : base(options)
        {
        }

        public DbSet<ClsPersonaDepartamentos> ClsPersonaDepartamento { get; set; }
    }
}
