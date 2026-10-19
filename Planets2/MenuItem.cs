using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets2
{
    public class MenuItem
    {
        public string Description { get; set; }
        public Action CallBack {  get; set; }
        public MenuItem(string description, Action callback) 
        {
            Description = description;
            CallBack = callback;
        }
    }
}
