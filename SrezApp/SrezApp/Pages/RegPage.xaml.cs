using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SrezApp.DataBase;

namespace SrezApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPage : ContentPage
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Login = ELogin.Text,
                Password = EPassword.Text
            };
            App.Db.SaveUser(user);
            await Navigation.PopAsync();
        }
    }
}