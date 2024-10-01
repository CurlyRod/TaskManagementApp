

using TaskManagement.Mobile.Models;

namespace TaskManagement.Mobile.Pages.Tasks
{
    public partial class Tasks
    {
        public List<MonthAndDaysModel> MonthAndDays { get; set; } 
        public static int monthNow = DateTime.Now.Month; 
        public static int yearNow = DateTime.Now.Year;
        public int _dateSelected { get; set; } = DateTime.Now.Day;  
        protected override async Task OnInitializedAsync()
        {
            await GetMonthAndDays();

        }
        public async Task GetTaskAsyncByDate(int dateSelected)
        {
            _dateSelected = dateSelected;
            IsActive(dateSelected);
            StateHasChanged();
        }
        public bool IsActive(int dateSelected) 
        {
            return _dateSelected == dateSelected;
        }

        public async Task<List<MonthAndDaysModel>> GetMonthAndDays()
        {
            var daysInMonth = DateTime.DaysInMonth(yearNow, monthNow);
            var monthAndDays = new List<MonthAndDaysModel>();

            for (int i = 1; i <= daysInMonth; i++)
            {
                DateTime dt = new DateTime(yearNow, monthNow, i);
                string dayName = dt.ToString("ddd");
                int dayNumber = dt.Day;
              
                monthAndDays.Add(new MonthAndDaysModel
                {
                    DayNumber = dayNumber,
                    DayName = dayName
                });
            }
            return  MonthAndDays = monthAndDays ;
        }   
       
        
    }
}