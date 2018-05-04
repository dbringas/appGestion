using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Data.SqlClient; 
using System.Linq; 
using System.Text; 
using BE.Empresa; 

namespace DA.Empresa 
{ 
	public class empresaDAO : IempresaDAO 
	{ 
		private SqlConnection _cadena_conexion; 

		public empresaDAO(String cadena_conexion) 
		{ 
			_cadena_conexion = new SqlConnection(cadena_conexion); 
		} 

		public String insertar(empresa BE) 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spEMP_empresaINS", _cadena_conexion); 

				cmd.CommandType = CommandType.StoredProcedure; 

				cmd.Parameters.AddWithValue("@stNumeroLegal", BE.stNumeroLegal); 
				cmd.Parameters.AddWithValue("@stNombreLegal", BE.stNombreLegal);    
				cmd.Parameters.AddWithValue("@inCodUsuarioRegistro", BE.inCodUsuarioRegistro);

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

		public void modificar(empresa BE) 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spEMP_empresaUPD", _cadena_conexion); 

				cmd.CommandType = CommandType.StoredProcedure; 

				cmd.Parameters.AddWithValue("@inCodEmpresa", BE.inCodEmpresa); 
				cmd.Parameters.AddWithValue("@stNumeroLegal", BE.stNumeroLegal); 
				cmd.Parameters.AddWithValue("@stNombreLegal", BE.stNombreLegal); 
				cmd.Parameters.AddWithValue("@stAlias", BE.stAlias); 
				cmd.Parameters.AddWithValue("@imLogo", BE.imLogo);
				cmd.Parameters.AddWithValue("@inCodUsuarioUltimaEdicion", BE.inCodUsuarioUltimaEdicion); 

				_cadena_conexion.Open(); 

				cmd.ExecuteNonQuery(); 
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

		public List<Dictionary<String, Object>> getById(empresa BE) 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spEMP_empresaSELBY", _cadena_conexion); 

				cmd.CommandType = CommandType.StoredProcedure; 

				cmd.Parameters.AddWithValue("@inCodEmpresa", BE.inCodEmpresa); 

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
