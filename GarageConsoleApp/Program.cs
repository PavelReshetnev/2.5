using System;
/*using System.Diagnostics;*/

namespace GarageConsoleApp
{
    /// <summary>
    /// Класс Program
    /// здесь описываем логику приложения
    /// вызываем нужные методы пишем обработчики и тд
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите нужный функционал...\n1 - Вывод и добавление водителей; 2 - Вывод и добавление прав водителей;\n" +
                              "3 - Вывод и добавление типов машин; 4 - Вывод и добавление машин;\n5 - Вывод и добавление маршрутов; 6 - Вывод и добавление рейсов\n");
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    DatabaseRequests.GetDriverQuery();
                    DatabaseRequests.AddDriverQuery("Иван", "Трошин", DateTime.Parse("2004.05.01"));
                    Console.WriteLine("Изменено...\n");
                    DatabaseRequests.GetDriverQuery();
                    break;
                case 2:
                    DatabaseRequests.GetDriverRightsCategoryQuery();
                    DatabaseRequests.AddDriverRightsCategoryQuery(4, 1);
                    Console.WriteLine("Изменено...\n");
                    DatabaseRequests.GetDriverRightsCategoryQuery();
                    break;
                case 3:
                    DatabaseRequests.GetTypeCarQuery();
                    DatabaseRequests.AddTypeCarQuery("Воздушный");
                    Console.WriteLine("Изменено...\n");
                    DatabaseRequests.GetTypeCarQuery();
                    break;
                case 4:
                    DatabaseRequests.GetCars();
                    DatabaseRequests.AddCar(3, "LADA Granta", "K900KX70", 4);
                    Console.WriteLine("Изменено...\n");
                    DatabaseRequests.GetCars();
                    break;
                case 5:
                    DatabaseRequests.GetItinerary();
                    DatabaseRequests.AddItinerary("Томск-Асино");
                    Console.WriteLine("Изменено...\n");
                    DatabaseRequests.GetItinerary();
                    break;
                case 6:
                    DatabaseRequests.GetRoutes();
                    DatabaseRequests.AddRoutes(4, 11, 12, 2);
                    Console.WriteLine("Изменено...\n");
                    DatabaseRequests.GetRoutes();
                    break;
            }
        }
    }
}


