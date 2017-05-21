using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Configuration;
using System.Xml;

namespace UberFrba
{
    class conexionBase
    {
        // STRING DE CONEXIÓN

        public static string ObtenerStringConexion()
        {

            //Se carga el patch del archivo
            string filePath = @"../../App.config";

            // Se lee desde el archivo todo el contenido
            string str = File.ReadAllText(filePath);


            // Crea Instancia de XMLDOCUMENT
            XmlDocument archivoConfig = new XmlDocument();

            //Lo cargás como XML
            archivoConfig.LoadXml(str);

            // Se obtiene el nodo raíz
            XmlElement root = archivoConfig.DocumentElement;

            //Para obtener un nodo que está adentro del principal

            // String de conección
            XmlNode conectionString = root["conectionString"];


            //Para obtener el texto del elemento:
            string conexionDB = conectionString.InnerText;


            return conexionDB;
        }

        // FIN STRING DE CONEXIÓN

        public static DateTime ObtenerFecha()
        {
            //Se carga el patch del archivo
            string filePath = @"../../App.config";

            // Se lee desde el archivo todo el contenido
            string str = File.ReadAllText(filePath);

            // Crea Instancia de XMLDOCUMENT
            XmlDocument archivoConfig = new XmlDocument();
            //Lo cargás como XML
            archivoConfig.LoadXml(str);
            // Se obtiene el nodo raíz
            XmlElement root = archivoConfig.DocumentElement;
            // Fecha del sistema
            XmlNode fecha = root["fecha"];
            string fechaSistema = fecha.InnerText;
            //Para obtener el texto del atributo de un elemento:
            string formato = fecha.Attributes["formato"].InnerText;
            //Parsear fecha:
            DateTime fechaFormateada = DateTime.Parse(fechaSistema);
            return fechaFormateada;
        }

    }
}
