using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mediappbd_backend.Model
{
    [Table("medic")]
    public class Medic
    {
        [Key,Required]
        public int Id { get; set; }

        public String firstName { get; set; }

        public String lastName { get; set; }

        public String dui { get; set; }

        public String phone { get; set; }

        public String email { get; set; }

        public String photoUrl { get; set; }

        public Boolean status { get; set; }
    }
}
