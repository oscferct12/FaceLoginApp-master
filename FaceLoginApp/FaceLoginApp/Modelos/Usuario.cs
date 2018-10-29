using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaceLoginApp.Modelos
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int Id { get; set; }
        public string Key { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string EmocionActual { get; set; }
        public float ScoreActual { get; set; }
        public string FotoActual { get; set; }

        public string MensajeBienvenida
        {
            get
            {
                return $"Bienvenido {Nombre},"+
                       $"tu emoción actual es {EmocionActual}"+
                       $"(,"+ $"porcentaje de coincidencia del rostro : {ScoreActual * 100} %)";
            }
        }
    }
}
