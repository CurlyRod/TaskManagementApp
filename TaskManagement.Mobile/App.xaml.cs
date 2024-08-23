using Microsoft.EntityFrameworkCore;
using TaskManagement.Mobile.Data;
using TaskManagement.Mobile.Models;

namespace TaskManagement.Mobile
{
    public partial class App : Application
    {   
       public App(MainPage mainPage)
        { 
            InitializeComponent();
            MainPage = mainPage;
        }
     
    }
}
