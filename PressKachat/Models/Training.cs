using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressKachat.Models
{
    class Training
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ObservableCollection<Exercise> Exercises { get; set; }
    }
}
