using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mediappbd_backend.Model
{
    [Table("examen")]
    public class Examen
    {
        [Key, Required]
        public int Id { get; set; }

        public String nombre { get; set; }

        public String descripcion { get; set; }

        public Boolean estado { get; set; }
    }
}
