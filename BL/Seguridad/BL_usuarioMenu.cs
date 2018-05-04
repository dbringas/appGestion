using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using DA.Seguridad; 
using BE.Seguridad; 

namespace BL.Seguridad 
{ 
	public partial class BL_usuarioMenu 
	{ 
		private IDAOFactory _daoFactory; 
		private IusuariomenuDAO _daousuarioMenu; 

		public BL_usuarioMenu() 
		{ 
			_daoFactory = new DAOFactory(); 
			_daousuarioMenu = _daoFactory.getusuarioMenuDAO(); 
		} 

		public String insertar(usuariomenu usuarioMenu) 
		{ 
			return _daousuarioMenu.insertar(usuarioMenu); 
		} 
        
		public List<Dictionary<String, Object>> getById(usuariomenu usuarioMenu) 
		{ 
			return _daousuarioMenu.getById(usuarioMenu); 
		} 
	} 
} 
