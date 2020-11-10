using IsracardServer.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsracardServer.Services
{
    public sealed class TasksServiceSingleton
    {
        private ConcurrentBag<CustomTask> _tasks;

        private TasksServiceSingleton()
        {
            _tasks = new ConcurrentBag<CustomTask>();

        }
        private static readonly Lazy<TasksServiceSingleton> lazy = new Lazy<TasksServiceSingleton>(() => new TasksServiceSingleton());
        public static TasksServiceSingleton Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void AddTask(CustomTask customTask)
        {
            _tasks.Add(customTask);
        }
        public List<CustomTask> GetTasks()
        {
            return _tasks.ToList();
        }
    }




}
