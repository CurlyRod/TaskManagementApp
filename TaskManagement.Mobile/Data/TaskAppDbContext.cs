using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Mobile.Models;
using Microsoft.Extensions.Configuration;

namespace TaskManagement.Mobile.Data
{

    public class TaskAppDbContext : DbContext
    {
        public TaskAppDbContext()
        { 

        }
        public DbSet<UserInfoEntities> UserModelEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string dbName = "taskapp.db";
            var dbPathName = Path.Combine(FileSystem.AppDataDirectory, dbName);
            optionsBuilder.UseSqlite($"Filename = {dbPathName}");
        }

    }
}
