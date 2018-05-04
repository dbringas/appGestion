using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using DA.Seguridad; 
using BE.Seguridad; 

namespace BL.Seguridad 
{ 
	public partial class BL_perfil 
	{ 
		private IDAOFactory _daoFactory; 
		private IperfilDAO _daoperfil; 

		public BL_perfil() 
		{ 
			_daoFactory = new DAOFactory(); 
			_daoperfil = _daoFactory.getperfilDAO(); 
		}

		public List<Dictionary<String, Object>> getAll() 
		{ 
			return _daoperfil.getAll(); 
		} 
	} 
} 
