using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CaseService _caseService;


        public MainWindow()
        {
            InitializeComponent();
            _caseService = new CaseService();
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            await _caseService.SaveAsync(new Models.CaseAddModel
            {
                Title = Title.Text,
                Description = Description.Text,
                User = new Models.UserModel()
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Email = Email.Text,
                    PhoneNumber = PhoneNumber.Text,
                    StreetName = StreetName.Text,
                    PostalCode = PostalCode.Text,
                    City = City.Text,
                    UserType = "Customer"
                }
            });
        }
    }
}
