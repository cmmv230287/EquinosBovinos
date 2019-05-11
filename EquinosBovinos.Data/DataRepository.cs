using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquinosBovinos.Data.Common;
namespace EquinosBovinos.Data
{
    public class DataRepository 
    {
        public DataRepository()
        {
            //se verifica la existencia de los directorios principales
            //en caso de que no exitan se crean
            Util.CreateFolders();
        }

        /// <summary>
        /// Devuelve una lista con los datos guardados en el repositorio configurado en 
        /// </summary>
        /// <returns></returns>
        public List<string> GetData()
        {
            List<string> _result = new List<string>();
            string _msg = "";
            try
            {
                string _path = $"{Config.RootPath}{Config.BussinesFileName}";

                if (!File.Exists(_path))
                {
                    _msg = $"El archivo de datos no existe: {_path}";
                    Log.WriteErrorLog(_msg);
                    throw new Exception(_msg);
                }
                _result = File.ReadAllLines($"{Config.RootPath}{Config.BussinesFileName}").ToList<string>();
            }
            catch (Exception ex)
            {
                Log.WriteErrorLog($"Error:{ex.Message}");
            }

            return _result;
        }
        /// <summary>
        /// Crea un archivo con la lista de animales en el archivo especificado 
        /// </summary>
        /// <param name="Animals">Lista de animales</param>
        /// <param name="OutPutfile">Archivo donde se debe guardar la lista de animales</param>
        /// <returns></returns>
        public bool SaveData(List<string> Animals, string OutPutfile)
        {
            bool _result = false;
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}{OutPutfile}";
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                File.WriteAllLines($"{AppDomain.CurrentDomain.BaseDirectory}{OutPutfile}", Animals.ToArray());
                _result = true;
            }
            catch (Exception ex)
            {
                _result = false;
                Log.WriteErrorLog($"Error:{ex.Message}");
                throw new Exception($"No se pudo guardar la informacion: {ex.Message}");
            }

            return _result;
        }
    }
}
