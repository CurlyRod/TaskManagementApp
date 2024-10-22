using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Mobile.Data;
using TaskManagement.Mobile.Data.Entities;
using TaskManagement.Mobile.Models;

namespace TaskManagement.Mobile.Services.TaskService
{
    public interface ITaskRepository
    {
       // Task<IEnumerable<UserInfoEntities>> GetAllUserAsync();
        //Task<bool> DeleteTaskAsync(int taskId);
        Task<IEnumerable<UserInfoEntities>> GetUserInfoAsync(int userId);
        Task<IEnumerable<TaskEntities>> GetTasksInfoAsync();
        Task  SaveTaskAsync(TaskModel task);
    }

    public class TaskRepository : ITaskRepository
    {
        private readonly TaskAppDbContext _context;
        public TaskRepository(TaskAppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskEntities>> GetTasksInfoAsync()
        {
            try
            {
                return await _context.TaskModelEntities.ToListAsync();
            }
            catch (Exception ex )
            {

                throw new Exception("Error fetching Tasks.", ex);
            }
        }
        public async Task<IEnumerable<UserInfoEntities>> GetUserInfoAsync(int id)
        {
            try
            {
                return await _context.UserModelEntities.Where(x => x.Id == id).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error not found user.", ex);
            }
        }
        public async Task SaveTaskAsync(TaskModel taskModel)
        {
            var taskEntities = new TaskEntities
            {
                UserId = taskModel.UserId,
                TaskName = taskModel.TaskName,
                TaskDescription = taskModel.TaskDescription,
                CreatedDate = taskModel.CreatedDate,
                TaskStatus = taskModel.TaskStatus,
                ActiveInactice = taskModel.ActiveInactice,
            };

            _context.TaskModelEntities.Add(taskEntities);
            await _context.SaveChangesAsync(); 
        }
    }
}
