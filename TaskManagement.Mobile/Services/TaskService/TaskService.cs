using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Mobile.Data;
using TaskManagement.Mobile.Models;

namespace TaskManagement.Mobile.Services.TaskService
{
    public class TaskService
    {
        private readonly TaskAppDbContext _context;

        public TaskService(TaskAppDbContext context)
        {
            _context = context;

        }
        public async Task<List<UserInfoEntities>> GetAllUsersAsync()
        {
            return await _context.UserModelEntities.ToListAsync();
        }
    }
}