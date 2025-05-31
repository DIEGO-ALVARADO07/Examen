using System.ComponentModel.DataAnnotations;

namespace Entity.Enum
{
    public enum TypeMovement
    {
        [Display(Name = "Entrada de productos")]
        Entrada = 1,

        [Display(Name = "Salida de productos")]
        Salida = 2,

        [Display(Name = "Actualización de productos")]
        Actualizacion = 3,
    }
}
