using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.ViewModels.ViewModel
{
    public class StudentViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Class { get; set; } = null!;

        public int? MarkObtained { get; set; }
    }
}
