using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using DA.Empresa; 
using BE.Empresa; 

namespace BL.Empresa 
{ 
	public partial class BL_empresa 
	{ 
		private IDAOFactory _daoFactory; 
		private IempresaDAO _daoempresa; 

		public BL_empresa() 
		{ 
			_daoFactory = new DAOFactory(); 
			_daoempresa = _daoFactory.getempresaDAO(); 
		} 

		public String insertar(empresa empresa) 
		{ 
			return _daoempresa.insertar(empresa); 
		} 

		public void modificar(empresa empresa) 
		{ 
			_daoempresa.modificar(empresa); 
		} 

		public List<Dictionary<String, Object>> getById(empresa empresa) 
		{ 
			return _daoempresa.getById(empresa); 
		}
	} 
} 
