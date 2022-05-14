using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SrezApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var user = App.Db.GetUser(ELogin.Text, EPassword.Text);
            if (user != null)
            {
                await Navigation.PushAsync(new ProjectsPage(user));
            }
            else
            {
                await DisplayAlert("Ошибка авторизации", "Неверный логин или пароль", "Закрыть");
            }
        }

        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegPage());
        }
    }
}