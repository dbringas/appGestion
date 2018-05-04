using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using BE.Seguridad; 

namespace DA.Seguridad 
{ 
	public interface ImenuDAO 
	{ 
		List<Dictionary<String, Object>> getAll(); 
	} 
} 
