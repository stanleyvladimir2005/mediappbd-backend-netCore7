using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mediappbd_backend.Model
{
    [Table("especialidad")]
    public class Especialidad
    {
        [Key,Required]
        public int Id { get; set; }

        public String nombre { get; set; }

        public Boolean estado { get; set; }
    }
}
