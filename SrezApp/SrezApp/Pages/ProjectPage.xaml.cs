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
    public partial class ProjectPage : ContentPage
    {
        private static Project currentProject;
        private static User currentUser;
        public ProjectPage(Project project, User user)
        {
            InitializeComponent();
            currentProject = project;
            currentUser = user;
            BtnAddProject.IsVisible = false;
        }
        public ProjectPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            BtnEdit.IsVisible = false;
            BtnDeleteProject.IsVisible = false;
        }

        private  bool DateIsCorrect()
        {
            if (DPDate.Date > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private async void BtnAddProject_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", $"Вы точно хотите добавить {EName.Text}?", "Да", "Нет");
            
            if (result == true && DateIsCorrect())
            {
                Project project = new Project();
                project.Name = EName.Text;
                project.Description = EDDescription.Text;
                project.Date = DPDate.Date;
                project.ID_User = currentUser.Id;
                App.Db.SaveProject(project);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Некорректная дата", $"Введите корректную дату", "Ладно");
            }
        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(" ", $"Вы хотите изменить {currentProject.Name}?", "Изменить", "Отмена"))
            {
                if (!String.IsNullOrEmpty(currentProject.Name) && DateIsCorrect())
                {
                    App.Db.SaveProject(currentProject);
                }
                else
                {
                    await DisplayAlert("Некорректная дата", $"Введите корректную дату", "Ладно");
                }
                await Navigation.PushAsync(new ProjectsPage(currentUser));
            }
        }

        private async void BtnDeleteProject_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(" ", $"Вы хотите удалить {currentProject.Name}?", "Удалить", "Отмена"))
            {
                App.Db.DeleteProject(currentProject.Id);
                await Navigation.PushAsync(new ProjectsPage(currentUser));
            }
        }
    }
}