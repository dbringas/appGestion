using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 

namespace DA.Empresa 
{ 
	public interface IDAOFactory 
	{ 
		IempresaDAO getempresaDAO(); 
	} 
} 
