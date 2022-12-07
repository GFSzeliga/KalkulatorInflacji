using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Year { get; set; }

        public Pupil Pupil { get; set; }
        public int PupilId { get; set; }
    }
}
