using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.OleDb;
using System.Data;
using JunoWebService.Models;

namespace JunoWebService.Controllers
{
    public class GETController : ApiController
    {           
        [HttpGet]
        [Route("Juno/Api/v1/BuscarDados/GetDeviceCode/{CodDispositivo}")]
        public string GetDeviceCode(string CodDispositivo)
        {
            string PRetorno = "";

            claLatLong objclaLatLong = new claLatLong();
            List<claLatLong> lstLatLong = objclaLatLong.CarregarDados(CodDispositivo);
            if (lstLatLong.Count > 0)
            {
                foreach (claLatLong objLstLatLong in lstLatLong)
                {
                    Importacao objImportacao = new Importacao();
                    List<Importacao> lstImportacao = objImportacao.CarregarDados(objLstLatLong.Latitude.ToString(), objLstLatLong.Longitude.ToString());
                    if (lstImportacao.Count > 0)
                    {
                        foreach (Importacao objLstImportacao in lstImportacao)
                        {
                            PRetorno += "Lat:" + objLstImportacao.Lat.ToString() + "," + "Long:" + objLstImportacao.Long.ToString() + "/";
                        }                       
                    }
                }                
            }
            else
            {
                PRetorno = "0";
            }
            return PRetorno;
        }

    
        [HttpGet]
        [Route("Juno/Api/v1/BuscarDados/IndiceFire/{ValorIndice}")]
        public string IndiceFire(double ValorIndice)
        {
            string PRetorno = "";

            Importacao objImportacao = new Importacao();
            List<Importacao> lstImportacao = objImportacao.CarregarDadosPorIndice(ValorIndice.ToString());
            if (lstImportacao.Count > 0)
            {
                foreach (Importacao objLstImportacao in lstImportacao)
                {
                    PRetorno += "Indice:" + objLstImportacao.Brilho.ToString() + "," + "Lat:" + objLstImportacao.Lat.ToString() + "," + "Long:" + objLstImportacao.Long.ToString() + "/";
                }
            }
            else
            {
                PRetorno = "0";
            }
            return PRetorno;
        }

    }
}
