using EquinosBovinos.Bussines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquinosBovinos.Data;
using EquinosBovinos.Data.Common;
using System.Text.RegularExpressions;
using EquinosBovinos.Bussines.Enums;

namespace EquinosBovinos.Bussines
{
    public class Bussines
    {
        private List<string> Data { get; set; }
        public List<string> ListBovinos { get; set; }
        public List<string> ListEquinos { get; set; }

        public bool HasAnimals { get; set; }

        private DataRepository Repository { get; set; }

        public Bussines()
        {
            Notify = new Notification();
            GetAnimalsFromRepository();
        }

        public Notification Notify { get; set; }
        /// <summary>
        /// Devuelve todos los animales del repositorio
        /// </summary>
        private void GetAnimalsFromRepository()
        {
            try
            {
                Repository = new DataRepository();
                Data = Repository.GetData();

                HasAnimals = (Data.Count > 0) ? true : false;
            }
            catch (Exception ex)
            {
                Log.WriteErrorLog($"Error: {ex.Message}");
                throw new Exception($"Error al momento de traer los datos del repositorio: {ex.Message}");
            }
        }
        /// <summary>
        /// Se encarga de identificar los animales segun el patron configurado en el setting patternbovinos
        /// </summary>
        /// <param name="Types">tipo del animal</param>
        /// <returns>devuelve la lista de animales segun el patron configurado</returns>
        private List<string> IdentifyAnimals(AnimalTypes Types)
        {
            List<string> _result = new List<string>();
            try
            {                
               _result = Util.FindOfList(Data, (Types == AnimalTypes.Bovinos) ? Config.PatternBovinos : "");
            }
            catch (Exception ex)
            {
                Log.WriteErrorLog($"Error al identificar el tipo de animal: {ex.Message}");
                throw new Exception(ex.Message);
            }
            return _result;
        }
        /// <summary>
        /// Se encarga de clasificar los animales por tipos
        /// </summary>
        /// <returns>devuelve el objeto notificacion con el mensaje y el tipo de mensaje</returns>
        public Notification classifyAnimals()
        {
            try
            {
                ListBovinos = IdentifyAnimals(AnimalTypes.Bovinos);
                ListEquinos = IdentifyAnimals(AnimalTypes.Equinos);

                Repository.SaveData(ListBovinos, Config.BovinosOutPutFile);
                Repository.SaveData(ListEquinos, Config.EquinosOutPutFile);
                Notify.Message = "Los animales han sido clasificados de manera exitosa";
                Notify.Type = NotificationType.Succes;
            }
            catch (Exception ex)
            {
                Notify.Message = $"Error al cladificar los animales por tipos: {ex.Message}";
                Notify.Type = NotificationType.Error;
                Log.WriteErrorLog(Notify.Message);                
            }

            return Notify;
        }
    }
}
