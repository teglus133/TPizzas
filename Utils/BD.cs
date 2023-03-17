using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

using Pizzas.API.Models;

namespace Pizzas.API.Utils {
    public static class BD {
        private static string CONNECTION_STRING = "@Persist Security Info=False;User ID=Pizzas;password=Pizzas;Initial Catalog=DAI-Pizzas;Data Source=.;";
        public static List<Pizza> GetAll() {
            string sqlQuery;
            List<Pizza> ListaPizzas;

            ListaPizzas = new List<Pizza>();
            using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {
                sqlQuery = "SELECT * FROM Pizzas";
                ListaPizzas = db.Query<Pizza>(sqlQuery).ToList();
            }
            return ListaPizzas;
        }
        public static Pizza GetById(int id) {
            string sqlQuery;
            Pizza pizza;

            using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {
                sqlQuery = "SELECT * FROM Pizzas WHERE Id = @idPizza";
                pizza = db.QueryFirstOrDefault<Pizza>(sqlQuery, new {idPizza = id});
            }
            return pizza;
        }
        public static int Insert(Pizza pizza) {
            string sqlQuery;
            int intRowsAffected = 0;

            using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {
                sqlQuery = "INSERT INTO Pizzas (Nombre, Vegetariana, Precio, Descripcion) VALUES (@nombre, @vegetariana, @precio, @descripcion";
                intRowsAffected = db.Execute(sqlQuery, new {nombre = pizza.Nombre, vegetariana = pizza.Vegetariana, precio = pizza.Precio, descripcion = pizza.Descripcion});
            }
            return intRowsAffected;
        }
        public static int UpdateById(Pizza pizza) {
            string sqlQuery;
            int intRowsAffected = 0;

            using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {
                sqlQuery = "UPDATE Pizzas SET Nombre = @nombre, Vegetariana = @vegetariana, Precio, @precio = Descripcion = @descripcion";
                intRowsAffected = db.Execute(sqlQuery, new {nombre = pizza.Nombre, vegetariana = pizza.Vegetariana, precio = pizza.Precio, descripcion = pizza.Descripcion});
            }
            return intRowsAffected;
        }
        public static int DeleteById(int id) {
            string sqlQuery;
            int intRowsAffected = 0;

            using (SqlConnection db = new SqlConnection(CONNECTION_STRING)) {
                sqlQuery = "DELETE FROM Pizzas WHERE Id = @idPizza";
                intRowsAffected = db.Execute(sqlQuery, new {idPizza = id});
            }
            return intRowsAffected;
        }
    }
}