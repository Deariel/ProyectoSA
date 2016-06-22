using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ConexionBanco
{
    public class Conexion
    {
        private string connection = "Data Source = DENNIS\\MSSQLSERVER2;Integrated Security = true; Initial Catalog = ENTIDAD_BANCO;";
        private SqlConnection connect;
        private SqlCommand command;
        private SqlDataAdapter da;
        private DataTable dt;
        private DataSet ds;

        public Conexion()
        {
            connect = new SqlConnection();
        }
        private SqlConnection connecttodb()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.ConnectionString = connection;
                    connect.Open();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return connect;
        }
        private void closeconnection()
        {
            if (connect.State != ConnectionState.Closed)
                connect.Close();
        }
        public string selectstring(string query)
        {
            string cadena = string.Empty;
            try
            {
                connecttodb();
                command = new SqlCommand(query, connect);
                cadena = command.ExecuteScalar().ToString();
            }
            catch
            {
                cadena = string.Empty;
            }
            finally
            {
                closeconnection();
            }
            return cadena;
        }

        public bool executecommand(string query)
        {
            bool exito;
            try
            {
                connecttodb();
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
                closeconnection();
            }
            return exito;
        }

        public bool ExecuteStoreProcedure(string namestoreprocedure)
        {
            try
            {
                connecttodb();
                command = new SqlCommand(namestoreprocedure, connect);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                closeconnection();
            }
        }

        public DataTable SelectDataTableFromStoreProcedure(string namestoreprocedure)
        {
            dt = new DataTable();
            try
            {
                connecttodb();
                command = new SqlCommand(namestoreprocedure, connect);//
                command.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                closeconnection();
            }
            return dt;
        }
        public DataTable SelectDataTable(string query)
        {
            dt = new DataTable();
            try
            {
                connecttodb();
                da = new SqlDataAdapter(query, connect);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                connecttodb();
            }
            return dt;
        }

        public DataSet SelectDataSet(string query, string table)
        {
            ds = new DataSet();
            try
            {
                connecttodb();
                da = new SqlDataAdapter(query, connect);
                da.Fill(ds, table);
            }
            catch //(Exception ex)
            {
                // ds = null;
            }
            finally
            {
                closeconnection();
            }
            return ds;
        }

    }
}
