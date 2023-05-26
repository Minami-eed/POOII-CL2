using System.ComponentModel.DataAnnotations;

namespace POOII_CL2_QUISPE_EDSON.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipo { get; set; }
        public decimal? Precio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
    }
}

