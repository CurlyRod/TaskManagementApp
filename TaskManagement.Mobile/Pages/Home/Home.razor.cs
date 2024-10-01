using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TaskManagement.Mobile.Data;
using TaskManagement.Mobile.Models;

namespace TaskManagement.Mobile.Pages.Home
{
    public partial class Home
    {  
        public bool IsLoading { get; set; } = true;
        public List<UserModel> Users { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await  GetAllUser(); 
            await Task.Delay(1000);
            IsLoading = false;
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
    } 
 }
