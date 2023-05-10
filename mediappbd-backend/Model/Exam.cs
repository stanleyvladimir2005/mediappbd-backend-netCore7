using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mediappbd_backend.Model
{
    [Table("exam")]
    public class Exam
    {
        [Key, Required]
        public int Id { get; set; }

        public String examName { get; set; }

        public String description { get; set; }

        public Boolean status { get; set; }
    }
}
