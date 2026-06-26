using System;
using System.Collections.Generic;
using System.Text;

namespace BotmanChatbot
{ 
    internal class ActivityLogger
    {
        private List<string> logs;

        public ActivityLogger()
        {
            logs = new List<string>();
        }

        public void AddLog(string action)
        {
            logs.Add(
                $"{DateTime.Now}: {action}"
                );
        }

        public List<string> GetLogs()
        {
            return logs; 
        }
    }
}
