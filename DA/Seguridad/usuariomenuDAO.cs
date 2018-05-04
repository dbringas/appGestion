using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Data.SqlClient; 
using System.Linq; 
using System.Text; 
using BE.Seguridad; 

namespace DA.Seguridad 
{ 
	public class usuariomenuDAO : IusuariomenuDAO 
	{ 
		private SqlConnection _cadena_conexion; 

		public usuariomenuDAO(String cadena_conexion) 
		{ 
			_cadena_conexion = new SqlConnection(cadena_conexion); 
		} 

		public String insertar(usuariomenu BE) 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spSEG_usuarioMenuINS", _cadena_conexion); 

				cmd.CommandType = CommandType.StoredProcedure; 

				cmd.Parameters.AddWithValue("@inCodUsuario", BE.inCodUsuario);

				_cadena_conexion.Open(); 

				String n = (String)cmd.ExecuteScalar(); 

				return n; 
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
        
		public List<Dictionary<String, Object>> getById(usuariomenu BE) 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spSEG_usuarioMenuSELBY", _cadena_conexion); 

				cmd.CommandType = CommandType.StoredProcedure; 

				cmd.Parameters.AddWithValue("@inCodUsuario", BE.inCodUsuario); 

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
