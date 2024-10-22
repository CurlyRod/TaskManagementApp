using Microsoft.AspNetCore.Components;

namespace TaskManagement.Mobile.Pages.Tasks
{
    public partial class AddTask
    {
        [Parameter] public string? Date { get; set; }
        public string? ConvertedDate { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Converted();
        }
        public void Converted()
        {
            if (Date != null)
            {
                DateTime date = DateTime.ParseExact(Date, "MM-dd-yyyy", null);
                ConvertedDate = date.ToString("MMMM dd yyyy");
            }
        }
    } 
}