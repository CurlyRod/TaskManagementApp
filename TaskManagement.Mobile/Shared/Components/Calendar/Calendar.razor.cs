using System.Globalization;

namespace TaskManagement.Mobile.Shared.Components.Calendar
{
    public partial class Calendar
    {
        private string[] DayName = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        private List<List<DateTime?>> Weeks = new();
        private  DateTime CurrentDate = DateTime.Now;
        private int MonthNow => CurrentDate.Month;
        private int YearNow => CurrentDate.Year;
        public int DateNow { get; set; } = DateTime.Now.Day; 

        protected override async Task OnInitializedAsync()
        {
             GenerateCalendar(YearNow, MonthNow);
             StateHasChanged();
        }
        public bool IsActive(int daynumber)
        { 
            return daynumber == DateNow;
        }

        public void GenerateCalendar(int year, int month)
        { 
            Weeks.Clear();
            var firstDay = new  DateTime(year, month, 1);
            var totalDays =  DateTime.DaysInMonth(year, month);
           
            var CurrentDay = firstDay;
            var Week = new List<DateTime?>(); 

            for (int i = 0; i < (int)firstDay.DayOfWeek; i++)
            {
                Week.Add(null); // if the day not start in sunday meaning Null.  --rod
            }

            for (int day = 1; day <= totalDays; day++) 
            {
                if (Week.Count == 7)
                {
                    Weeks.Add(Week); 
                    Week = new List<DateTime?>();
                }
                Week.Add(CurrentDay); 
                CurrentDay = CurrentDay.AddDays(1);   
            }

            while (Week.Count < 7)
            {
                Week.Add(null);
            }
            Weeks.Add(Week);
        }
        public void NextMonth()
        { 
            CurrentDate =  CurrentDate.AddMonths(1); 
            GenerateCalendar(YearNow, MonthNow);
           
        }
        public void PreviousMonth() 
        {
            CurrentDate = CurrentDate.AddMonths(-1);
            GenerateCalendar(YearNow, MonthNow);
        }

    }
}