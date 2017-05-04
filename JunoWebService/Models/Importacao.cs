using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace JunoWebService.Models
{
    public class Importacao
    {
        public int IdImportacao { get; set; }
        public string Long { get; set; }
        public string Lat { get; set; }
        public string Brilho { get; set; }

        public List<Importacao> CarregarDados(string Latitude, string Longitude)
        {
            string strSQL = "";
            strSQL = "SELECT IdImportacao, Long, Lat, Brilho ";
            strSQL = strSQL + "FROM Importacao ";
            strSQL = strSQL + "WHERE Long ='" + Longitude + "' ";
            strSQL = strSQL + "AND Lat ='" + Latitude + "' ";


            List<Importacao> ListaImportacao = new List<Importacao>();
            claConexoes Conexao = new claConexoes();
            OleDbDataReader Dados = Conexao.ExecutaSELECT(strSQL);
            while (Dados.Read())
            {
                Importacao objImportacao = new Importacao();
                objImportacao.IdImportacao = Convert.ToInt32(Dados["IdImportacao"]);
                objImportacao.Lat = Dados["Lat"].ToString();
                objImportacao.Long = Dados["Long"].ToString();
                objImportacao.Brilho = Dados["Brilho"].ToString();               
                ListaImportacao.Add(objImportacao);
            }
            Dados.Close();

            return ListaImportacao;
        }

        public List<Importacao> CarregarDadosPorIndice(string Indice)
        {
            string strSQL = "";
            strSQL = "SELECT IdImportacao, Long, Lat, Brilho ";
            strSQL = strSQL + "FROM Importacao ";
            strSQL = strSQL + "WHERE Brilho = '" + Indice  + "'";

            List<Importacao> ListaImportacao = new List<Importacao>();
            claConexoes Conexao = new claConexoes();
            OleDbDataReader Dados = Conexao.ExecutaSELECT(strSQL);
            while (Dados.Read())
            {
                Importacao objImportacao = new Importacao();
                objImportacao.IdImportacao = Convert.ToInt32(Dados["IdImportacao"]);
                objImportacao.Lat = Dados["Lat"].ToString();
                objImportacao.Long = Dados["Long"].ToString();
                objImportacao.Brilho = Dados["Brilho"].ToString();
                ListaImportacao.Add(objImportacao);
            }
            Dados.Close();

            return ListaImportacao;
        }





    }
}