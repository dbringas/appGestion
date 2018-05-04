using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using DA.Seguridad; 
using BE.Seguridad; 

namespace BL.Seguridad 
{ 
	public partial class BL_menu 
	{ 
		private IDAOFactory _daoFactory; 
		private ImenuDAO _daomenu; 

		public BL_menu() 
		{ 
			_daoFactory = new DAOFactory(); 
			_daomenu = _daoFactory.getmenuDAO(); 
		}

		public List<Dictionary<String, Object>> getAll() 
		{ 
			return _daomenu.getAll(); 
		} 
	} 
} 
