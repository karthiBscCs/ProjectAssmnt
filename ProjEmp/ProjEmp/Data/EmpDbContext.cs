using Microsoft.EntityFrameworkCore;
using ProjEmp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjEmp.Data
{
    public class EmpDbContext: DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options): base(options){}

        public bool IsDbCntd(){
            try{Database.OpenConnection();Database.CloseConnection();return true;}
            catch(Exception ex){return false;}
        }

        public DbSet<EmpVewMdl> Employees { get; set; }
    }
}
