using System; 
using System.Collections.Generic; 
using System.Data; 
using System.Data.SqlClient; 
using System.Linq; 
using System.Text; 
using BE.Seguridad; 

namespace DA.Seguridad 
{ 
	public class usuarioDAO : IusuarioDAO 
	{ 
		private SqlConnection _cadena_conexion; 

		public usuarioDAO(String cadena_conexion) 
		{ 
			_cadena_conexion = new SqlConnection(cadena_conexion); 
		} 

		public String insertar(usuario BE) 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spSEG_usuarioINS", _cadena_conexion); 

				cmd.CommandType = CommandType.StoredProcedure; 

				cmd.Parameters.AddWithValue("@inCodEmpresa", BE.inCodEmpresa); 
				cmd.Parameters.AddWithValue("@inCodPerfil", BE.inCodPerfil); 
				cmd.Parameters.AddWithValue("@stNombre", BE.stNombre); 
				cmd.Parameters.AddWithValue("@stCorreo", BE.stCorreo); 
				cmd.Parameters.AddWithValue("@stClave", BE.stClave); 

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

		public void modificar(usuario BE) 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spSEG_usuarioUPD", _cadena_conexion); 

				cmd.CommandType = CommandType.StoredProcedure; 

				cmd.Parameters.AddWithValue("@inCodUsuario", BE.inCodUsuario); 
				cmd.Parameters.AddWithValue("@inCodEmpresa", BE.inCodEmpresa); 
				cmd.Parameters.AddWithValue("@inCodPerfil", BE.inCodPerfil); 
				cmd.Parameters.AddWithValue("@stNombre", BE.stNombre); 
				cmd.Parameters.AddWithValue("@stCorreo", BE.stCorreo);

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

        public void modificarClave(usuario BE)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spSEG_usuarioUPDclave", _cadena_conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@inCodUsuario", BE.inCodUsuario);
                cmd.Parameters.AddWithValue("@stClave", BE.stClave);

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

		public List<Dictionary<String, Object>> getById(usuario BE) 
		{ 
			try 
			{ 
				SqlCommand cmd = new SqlCommand("spSEG_usuarioSELBY", _cadena_conexion);

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
        
        public String getValidar(usuario BE)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spSEG_usuarioSELBYvalidar", _cadena_conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@stCorreo", BE.stCorreo);
                cmd.Parameters.AddWithValue("@stClave", BE.stClave);

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

        public void getActivar(usuario BE)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spSEG_usuarioUPDactivar", _cadena_conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@inCodUsuario", BE.inCodUsuario);

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
    } 
} 
