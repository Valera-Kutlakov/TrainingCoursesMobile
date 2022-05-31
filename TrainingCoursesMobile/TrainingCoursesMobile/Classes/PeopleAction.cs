using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrainingCoursesMobile.Classes
{
    public class PeopleAction
    {
        SQLiteConnection database;

        public PeopleAction(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
        }

        public void CreateTable()
        {
            database.CreateTable<People>();
        }
        public List<Course> GetCourse()
        {
            return database.Table<Course>().ToList();
        }
        public List<CourseForm> GetCourseForm()
        {
            return database.Table<CourseForm>().ToList();
        }
        public List<Organization> GetOrganization()
        {
            return database.Table<Organization>().ToList();
        }
        public List<Qualification> GetQualification()
        {
            return database.Table<Qualification>().ToList();
        }
        public  People GetItem(int id)
        {
            return database.Get<People>(id);
        }
        public People GetPeopleLogin(string login)
        {
            return database.Table<People>().FirstOrDefault(x => x.Login == login);
        }
        public People GetPeopleLoginPassword(string login, string password)
        {
            return database.Table<People>().FirstOrDefault(x => x.Login == login && x.Password == password);
        }
        public int DeleteItem(People item)
        {
            return database.Delete(item);
        }
        public int DeleteCourse(Course item)
        {
            return database.Table<Course>().Delete(x => x.CourseID == item.CourseID);
        }
        public int AddCourse(Course item)
        {
            return database.Insert(item);
        }
        public int SaveItem(People item)
        {
            if (item.PeopleID != 0)
            {
                database.Update(item);
                return item.PeopleID;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
