using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using BE.Empresa; 

namespace DA.Empresa 
{ 
	public interface IempresaDAO 
	{ 
		String insertar(empresa empresa); 
		void modificar(empresa empresa); 
		List<Dictionary<String, Object>> getById(empresa empresa); 
	} 
} 
