using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDatabase.Models
{
    [Table("Student")]
    public class Pupil
    {
        [Column("StudentId")]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        [DisallowNull]
        [MinLength(10)]
        public string Surname { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
