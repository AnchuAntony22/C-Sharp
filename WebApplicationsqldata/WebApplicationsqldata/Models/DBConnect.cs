using Dapper;
using MySql.Data.MySqlClient;
using static Mysqlx.Expect.Open.Types;

namespace WebApplicationsqldata.Models
{
    public class DBConnect
    {
        string connectionString = "server=localhost;database=car_data;password=1234;user=root";
        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            string sqlCars = "select * from car";
            using (var connction = new MySqlConnection(connectionString))
            {
                cars = connction.Query<Car>(sqlCars).ToList();
            };
            return cars;
        }
    }
}
