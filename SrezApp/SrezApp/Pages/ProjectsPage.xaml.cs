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
    public partial class ProjectsPage : ContentPage
    {
        private static User currentUser;
        public ProjectsPage(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private async void NewProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage(currentUser));
        }

        private async void LVProjects_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Project selectedProject = (Project)e.SelectedItem;
            ProjectPage selectedProjectPage = new ProjectPage(selectedProject, currentUser);
            selectedProjectPage.BindingContext = selectedProject;
            await Navigation.PushAsync(selectedProjectPage);
        }
        protected override void OnAppearing()
        {
            LVProjects.ItemsSource = App.Db.GetProjectsByUser(currentUser.Id);
            base.OnAppearing();
        }
    }
}