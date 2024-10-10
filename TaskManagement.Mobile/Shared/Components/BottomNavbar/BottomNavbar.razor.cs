using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using MudBlazor;

namespace TaskManagement.Mobile.Shared.Components.BottomNavbar
{
    public partial class BottomNavbar
    {    
        public  IEnumerable <MenuBarItem> MenuBar { get; set; }
        private string currentRoute;
        public class MenuBarItem
        {
            public string TabName { get; set; } = default!; 
            public string Link { get; set; } = default!;     
            public string Icon { get; set; }
            public MudBlazor.Size IconSize { get; set; } = MudBlazor.Size.Medium;
            public MudBlazor.Color Color { get; set; } = MudBlazor.Color.Default;
        }
        protected override async Task OnInitializedAsync() 
        {
            await RenderMenuItems();
            currentRoute = NavigationManager.Uri;
            NavigationManager.LocationChanged += HandleLocationChanged;
        } 
        public async Task RenderMenuItems() 
        {
            MenuBar = new List<MenuBarItem>()
            {   
                new MenuBarItem  { TabName = "", Link = "/home", Icon = Icons.Material.Filled.Home ,  IconSize = default },
                new MenuBarItem  { TabName = "", Link = "/tasks", Icon = Icons.Material.Filled.CalendarMonth , IconSize = default }, 
                new MenuBarItem  { TabName = "", Link ="/addtask" , Icon= Icons.Material.Filled.AddCircle , IconSize = MudBlazor.Size.Large , Color = MudBlazor.Color.Primary },
                new MenuBarItem  { TabName = "", Link = "/", Icon = Icons.Material.Filled.LibraryBooks , IconSize = default },
                new MenuBarItem  { TabName = "", Link = "/onboarding", Icon = Icons.Material.Filled.People ,  IconSize = default }, 
            };
            await Task.CompletedTask; 

        }
        private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            currentRoute = e.Location;
            StateHasChanged();
        }
        private void OnRoute(string url)
        {
            if (url != "/addtask")
            {
                NavigationManager.NavigateTo(url);
            }
        }
        public bool IsVisible()
        {
            return !currentRoute.EndsWith("/onboarding") && !currentRoute.EndsWith("/");
        }
        private bool IsTabActive(string tabRoute)
        {
            return currentRoute.Contains(tabRoute, StringComparison.OrdinalIgnoreCase);
        }



    } 

}