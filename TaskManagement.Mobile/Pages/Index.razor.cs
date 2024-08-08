using Microsoft.AspNetCore.Components;

namespace TaskManagement.Mobile.Pages
{   
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } 
        public bool IsDoneOnBoarding { get; set; } = false;
        public void GotoHome()
        {
            NavigationManager.NavigateTo("/fetchdata");
        }
        protected override void OnInitialized()
        {
            if (IsDoneOnBoarding)
            {
                NavigationManager.NavigateTo("/hoome");
            }
            else 
            {
                NavigationManager.NavigateTo("/onboarding");
            }
        }
    }
}