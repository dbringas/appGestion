using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Data.SqlClient; 
using System.Linq; 
using System.Text; 

namespace DA.Empresa 
{ 
	public class DAOFactory : IDAOFactory 
	{ 
		private String cadena_conexion = @"Initial Catalog=SGA_PRW; Server=VIRTUAL-SQLSRV; User ID=sa; Password=proware12."; 

		public IempresaDAO getempresaDAO() 
		{ 
			return new empresaDAO(cadena_conexion); 
		} 
	} 
} 
