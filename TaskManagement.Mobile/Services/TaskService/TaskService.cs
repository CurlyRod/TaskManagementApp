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
    public class TaskService :  ITaskRepository
    {
        private readonly TaskAppDbContext _context;

        public TaskService(TaskAppDbContext context)
        {
            _context = context;

        }

        public Task<bool> DeleteTaskAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserInfoEntities>> GetAllUserAsync()
        {
            return await _context.UserModelEntities.ToListAsync();
        }

        public Task<IEnumerable<TaskModel>> GetTaskAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserInfoEntities>> GetUserAsync(int userId)
        {
            return await _context.UserModelEntities.Where(x => x.Id == userId).ToListAsync();
        }

    }
}