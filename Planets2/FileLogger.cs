using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets2
{
    public class FileLogger
    {
        private readonly string _path;
        private static readonly object _lock = new();

        public FileLogger(string path = "planets.log")
        {
            _path = path;
        }
        public void LogError(string message)
        {
            Write("ERROR", message);
        }
        public void LogInfo(string message)
        {
            Write("INFO", message);
        }
        private void Write(string level, string message)
        {
            lock (_lock)
            {
                File.AppendAllText(_path,
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}{Environment.NewLine}");
            }
        }
    }
}
