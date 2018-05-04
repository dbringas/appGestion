using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webApp.Models
{
    public class LoginViewModels
    {
        [Required]
        //[EmailAddress]
        [Display(Name = "Cuenta de correo")]
        public String correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public String clave { get; set; }

        [Display(Name = "¿Recordar credenciales?")]
        public Boolean recordar { get; set; }
    }

    public class RegistroViewModels
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public String nombre { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public String empresa { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Cuenta de correo")]
        public String correo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Confirmar cuenta de correo")]
        public String confirmarCorreo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public String clave { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        public String confirmarClave { get; set; }
    }
}