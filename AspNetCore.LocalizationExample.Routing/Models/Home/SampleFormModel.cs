using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.LocalizationExample.Routing.Models.Home
{
	public class SampleFormModel
	{

		[Display(Name = "Nombre:")]
		[MinLength(3, ErrorMessage = "El nombre debe contener más de tres caracteres.")]
		[MaxLength(50, ErrorMessage = "El nombre debe contener, como máximo, cincuenta caracteres.")]
		[Required(ErrorMessage = "El nombre es obligatorio.")]
		public string Name { get; set; }


		[Display(Name = "Apellidos:")]
		[Required(ErrorMessage = "Los apellidos son obligatorios.")]
		[MinLength(3, ErrorMessage = "Los apellidos deben contener más de tres caracteres.")]
		[MaxLength(100, ErrorMessage = "Los apellidos deben contener, como máximo, cincuenta caracteres.")]
		public string Surname { get; set; }

		[Display(Name = "Dirección de correo electrónico:")]
		[Required(ErrorMessage = "La dirección de correo electrónico es obligatoria.")]
		[MinLength(8, ErrorMessage = "La dirección de correo electrónico debe contener más de ocho caracteres.")]
		[MaxLength(50, ErrorMessage = "La dirección de correo electrónico debe contener, como máximo, cincuenta caracteres.")]
		[DataType(DataType.EmailAddress, ErrorMessage = "El formato de la dirección de correo electrónico parece no ser válido. Por favor, revísalo.")]
		public string EmailAddress { get; set; }


		[Display(Name = "Confirma tu dirección de correo electrónico:")]
		[Required(ErrorMessage = "La confirmación de tu dirección de correo electrónico es obligatoria.")]
		[MinLength(8, ErrorMessage = "La confirmación de tu dirección de correo electrónico debe contener más de ocho caracteres.")]
		[MaxLength(50, ErrorMessage = "La confirmación de tu dirección de correo electrónico debe contener, como máximo, cincuenta caracteres.")]
		[DataType(DataType.EmailAddress, ErrorMessage = "El formato de la confirmación de tu dirección de correo electrónico parece no ser válido. Por favor, revísalo.")]
		[Compare("EmailAddress", ErrorMessage = "Las direcciones de correo electrónico no coinciden. Por favor, revísalas.")]
		public string ConfirmEmail { get; set; }



	}
}
