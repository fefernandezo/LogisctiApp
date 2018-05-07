using LogisticApp.Interfaces;
using LogisticApp.Models;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Linq;
using Xamarin.Forms;





namespace LogisticApp.Data
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Platform,
                System.IO.Path.Combine(config.DirectoryDB, "LogisticApp.db3"));
            connection.CreateTable<LoginResult>();
            connection.CreateTable<RutasResult>();

        }

        public void Insert<T>(T model)
        {
            connection.Insert(model);
        }

        public void Update<T>(T model)
        {
            connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            connection.Delete(model);
        }

        public T First<T>(bool WithChildren) where T : class
        {
            if(WithChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault();

               

            }
            else
            {
                return connection.Table<T>().FirstOrDefault();
            }

        }

        public T GetList<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault();
            }
            else
            {
                return connection.Table<T>().FirstOrDefault();
            }

        }

        public T Find<T>(int pk, bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
            else
            {
                return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }

        }

        public void Dispose()
        {
            connection.Dispose();
        }

    }
}
