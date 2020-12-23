using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressKachat.Models
{
    class ProgramTrainings
    {
        public string Name { get; set; }
        public ObservableCollection<Training> Trainings { get; set; }
    }
}
