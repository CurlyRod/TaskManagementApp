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
            _context.Database.Migrate();
         //   SeedData();
            await Task.Delay(2000); // Set only for 2s for loading. Ui 
            IsLoading = false;
             await  GetAllUser(); 
        }

           private void SeedData()
        {
            if (_context.UserModelEntities.Any()) {
                return;
            }
            var user = new UserModel //DTO
            {
                Id = 1,
                Name = "Test", 
                Email = "Test@gmail.com",
                CreatedDate = DateTime.Now.ToString("M/dd/yyyy"),
            };

            //DTO to Entity
            var userEntity = new UserInfoEntities
            {
                 Id = user.Id,
                 Name = user.Name,
                 Email = user.Email,
                 CreatedDate  = user.CreatedDate
            };

            //add to context
            _context.UserModelEntities.Add(userEntity) ;
            _context.SaveChanges();
        }
        public async Task<List<UserModel>> GetAllUser()
        {
           
            var userEntities =  await _context.UserModelEntities.ToListAsync();

            var userModels = userEntities.Select(userEntity => new UserModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                CreatedDate = userEntity.CreatedDate
            }).ToList();
            return Users = userModels;
            // Return the list of UserModel DTOs


        }
        
    }
}