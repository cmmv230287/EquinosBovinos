using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquinosBovinos.Data.Common
{
    public static class Config
    {
        /// <summary>
        /// devuelve el path del archivo donde estan almacenados los datos
        /// </summary>
        public static string BussinesFileName
        {
            get
            {
                return (ConfigurationManager.AppSettings["bussinesfilepath"] != null) ? ConfigurationManager.AppSettings["bussinesfilepath"] : "";
            }
        }
        /// <summary>
        /// devuleve el nombre del directorio donde se guardara el archivo de log
        /// </summary>
        public static string LogFilePath
        {
            get
            {
                return (ConfigurationManager.AppSettings["logfilepath"] != null) ? ConfigurationManager.AppSettings["logfilepath"] : "";
            }
        }
        /// <summary>
        /// devuelve el patron configurado con el cual se filtraran los Bovinos
        /// </summary>
        public static string PatternBovinos
        {
            get
            {
                return (ConfigurationManager.AppSettings["patternbovinos"] != null) ? ConfigurationManager.AppSettings["patternbovinos"] : "";
            }
        }
        /// <summary>
        /// devuelve el tipo de archivo con el que se va a procesar la informacion
        /// </summary>
        public static string ProviderData
        {
            get
            {
                return (ConfigurationManager.AppSettings["providerdata"] != null) ? ConfigurationManager.AppSettings["providerdata"] : "";
            }
        }
        /// <summary>
        /// devuelve el path y nombre del archivo de salida para los Equinos
        /// </summary>
        public static string EquinosOutPutFile
        {
            get
            {
                return (ConfigurationManager.AppSettings["equinosoutputfile"] != null) ? ConfigurationManager.AppSettings["equinosoutputfile"] : "";
            }
        }
        /// <summary>
        /// devuelve el path y nombre del archivo de salida para los Bovinos
        /// </summary>
        public static string BovinosOutPutFile
        {
            get
            {
                return (ConfigurationManager.AppSettings["bovinosoutputfile"] != null) ? ConfigurationManager.AppSettings["bovinosoutputfile"] : "";
            }
        }
        /// <summary>
        /// devuelve el nombre de los directorios que se deben crear en la raiz de la aplicacion
        /// </summary>
        public static string CreateFolders
        {
            get
            {
                return (ConfigurationManager.AppSettings["createfolders"] != null) ? ConfigurationManager.AppSettings["createfolders"] : "";
            }
        }
        /// <summary>
        /// devuelve el path raiz donde se ejecuta la aplicacion
        /// </summary>
        public static string RootPath { get { return AppDomain.CurrentDomain.BaseDirectory; } }
    }
}
