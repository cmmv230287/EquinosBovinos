using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EquinosBovinos.Bussines;
namespace EquinosBovinos.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Bussines.Bussines bussines = new Bussines.Bussines();
            if (bussines.HasAnimals)
            {
                bussines.classifyAnimals();
            }
            else
            {
                bussines.Notify.Message = "No existen datos disponibles";
                bussines.Notify.Type = Bussines.Enums.NotificationType.Alert;
            }


            Console.WriteLine("---------Informe---------");
            Console.WriteLine("-------------------------");
            
            switch (bussines.Notify.Type)
            {
                case Bussines.Enums.NotificationType.Error:
                    Console.WriteLine("Hubo problemas al momento de ejecutar el proceso:");
                    Console.WriteLine(bussines.Notify.Message);
                    break;
                case Bussines.Enums.NotificationType.Succes:
                    Console.WriteLine(bussines.Notify.Message);
                    break;
                case Bussines.Enums.NotificationType.Alert:
                    Console.WriteLine(bussines.Notify.Message);
                    break;
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Oprima cualquier tecla para salir");
            Console.Read();
        }
    }
}
