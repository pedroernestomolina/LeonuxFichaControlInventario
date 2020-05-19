using Provider.Infra;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Provider.Data
{

    public partial class DataProvider: IProvider
    {

        EntityConnectionStringBuilder _cn;
        string _Instancia;
        string _BaseDatos;
        string _Usuario;
        string _Password;


        public DataProvider() 
        {
        }

        public DTO.Resultado.Ficha Inicializa()
        {
            var result = new DTO.Resultado.Ficha();

            var r1 = CargarXml();
            if (r1.Result == DTO.Resultado.Enumerados.EnumResult.isError )
            {
                result.Mensaje = r1.Mensaje;
                result.Result = DTO.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            _Usuario = "root";
            _Password = "123";
            _cn = new EntityConnectionStringBuilder();
            _cn.Metadata = "res://*/ModelLeonux.csdl|res://*/ModelLeonux.ssdl|res://*/ModelLeonux.msl";
            _cn.Provider = "MySql.Data.MySqlClient";
            _cn.ProviderConnectionString = "data source=" + _Instancia + ";initial catalog=" + _BaseDatos + ";user id=" + _Usuario + ";Password=" + _Password + ";Convert Zero Datetime=True;";

            return result;
        }


        private DTO.Resultado.Ficha CargarXml()
        {
            var result = new DTO.Resultado.Ficha();

            try
            {
                var doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Conf.XML");

                if (doc.HasChildNodes)
                {
                    foreach (XmlNode nd in doc)
                    {
                        if (nd.LocalName.ToUpper().Trim() == "CONFIGURACION")
                        {
                            foreach (XmlNode nv in nd.ChildNodes)
                            {
                                if (nv.LocalName.ToUpper().Trim() == "SERVIDOR")
                                {
                                    foreach (XmlNode sv in nv.ChildNodes)
                                    {
                                        if (sv.LocalName.Trim().ToUpper() == "INSTANCIA")
                                        {
                                            _Instancia = sv.InnerText.Trim();
                                        }
                                        if (sv.LocalName.Trim().ToUpper() == "CATALOGO")
                                        {
                                            _BaseDatos = sv.InnerText.Trim();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Result =  DTO.Resultado.Enumerados.EnumResult.isError;
                result.Mensaje = e.Message;
            }

            return result;
        }

    }

}