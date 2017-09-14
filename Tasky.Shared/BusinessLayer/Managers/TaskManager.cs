using System;
using System.Collections.Generic;
using System.Text;

namespace Tasky.Shared.BusinessLayer.Managers
{
    public static class TaskManager
    {
        static TaskManager()
        {
        }

        public static Task GetTask(int id)
        {
            return DAL.TaskRepository.GetTask(id);
        }

        public static IList<Task> GetTasks()
        {
            return new List<Task>(DAL.TaskRepository.GetTasks());
        }

        public static int SaveTask(Task item)
        {
            return DAL.TaskRepository.SaveTask(item);
        }

        public static int DeleteTask(int id)
        {
            return DAL.TaskRepository.DeleteTask(id);
        }

    }
}
