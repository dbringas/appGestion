using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using BE.Seguridad; 

namespace DA.Seguridad 
{ 
	public interface IusuarioDAO 
	{ 
		String insertar(usuario usuario);
        void modificar(usuario usuario);
        void modificarClave(usuario usuario);
		List<Dictionary<String, Object>> getById(usuario usuario);
        String getValidar(usuario usuario);
        void getActivar(usuario usuario);

    } 
} 
