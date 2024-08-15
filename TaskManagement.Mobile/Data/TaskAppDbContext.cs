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

    public class TaskAppDbContext 
    {

        public SQLiteAsyncConnection _dbConnection;
        private readonly string nameSpace = typeof(TaskAppDbContext).Namespace;
        public const string dbFileName = "taskapp.db";
        public static string dbPathName => Path.Combine(FileSystem.AppDataDirectory, dbFileName);
      
        public const SQLite.SQLiteOpenFlags flags = 
                             SQLiteOpenFlags.ReadOnly |  
                             SQLiteOpenFlags.Create | 
                             SQLiteOpenFlags.SharedCache;
        public TaskAppDbContext()
        {
            if( _dbConnection is null)
            {   
               _dbConnection = new SQLiteAsyncConnection(dbPathName, flags);
               _dbConnection.CreateTableAsync<UserInfoEntities>();
            }    
        }  
      
    }
}
