using Microsoft.AspNetCore.Components;

namespace TaskManagement.Mobile.Pages
{   
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public void GotoHome()
        {
            NavigationManager.NavigateTo("/fetchdata");
        }
    }
}