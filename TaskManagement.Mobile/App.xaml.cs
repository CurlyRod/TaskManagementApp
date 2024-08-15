using TaskManagement.Mobile.Data;

namespace TaskManagement.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            dbContext =  new TaskAppDbContext();
            MainPage = new MainPage();
        }
        public static TaskAppDbContext dbContext { get; private set; }
    }
}
