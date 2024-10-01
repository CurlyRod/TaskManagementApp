using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Mobile.Models;

namespace TaskManagement.Mobile.Services.TaskService
{
    public interface ITaskRepository
    {
        Task<IEnumerable<UserInfoEntities>> GetAllUserAsync();
        Task<bool> DeleteTaskAsync(int taskId);
        Task<IEnumerable<UserInfoEntities>> GetUserAsync(int userId);
        Task<IEnumerable<TaskModel>> GetTaskAsync();

    }
}
