using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using TrainingCoursesMobile.Classes;

namespace TrainingCoursesMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Title = "Training Courses Mobile";
        }

        protected override void OnAppearing()
        {
            //App.Database.CreateTable();
            base.OnAppearing();
        }

        private async void btnInside_Clicked(object sender, EventArgs e)
        {
            People peopleLogin = App.Database.GetPeopleLogin(txbLogin.Text);
            People peopleLoginPassword = App.Database.GetPeopleLoginPassword(txbLogin.Text, txbPassword.Text);

            if (peopleLogin == null)
            {
                await DisplayAlert("Ошибка", "Данный пользователь не зарегистрирован", "ОK");
            }
            else
            {
                if (peopleLoginPassword == null)
                {
                    await DisplayAlert("Ошибка", "Неправильный пароль", "ОK");
                }
                else
                {
                    if (peopleLoginPassword.IDCategory != 1)
                    {
                        await DisplayAlert("Уведомление", "Вы авторизовались под преподавателем, функционал будет доступен только под администратором", "ОK");
                    }
                    else
                    {
                        await Navigation.PushAsync(new PageMains());
                    }
                }
            }
        }
    }
}
