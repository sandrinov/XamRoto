using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Text;
using Tasky.Shared.BusinessLayer;
using Tasky.Shared.BusinessLayer.Contracts;

namespace Tasky.Shared.DataLayer
{
    public class TaskDatabase : SQLiteConnection
    {
        static object locker = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public TaskDatabase(string path) : base( path)
        {
            // create the tables
            CreateTable<Task>();
        }

        public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return (from i in Table<T>() select i).ToList();
            }
        }

        public T GetItem<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return Table<T>().FirstOrDefault(x => x.ID == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
        }

        public int SaveItem<T>(T item) where T : IBusinessEntity
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    Update(item);
                    return item.ID;
                }
                else
                {
                    return Insert(item);
                }
            }
        }

        public int DeleteItem<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return Delete(new T() { ID = id });
            }
        }
    }
}
