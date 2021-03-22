using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SWTGr16Handin2_vers02.LogToFile
{
    public class LogToFile : ILog
    {
        private string _logFile;

        public void DoorLocked(string id)
        {
            using (var w = File.AppendText(_logFile))
            {
                w.WriteLine(DateTime.Now + ": Skab låst med id: {0}", id);
            }

        }

        public void DoorUnlocked(string id)
        {
            using (var w = File.AppendText(_logFile))
            {
                w.WriteLine(DateTime.Now + ": Skab låst op med id: {0}", id);
            }
        }
    }
}
