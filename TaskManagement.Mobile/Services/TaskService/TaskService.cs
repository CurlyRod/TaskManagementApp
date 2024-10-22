using Microsoft.EntityFrameworkCore;
using SQLite;
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
    public class TaskService 
    {   
        private readonly ITaskRepository _taskRepository;   
        public TaskService(ITaskRepository taskRepository)
        { 
            _taskRepository = taskRepository;
        }
        public async Task<IEnumerable<TaskEntities>> GetAllTaskAsync() 
        { 
            return await _taskRepository.GetTasksInfoAsync();
        }
        public async Task<IEnumerable<UserInfoEntities>> GetUsersAsync(int id)
        { 
            return await _taskRepository.GetUserInfoAsync(id);  
        }

        public async Task SaveTaskAsync(TaskModel taskModel)
        {
            await _taskRepository.SaveTaskAsync(taskModel);  
        }

    }
}