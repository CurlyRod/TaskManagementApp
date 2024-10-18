using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Mobile.Models;
using Microsoft.Extensions.Configuration;
using TaskManagement.Mobile.Data.Entities;

namespace TaskManagement.Mobile.Data
{

    public class TaskAppDbContext : DbContext
    {
        public TaskAppDbContext()
        { 

        }
        public DbSet<UserInfoEntities> UserModelEntities { get; set; }
        public DbSet<TaskEntities> TaskModelEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string dbName = "taskapp.db";
            var dbPathName = Path.Combine(FileSystem.AppDataDirectory, dbName);
            //optionsBuilder.UseSqlite($"Data Source={dbName}");  //uncomment this if new migration is need to apply 
            optionsBuilder.UseSqlite($"Filename={dbPathName}");

        }

    }
}
