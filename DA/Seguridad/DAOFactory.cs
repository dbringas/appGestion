using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Data.SqlClient; 
using System.Linq; 
using System.Text; 

namespace DA.Seguridad 
{ 
	public class DAOFactory : IDAOFactory 
	{ 
		private String cadena_conexion = @"Initial Catalog=SGA_PRW; Server=VIRTUAL-SQLSRV; User ID=sa; Password=proware12."; 

		public ImenuDAO getmenuDAO() 
		{ 
			return new menuDAO(cadena_conexion); 
		} 
		public IperfilDAO getperfilDAO() 
		{ 
			return new perfilDAO(cadena_conexion); 
		} 
		public IusuarioDAO getusuarioDAO() 
		{ 
			return new usuarioDAO(cadena_conexion); 
		} 
		public IusuariomenuDAO getusuarioMenuDAO() 
		{ 
			return new usuariomenuDAO(cadena_conexion); 
		} 
	} 
} 
