using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using SQLite;
using System.IO;
using TrainingCoursesMobile.Classes;

namespace TrainingCoursesMobile
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "TrainingCources.db";
        public static PeopleAction database;
        public static PeopleAction Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    if (!File.Exists(dbPath))
                    {
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        using (Stream stream = assembly.GetManifestResourceStream($"TrainingCoursesMobile.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                    }
                    database = new PeopleAction(dbPath);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
