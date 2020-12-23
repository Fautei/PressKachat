using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressKachat.Models
{
    class Exercise
    {
        public string Name { get; set; }
        public ushort Repeats { get; set; }
        public TimeSpan Time { get; set; }
    }
}
