using Microsoft.AspNetCore.Components;

namespace TaskManagement.Mobile
{       
    public partial class Main
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        public void BackToDashboard()
        {
            NavigationManager.NavigateTo("/home");
        }
    }
}