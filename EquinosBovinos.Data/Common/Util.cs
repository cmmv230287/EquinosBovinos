using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EquinosBovinos.Data.Common
{
    public static class Util
    {
        /// <summary>
        /// devuelve un lista de string segun el patron pasado por parametro
        /// </summary>
        /// <param name="List">Listado de animales</param>
        /// <param name="Pattern">patron configurado para devolver los bovinos</param>
        /// <returns></returns>
        public static List<string> FindOfList(List<string> List, string Pattern)
        {
            List<string> _result = new List<string>();
            try
            {
                var myRegex = new Regex(@"" + Config.PatternBovinos, RegexOptions.IgnoreCase);
                _result = List.Where(f => (Pattern == "") ? !myRegex.IsMatch(f) : myRegex.IsMatch(f)).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteErrorLog($"Error: {ex.Message}");
                throw new Exception(ex.Message);
            }

            return _result;
        }

        /// <summary>
        /// Se encarga de verificar y crear los directorios que deben estar en la raiz de la aplicacion
        /// </summary>
        public static void CreateFolders()
        {
            char[] _split = new char[] { ',' };

            List<string> _folders = Config.CreateFolders.Split(_split).ToList<string>();
            foreach (string _folder in _folders)
            {
                if (!Directory.Exists($"{Config.RootPath}/{_folder}"))
                {
                    Directory.CreateDirectory($"{Config.RootPath}/{_folder}");
                }
            }
        }
    }
}
