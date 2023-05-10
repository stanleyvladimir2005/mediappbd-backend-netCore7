using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mediappbd_backend.Model
{
    [Table("specialty")]
    public class Specialty
    {
        [Key,Required]
        public int Id { get; set; }

        public String specialtyName { get; set; }

        public Boolean status { get; set; }
    }
}
