using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoursesMobile.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrainingCoursesMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMains : ContentPage
    {
        public PageMains()
        {
            InitializeComponent();
            Title = "Список курсов";
        }

        protected override void OnAppearing()
        {
            lvCourses.ItemsSource = App.Database.GetCourse();
            base.OnAppearing();
        }

        private async void lvCourses_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvCourses.SelectedItem == null)
                return;
            bool result = await DisplayAlert("Просмотр курса", $"Курс - \"{(lvCourses.SelectedItem as Course).Program}\"", "Удалить", "Отмена");
            if (result == true)
            {
                try
                {
                    App.Database.DeleteCourse(lvCourses.SelectedItem as Course);
                    await DisplayAlert("Уведомление", "Удаление успешно завершено", "ОК");
                    lvCourses.ItemsSource = App.Database.GetCourse();
                    lvCourses.SelectedItem = null;
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", $"{ex.Message}", "Отмена");
                    return;
                }
            }
            if (result == false)
            {
                lvCourses.SelectedItem = null;
            }
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAdd());
        }
    }
}