using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace ParcialCesanelli.Models
{
    public class SucursalModel
    {
        public int IdSucursal { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string? Direccion { get; set; }

        [Required(ErrorMessage = "El campo Ciudad es obligatorio")]
        public string? Ciudad { get; set; }

        [Required(ErrorMessage = "El campo Provincia es obligatorio")]
        public string? Provincia { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }
    }
}
