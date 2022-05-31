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
    public partial class PageAdd : ContentPage
    {
        public PageAdd()
        {
            InitializeComponent();
            Title = "Добавление курса";

            pickCourseForm.ItemsSource = App.Database.GetCourseForm();
            pickOrganization.ItemsSource = App.Database.GetOrganization();
            pickQualification.ItemsSource = App.Database.GetQualification();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course()
                {
                    Program = txbProgram.Text,
                    IDOrganization = (pickOrganization.SelectedItem as Organization).OrganizationID,
                    PlanStart = dpStart.Date,
                    PlanEnd = dpEnd.Date,
                    CountHours = int.Parse(txbCountHours.Text),
                    CountPeopleMax = int.Parse(txbCountPeopleMax.Text),
                    CountPeopleNow = 0,
                    IDCourseForm = (pickCourseForm.SelectedItem as CourseForm).CourseFormID,
                    IDStatus = 1,
                    IDQualification = (pickQualification.SelectedItem as Qualification).QualificationID,
                    Description = txbDescription.Text
                };
                App.Database.AddCourse(course);
                await DisplayAlert("Уведомление", "Новый курс успешно создан", "ОК");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"{ex.Message}", "Отмена");
                return;
            }
        }
    }
}