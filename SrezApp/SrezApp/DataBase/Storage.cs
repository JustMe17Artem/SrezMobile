using System;
using System.Text;
using System.Collections.Generic;
using SQLite;
using System.Linq;

namespace SrezApp.DataBase
{
    internal class Storage
    {
        SQLiteConnection database;

        public Storage(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Project>();
            database.CreateTable<User>();
        }

        public IEnumerable<Project> GetProjects()
        {
            return database.Table<Project>().ToList();
        }

        public IEnumerable<Project> GetProjectsByUser(int idUser)
        {
            return GetProjects().Where(project => project.ID_User == idUser);
        }
        public Project GetProject(int id)
        {
            return database.Get<Project>(id);
        }

        public int SaveProject(Project project)
        {
            if (project.Id != 0)
            {
                database.Update(project);
                return project.Id;
            }
            else
            {
                return database.Insert(project);
            }
        }
        public int SaveUser(User user)
        {
            if (user.Id != 0)
            {
                database.Update(user);
                return user.Id;
            }
            else
            {
                return database.Insert(user);
            }
        }
        public User GetUser(string login, string password)
        {
            return GetUsers().Where(user => user.Login == login && user.Password == password).FirstOrDefault();
        }
        public int DeleteProject(int idProject)
        {
            return database.Delete<Project>(idProject);
        }
        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

    }
}
