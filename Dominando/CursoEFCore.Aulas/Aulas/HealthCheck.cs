using System;
using CursoEFCore.Aulas.Data;

namespace CursoEFCore.Aulas.Aulas
{
    public class HealthCheck
    {
        public static void DatabaseHealthCheck()
        {
            using var db = new ApplicationContext();
            var canConnect = db.Database.CanConnect();

            if (canConnect)
            {
                Console.WriteLine("Connection is up!");
            }
            else
            {
                Console.WriteLine("Connection is down!");
            }
        }
    }
}