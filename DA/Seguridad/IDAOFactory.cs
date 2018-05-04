using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 

namespace DA.Seguridad 
{ 
	public interface IDAOFactory 
	{ 
		ImenuDAO getmenuDAO(); 
		IperfilDAO getperfilDAO(); 
		IusuarioDAO getusuarioDAO(); 
		IusuariomenuDAO getusuarioMenuDAO(); 
	} 
} 
