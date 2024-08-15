namespace TaskManagement.Mobile.Pages.Home
{
    public partial class Home
    {   
        // for test purpose only if this app have a background process.
        public bool IsLoading { get; set; } = true;
        protected override async Task OnInitializedAsync()
        {   
            
            await Task.Delay(2000); // Set only for 2s for loading. Ui 
            IsLoading = false; 

        }
        
    }
}