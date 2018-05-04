using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 

namespace BE.Seguridad 
{ 
	public partial class usuario 
	{ 
		public Int32 inCodUsuario { get; set; } 
		public Int32 inCodEmpresa { get; set; } 
		public Int32 inCodPerfil { get; set; } 
		public String stNombre { get; set; } 
		public String stCorreo { get; set; }
        public String stClave { get; set; }
        public String stActivado { get; set; }
    } 
} 
