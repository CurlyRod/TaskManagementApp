using TaskManagement.Mobile.Data;

namespace TaskManagement.Mobile
{
    public partial class MainPage : ContentPage
    {   
        private readonly TaskAppDbContext context;
        public MainPage(TaskAppDbContext _context)
        {
            InitializeComponent();
            _context = context;
        }
    }
}
