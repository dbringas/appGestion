using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 

namespace BE.Empresa 
{ 
	public partial class empresa 
	{ 
		public Int32 inCodEmpresa { get; set; } 
		public String stNumeroLegal { get; set; } 
		public String stNombreLegal { get; set; } 
		public String stAlias { get; set; } 
		public String imLogo { get; set; } 
		public Int32 inCodUsuarioRegistro { get; set; } 
		public Int32 inCodUsuarioUltimaEdicion { get; set; }
	} 
} 
