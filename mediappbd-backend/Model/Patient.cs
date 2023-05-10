using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mediappbd_backend.Model
{
    [Table("patient")]
    public class Patient
    {
        [Key,Required]
        public int Id { get; set; }

        public String firstName { get; set; }

        public String lastName { get; set; }

        public String dui { get; set; }

        public String address { get; set; }

        public String phone { get; set; }

        public String email { get; set; }

        public Boolean status { get; set; }
    }
}
