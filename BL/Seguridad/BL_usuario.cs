using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Linq; 
using System.Text; 
using DA.Seguridad; 
using BE.Seguridad; 

namespace BL.Seguridad 
{ 
	public partial class BL_usuario 
	{ 
		private IDAOFactory _daoFactory; 
		private IusuarioDAO _daousuario; 

		public BL_usuario() 
		{ 
			_daoFactory = new DAOFactory(); 
			_daousuario = _daoFactory.getusuarioDAO(); 
		} 

		public String insertar(usuario usuario) 
		{ 
			return _daousuario.insertar(usuario);
        }

        public void modificar(usuario usuario)
        {
            _daousuario.modificar(usuario);
        }

        public void modificarClave(usuario usuario)
        {
            _daousuario.modificarClave(usuario);
        }

		public List<Dictionary<String, Object>> getById(usuario usuario) 
		{ 
			return _daousuario.getById(usuario); 
		} 

        public String getValidar(usuario usuario)
        {
            return _daousuario.getValidar(usuario);
        }

        public void getActivar(usuario usuario)
        {
            _daousuario.getActivar(usuario);
        }
    } 
} 
