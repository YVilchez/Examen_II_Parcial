using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Datos
{
    public class DetalleTicketDB
    {
        string cadena = "server=localhost; user=root; database=soporte; password=1234;";
        public bool Insertar(DetalleTicket detalleTicket)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO producto VALUES ");
                sql.Append(" (@IdTicket, @TipoSoporte, @DescripcionSolicitud, @DescripcionRespuesta; ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@IdTicket", MySqlDbType.VarChar, 500).Value = detalleTicket.IdTicket;
                        comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 500).Value = detalleTicket.TipoSoporte;
                        comando.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 500).Value = detalleTicket.DescripcionSolicitud;
                        comando.Parameters.Add("@DescripcionRespuesta ", MySqlDbType.VarChar, 500).Value = detalleTicket.DescripcionRespuesta;

                        comando.ExecuteNonQuery();
                        inserto = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return inserto;
        }

        public bool Editar(DetalleTicket detalleTicket)
        {
            bool edito = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE producto SET ");
                sql.Append(" (@IdTicket, @TipoSoporte, @DescripcionSolicitud, @DescripcionRespuesta; ");
                sql.Append(" WHERE IdTicket = @IdTicket; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@IdTicket", MySqlDbType.VarChar, 500).Value = detalleTicket.IdTicket;
                        comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 500).Value = detalleTicket.TipoSoporte;
                        comando.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 500).Value = detalleTicket.DescripcionSolicitud;
                        comando.Parameters.Add("@DescripcionRespuesta ", MySqlDbType.VarChar, 500).Value = detalleTicket.DescripcionRespuesta;
                        comando.ExecuteNonQuery();
                        edito = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return edito;
        }

        public bool Eliminar(string IdTicket)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM producto ");
                sql.Append(" WHERE IdTicket = @IdTicket; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@IdTicket", MySqlDbType.VarChar, 500).Value = IdTicket;
                        comando.ExecuteNonQuery();
                        elimino = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return elimino;
        }

        public DataTable DevolverDetalleTicketDB()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM DetalleTicketDB ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return dt;
        }


        public DataTable DevolverDetalleTicketDBPorTipoSoporte(string TipoSoporte)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM DetalleTicketDB WHERE Descripcion LIKE '%" + TipoSoporte + "%'");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return dt;
        }

    }
}
