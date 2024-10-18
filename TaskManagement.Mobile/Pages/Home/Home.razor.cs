using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TaskManagement.Mobile.Data;
using TaskManagement.Mobile.Data.Entities;
using TaskManagement.Mobile.Models;
using TaskManagement.Mobile.Pages.Tasks;

namespace TaskManagement.Mobile.Pages.Home
{
    public partial class Home
    {  
        public bool IsLoading { get; set; } = true;
        public List<UserModel> Users { get; set; }
        [Inject]  private TaskAppDbContext _dbContext { get; set; } 
            
        protected override async Task OnInitializedAsync()
        {
            await  GetAllUser(); 
            await Task.Delay(1000);
            IsLoading = false;
           // SeedData();
            await GetAllTask();
        }

        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            var user = await TaskService.GetAllUserAsync();
            Users = user.Select(x => new UserModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                CreatedDate = x.CreatedDate,

            }).ToList();
            return Users;
        }

        public async Task<IEnumerable<UserModel>> GetUserById( int id =1) {
            
            var userDetails = await TaskService.GetUserAsync(id);
            Users = userDetails.Select(x => new UserModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                CreatedDate = x.CreatedDate,

            }).ToList();
            return Users;
        } 
        public void SeedData()
        {   //check the table in have data if no dataset then will proceed to seeding data.
            if (_dbContext.TaskModelEntities.Any())
            { 
                return;
            }

            // ADD DATA TO DTO MODEL
            var tasks = new TaskModel
            {
                Id = 1,
                UserId = 1,
                TaskName = "Updating",
                CreatedDate = DateTime.Now.ToString("MM/dd/yyyy"),
                TaskDescription = "Updating Taks",
                ActiveInactice = true,
                TaskStatus = "In-pogress"
            };
            //transfer data from DTO to entity for simulation of data from List
            var taskEntity = new TaskEntities
            {
                Id = tasks.Id,
                UserId = tasks.UserId,
                TaskName = tasks.TaskName,
                CreatedDate = tasks.CreatedDate,
                TaskDescription = tasks.TaskDescription,
                ActiveInactice = tasks.ActiveInactice,
                TaskStatus = tasks.TaskStatus
            };
            _dbContext.TaskModelEntities.Add(taskEntity);
            _dbContext.SaveChanges();

        }
        public async Task<List<TaskModel>> GetAllTask()
        {
            var tasks = await _dbContext.TaskModelEntities.ToListAsync(); 

            var taskModel = tasks.Select(x => new TaskModel
            {
                Id =  x.Id,
                UserId = x.UserId,
                TaskName = x.TaskName,
                CreatedDate = x.CreatedDate,
                TaskDescription = x.TaskDescription,
                ActiveInactice = x.ActiveInactice,
                TaskStatus = x.TaskStatus
            }).ToList(); 
            return taskModel;
        }
    } 
 }
