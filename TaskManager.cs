using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BotmanChatbot
{
    internal class TaskManager
    {
        private List<TaskStorageHelper> tasks;

        public TaskManager()
        {
            LoadTasks(); 
        } 

        public void AddTask(string title, string reminder)
        {
            tasks.Add(new TaskStorageHelper
            {
                Title = title,
                Reminder = reminder,
                IsComplete = false
            });

            SaveTasks();
        }

         public void DeleteTask(int index)
         {
            if(index >= 0 && index < tasks.Count) 
            {
                tasks.RemoveAt(index);
                SaveTasks();
            }
         }


        public void MarkComplete(int index)
        {
            if(index >= 0 && index < tasks.Count)
            {
                tasks[index].IsComplete = true;
                SaveTasks();
            }
        }

        public List<TaskStorageHelper> GetTasks()
        {
            return tasks;
        }


        private void LoadTasks()
        {
            if (File.Exists("tasks.json"))
            {
                string json = File.ReadAllText("tasks.json");
                tasks = JsonConvert.DeserializeObject<List<TaskStorageHelper>>(json);
            }
        }

        private void SaveTasks()
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText("tasks.json", json);

        }


    }
}
