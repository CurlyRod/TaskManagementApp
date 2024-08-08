using Microsoft.AspNetCore.Components;

namespace TaskManagement.Mobile.Pages.Onboarding
{
    public partial class Onboarding
    {
       [Inject] public NavigationManager NavigationManager { get; set; }

        public void GoToDashboard()
        {
            NavigationManager.NavigateTo("/home");
        }
    }
}