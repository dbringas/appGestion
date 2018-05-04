using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Data.SqlClient; 
using System.Linq; 
using System.Text; 
using BE.Seguridad; 

namespace DA.Seguridad 
{ 
	public class menuDAO : ImenuDAO 
	{ 
		private SqlConnection _cadena_conexion; 

		public menuDAO(String cadena_conexion) 
		{ 
			_cadena_conexion = new SqlConnection(cadena_conexion); 
		}

		public List<Dictionary<String, Object>> getAll() 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spSEG_menuSEL", _cadena_conexion); 

				cmd.CommandType = CommandType.StoredProcedure; 

				_cadena_conexion.Open(); 

				List<Dictionary<String, Object>> lista = new List<Dictionary<String, Object>>(); 
				Dictionary<String, Object> fila; 

				SqlDataReader dr = cmd.ExecuteReader(); 

				while (dr.Read()) 
				{ 
					fila = new Dictionary<String, Object>(); 

					for (int i = 0; i < dr.FieldCount; i++) 
						fila.Add(dr.GetName(i), dr[i]); 

					lista.Add(fila); 
				} 

				dr.Close(); 

				return lista; 
			} 
			catch (Exception ex) 
			{ 
				throw new Exception(ex.Message); 
			} 
			finally 
			{ 
				_cadena_conexion.Close(); 
			} 
		} 

	} 
} 
