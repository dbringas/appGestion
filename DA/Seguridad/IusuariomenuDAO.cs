using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using BE.Seguridad; 

namespace DA.Seguridad 
{ 
	public interface IusuariomenuDAO 
	{ 
		String insertar(usuariomenu usuarioMenu); 
		List<Dictionary<String, Object>> getById(usuariomenu usuarioMenu); 
	} 
} 
