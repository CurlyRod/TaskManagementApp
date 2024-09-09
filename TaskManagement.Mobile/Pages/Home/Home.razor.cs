using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Mobile.Data;
using TaskManagement.Mobile.Models;


namespace TaskManagement.Mobile.Pages.Home
{
    public partial class Home
    {   
        // for test purpose only if this app have a background process.
        public bool IsLoading { get; set; } = true;
        [Inject]
        private TaskAppDbContext _context { get; set; }
        public List<UserModel> Users { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await  GetAllUser();
            await Task.Delay(1000);
            IsLoading = false;
        }


        public async Task<List<UserModel>> GetAllUser()
        {
            var user = await TaskService.GetAllUsersAsync();
            Users = user.Select(x => new UserModel
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