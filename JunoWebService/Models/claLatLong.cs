using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace JunoWebService.Models
{

    public class claLatLong
    {
        public int IdDispositivo { get; set; }
        public int CodDispositivo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }

        public string Retorno;


        public List<claLatLong> CarregarDados(string inCodDispositivo)
        {
            string strSQL = "";
            strSQL = "SELECT IdDispositivo, CodDispositivo, Latitude, Longitude, Data, Hora ";
            strSQL = strSQL + "FROM Juno ";
            strSQL = strSQL + "WHERE CodDispositivo ='" + inCodDispositivo + "' ";


            List<claLatLong> ListaDispositivos = new List<claLatLong>();
            claConexoes Conexao = new claConexoes();
            OleDbDataReader Dados = Conexao.ExecutaSELECT(strSQL);
            while (Dados.Read())
            {
                claLatLong objLatlong = new claLatLong();
                objLatlong.IdDispositivo = Convert.ToInt32(Dados["IdDispositivo"]);
                objLatlong.CodDispositivo = Convert.ToInt32(Dados["CodDispositivo"]);
                objLatlong.Latitude = Dados["Latitude"].ToString();
                objLatlong.Longitude = Dados["Longitude"].ToString();
                objLatlong.Data = Dados["Data"].ToString();
                objLatlong.Hora = Dados["Hora"].ToString();
                ListaDispositivos.Add(objLatlong);
            }
            Dados.Close();

            return ListaDispositivos;
        }

        public void GravarDevice(string CodDevice, string Latitude, string Longitude)
        {
            string strSQL = "INSERT INTO table_name (CodDispositivo, Latitude,Longitude)";
            strSQL += "VALUES(" + Convert.ToInt32(CodDevice) + ", " + Latitude.ToString() + "," + Latitude.ToString() + ")";

            claConexoes objConexoes = new claConexoes();
            objConexoes.ExecutaComando(strSQL);
        }
    }
}