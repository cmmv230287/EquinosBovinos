using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquinosBovinos.Data.Common
{
    public static class Log
    {
        /// <summary>
        /// escribe el mensaje de error en el archivo de log
        /// </summary>
        /// <param name="content">contenido del error que sera guardado en el archivo de log</param>
        public static void WriteErrorLog(string content)
        {
            string _pathlog = AppDomain.CurrentDomain.BaseDirectory + "/log/";
            if (!Directory.Exists(_pathlog))
            {
                Directory.CreateDirectory(_pathlog);
            }
            FileStream stream = new FileStream(_pathlog + $"logmsg_{Config.LogFilePath}_{DateTime.Now.ToShortDateString().Replace("/", "")}.log", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(content);
            writer.Close();
        }
    }
}
