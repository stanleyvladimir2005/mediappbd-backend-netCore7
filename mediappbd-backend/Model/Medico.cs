using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mediappbd_backend.Model
{
    [Table("medico")]
    public class Medico
    {
        [Key,Required]
        public int Id { get; set; }

        public String nombres { get; set; }

        public String apellidos { get; set; }

        public String dui { get; set; }

        public String telefono { get; set; }

        public String email { get; set; }

        public String photoUrl { get; set; }

        public Boolean estado { get; set; }
    }
}
