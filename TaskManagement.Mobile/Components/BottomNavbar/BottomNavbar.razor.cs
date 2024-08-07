using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using MudBlazor;

namespace TaskManagement.Mobile.Components.BottomNavbar
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
                new MenuBarItem  { TabName = "", Link = "/", Icon = Icons.Material.Filled.Home },
                new MenuBarItem  { TabName = "", Link = "/calendar", Icon = Icons.Material.Filled.CalendarMonth },
                new MenuBarItem  { TabName = "", Link = "/counter", Icon = Icons.Material.Filled.LibraryBooks },
                new MenuBarItem  { TabName = "", Link = "/fetchdata", Icon = Icons.Material.Filled.People }, 
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
            NavigationManager.NavigateTo(url);
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