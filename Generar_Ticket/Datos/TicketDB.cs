﻿using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class TicketDB
    {
        string cadena = "server=localhost; user=root; database=soporte; password=1234;";

        public bool Guardar(Ticket ticket, List<DetalleTicket> detalles)
        {
            bool inserto = false;
            int idTicket = 0;
            try
            {
                StringBuilder sqlTicket = new StringBuilder();
                sqlTicket.Append("INSERT INTO ticket (Fecha, IdCliente, CodigoUsuario, ISV, Descuento, SubTotal, Total) VALUES (@Fecha, @IdCliente, @CodigoUsuario, @ISV, @Descuento, @SubTotal, @Total); ");
                sqlTicket.Append(" SELECT LAST_INSERT_ID(); ");

                StringBuilder sqlDetalle = new StringBuilder();
                sqlDetalle.Append(" INSERT INTO detalleticket (IdTicket, TipoSoporte, DescripcionSolicitud, DescripcionRespuesta) VALUES (@IdTicket, @TipoSoporte, @DescripcionSolicitud, @DescripcionRespuesta); ");


                using (MySqlConnection con = new MySqlConnection(cadena))
                {
                    con.Open();

                    MySqlTransaction transaction = con.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    try
                    {

                        using (MySqlCommand cmd1 = new MySqlCommand(sqlTicket.ToString(), con, transaction))
                        {
                            cmd1.CommandType = System.Data.CommandType.Text;
                            cmd1.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = ticket.Fecha;
                            cmd1.Parameters.Add("@IdCliente", MySqlDbType.VarChar, 25).Value = ticket.IdCliente;
                            cmd1.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 50).Value = ticket.CodigoUsuario;
                            cmd1.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = ticket.ISV;
                            cmd1.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = ticket.Descuento;
                            cmd1.Parameters.Add("@SubTotal", MySqlDbType.Decimal).Value = ticket.SubTotal;
                            cmd1.Parameters.Add("@Total", MySqlDbType.Decimal).Value = ticket.Total;
                            idTicket = Convert.ToInt32(cmd1.ExecuteScalar());
                        }

                        foreach (DetalleTicket detalle in detalles)
                        {
                            using (MySqlCommand cmd2 = new MySqlCommand(sqlDetalle.ToString(), con, transaction))
                            {

                                cmd2.CommandType = System.Data.CommandType.Text;
                                cmd2.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 500).Value = detalle.TipoSoporte;
                                cmd2.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 500).Value = detalle.DescripcionSolicitud;
                                cmd2.Parameters.Add("@DescripcionRespuesta", MySqlDbType.VarChar, 500).Value = detalle.DescripcionRespuesta;
                                idTicket = Convert.ToInt32(cmd2.ExecuteScalar());

                            }
                        }
                        transaction.Commit();
                        inserto = true;

                    }

                    catch (System.Exception)
                    {
                        inserto = false;
                        transaction.Rollback();
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return inserto;
        }


    }
}