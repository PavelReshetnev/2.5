using System;
using System.IO;
using Npgsql;

namespace GarageConsoleApp
{ 
    /// <summary>
/// Класс DatabaseRequests
/// содержит методы для отправки запросов к БД
/// </summary>
public static class DatabaseRequests
{
    
    /// <summary>
    /// Метод GetTypeCarQuery
    /// отправляет запрос в БД на получение списка типов машин
    /// выводит в консоль список типов машин
    /// </summary>
    public static void GetTypeCarQuery()
    {
        // Сохраняем в переменную запрос на получение всех данных и таблицы type_car
        var querySql = "SELECT * FROM type_car";
        // Создаем команду(запрос) cmd, передаем в нее запрос и соединение к БД
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        // Выполняем команду(запрос)
        // результат команды сохранится в переменную reader
        using var reader = cmd.ExecuteReader();
        
        // Выводим данные которые вернула БД
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]};\nНазвание: {reader[1]}");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Метод AddTypeCarQuery
    /// отправляет запрос в БД на добавление типа машины
    /// </summary>
    public static void AddTypeCarQuery(string name)
    {
        var querySql = $"INSERT INTO type_car(name) VALUES ('{name}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    public static void SaveTypeCarQuery()
    {
        string path = "TypeCar.txt";
        var querySql = "SELECT * FROM type_car";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            while (reader.Read())
            {
                writer.WriteLine($"Id: {reader[0]};\nНазвание: {reader[1]}\n");
            }
        }
    }
    
    /// <summary>
    /// Метод GetDriverQuery
    /// отправляет запрос в БД на получение списка водителей
    /// выводит в консоль данные о водителях
    /// </summary>
    public static void GetDriverQuery()
    {
        var querySql = "SELECT * FROM driver";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]};\nИмя: {reader[1]};\nФамилия: {reader[2]};\nДата рождения: {reader[3]}");
            Console.WriteLine();

        }
    }
    /// <summary>
    /// Метод AddDriverQuery
    /// отправляет запрос в БД на добавление водителей
    /// </summary>
    public static void AddDriverQuery(string firstName, string lastName, DateTime birthdate)
    {
        var querySql = $"INSERT INTO driver(first_name, last_name, birthdate) VALUES ('{firstName}', '{lastName}', '{birthdate}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    public static void SaveDriverQuery()
    {
        string path = "DriverQuery.txt";
        var querySql = "SELECT * FROM driver";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            while (reader.Read())
            {
                writer.WriteLine($"Id: {reader[0]};\nИмя: {reader[1]};\nФамилия: {reader[2]};\nДата рождения: {reader[3]}\n");
            }
        }
    }
    /// <summary>
    ///  Метод GetCars
    ///  Отправляет запрос в БД на получение списка автомобилей
    ///  Выводит в консоль данные о машинах
    /// </summary>
    public static void GetCars()
    {
        var querySql = "SELECT * FROM car";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]};\nТип: {reader[1]};\nМодель: {reader[2]};\nГос.Номер: {reader[3]};\nВместительность: {reader[4]}");
            Console.WriteLine();
        }
    }
    /// <summary>
    ///  Метод AddCar
    ///  отправляет запрос в БД на добавления новой машины
    /// </summary>
    public static void AddCar(int idtypecar, string name, string statenumber, int numberpassengers)
    {
        var querySql = $"INSERT INTO car(id_type_car, name, state_number, number_passengers) VALUES ('{idtypecar}', '{name}', '{statenumber}', '{numberpassengers}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
;   }

    public static void SaveCars()
    {
        string path = "Cars.txt";
        var querySql = "SELECT * FROM car";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            while (reader.Read())
            {
                writer.WriteLine($"Id: {reader[0]};\nТип: {reader[1]};\nМодель: {reader[2]};\nГос.Номер: {reader[3]};\nВместительность: {reader[4]}\n");
            }
        }
    }
    
    /// <summary>
    ///  Метод GetItinerary
    ///  Отправляет запрос в БД на получение списка маршрутов
    ///  Выводит в консоль все маршруты, которые имеются в БД
    /// </summary>
    public static void GetItinerary()
    {
        var querySql = "SELECT * FROM itinerary";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader[0]};\nМаршрут: {reader[1]}");
            Console.WriteLine();

        }
    }
    /// <summary>
    /// Метод AddItinerary
    /// Отправляет запрос в БД на добавление нового маршрута
    /// </summary>
    public static void AddItinerary(string name)
    {
        var querySql = $"INSERT INTO itinerary(name) VALUES ('{name}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    public static void SaveItinerary()
    {
        string path = "Itinerary.txt";
        var querySql = "SELECT * FROM itinerary";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            while (reader.Read())
            {
                writer.WriteLine($"Id: {reader[0]};\nМаршрут: {reader[1]}\n");
            }
        }
        
    }
    
    /// <summary>
    /// Метод AddRightsCategoryQuery
    /// отправляет запрос в БД на добавление категорий прав
    /// </summary>
    public static void AddRightsCategoryQuery(string name)
    {
        var querySql = $"INSERT INTO rights_category(name) VALUES ('{name}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }
    
    /// <summary>
    /// Метод GetDriverRightsCategoryQuery
    /// отправляет запрос в БД на получение категорий водителей
    /// выводит в консоль информацию о категориях прав водителей
    /// </summary>
    public static void GetDriverRightsCategoryQuery()
    {
        var querySql = "SELECT dr.first_name, dr.last_name, rc.name " +
                       "FROM driver_rights_category " +
                       "INNER JOIN driver dr on driver_rights_category.id_driver = dr.id " +
                       "INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category ";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"Имя: {reader[0]};\nФамилия: {reader[1]};\nКатегория прав: {reader[2]}");
            Console.WriteLine();

        }
    }
    
    /// <summary>
    /// Метод AddDriverRightsCategoryQuery
    /// отправляет запрос в БД на добавление категории прав водителю
    /// </summary>
    public static void AddDriverRightsCategoryQuery(int driver, int rightsCategory)
    {
        var querySql = $"INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES ({driver}, {rightsCategory})";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        cmd.ExecuteNonQuery();
    }

    public static void SaveDriverRightsCategoryQuery()
    {
        string path = @"C:\Users\gr623_repal\Desktop\output\DriverRightsCategoryQuery.txt";
        var querySql = "SELECT dr.first_name, dr.last_name, rc.name " +
                       "FROM driver_rights_category " +
                       "INNER JOIN driver dr on driver_rights_category.id_driver = dr.id " +
                       "INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category ";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            while (reader.Read())
            {
                writer.WriteLine($"Имя: {reader[0]};\nФамилия: {reader[1]};\nКатегория прав: {reader[2]}\n");
            }
        }
        
    }
    
    /// <summary>
    ///  Метод GetRoutes
    ///  Отправляет запрос в БД на получение существующих рейсов
    ///  Выводит в консоль данные о рейсах
    /// </summary>
    public static void GetRoutes()
    {
        var querySql =@"SELECT ity.name, cr.name, dr.first_name, dr.last_name
                        FROM route
                        INNER JOIN driver dr on route.id_driver = dr.id
                        INNER JOIN car cr on route.id_car = cr.id
                        INNER JOIN itinerary ity on route.id_itinerary = ity.id";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Console.WriteLine($"Маршрут: {reader[0]};\nМашина: {reader[1]};\nИмя Водителя: {reader[2]};\nФамилия Водителя: {reader[3]}");
            Console.WriteLine();
        }
    }
    /// <summary>
    /// Метод AddRoutes
    /// Отправляет запрос в БД на добавление нового рейса
    /// </summary>
    public static void AddRoutes(int driver, int car, int itinerary, int passengers)
    {
        var querySql = $"INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES ('{driver}', '{car}', '{itinerary}', '{passengers}')";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
    }

    public static void SaveRoutes()
    {
        string path = "Routes.txt";
        var querySql =@"SELECT ity.name, cr.name, dr.first_name, dr.last_name
                        FROM route
                        INNER JOIN driver dr on route.id_driver = dr.id
                        INNER JOIN car cr on route.id_car = cr.id
                        INNER JOIN itinerary ity on route.id_itinerary = ity.id";
        using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
        using var reader = cmd.ExecuteReader();
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            while (reader.Read())
            {
                writer.WriteLine($"Маршрут: {reader[0]};\nМашина: {reader[1]};\nИмя Водителя: {reader[2]};\nФамилия Водителя: {reader[3]}\n");
            }
        }

    }
}
}

