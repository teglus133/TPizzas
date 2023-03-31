using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

using Pizzas.API.Models;

namespace Pizzas.API.Utils {
    public static class BD {
        private static string _connectionString = @"Server=A-PHZ2-AMI-012;DataBase=BD.Pizzas;Trusted_Connection=True;";
        public static List<Pizza> GetAll() {
            string sqlQuery;
            List<Pizza> ListaPizzas;

            ListaPizzas = new List<Pizza>();
            using (SqlConnection db = new SqlConnection(_connectionString)) {
                sqlQuery = "SELECT * FROM Pizzas";
                ListaPizzas = db.Query<Pizza>(sqlQuery).ToList();
            }
            return ListaPizzas;
        }
        public static Pizza GetById(int id) {
            string sqlQuery;
            Pizza pizza;

            using (SqlConnection db = new SqlConnection(_connectionString)) {
                sqlQuery = "SELECT * FROM Pizzas WHERE Id = @idPizza";
                pizza = db.QueryFirstOrDefault<Pizza>(sqlQuery, new {idPizza = id});
            }
            return pizza;
        }
        public static int Insert(Pizza pizza) {
            string sqlQuery;
            int intRowsAffected = 0;

            using (SqlConnection db = new SqlConnection(_connectionString)) {
                sqlQuery = "INSERT INTO Pizzas (Nombre, Vegetariana, Precio, Descripcion) VALUES (@nombre, @vegetariana, @precio, @descripcion)";
                intRowsAffected = db.Execute(sqlQuery, new {nombre = pizza.Nombre, vegetariana = pizza.Vegetariana, precio = pizza.Precio, descripcion = pizza.Descripcion});
            }
            return intRowsAffected;
        }
        public static int UpdateById(Pizza pizza, int id) {
            string sqlQuery;
            int intRowsAffected = 0;

            using (SqlConnection db = new SqlConnection(_connectionString)) {
                sqlQuery = "UPDATE Pizzas SET Nombre = @nombre, Vegetariana = @vegetariana, Precio = @precio,  Descripcion = @descripcion WHERE id = @Id";
                intRowsAffected = db.Execute(sqlQuery, new {Id = id ,nombre = pizza.Nombre, vegetariana = pizza.Vegetariana, precio = pizza.Precio, descripcion = pizza.Descripcion});
            }
            return intRowsAffected;
        }
        public static int DeleteById(int id) {
            string sqlQuery;
            int intRowsAffected = 0;

            using (SqlConnection db = new SqlConnection(_connectionString)) {
                sqlQuery = "DELETE FROM Pizzas WHERE Id = @idPizza";
                intRowsAffected = db.Execute(sqlQuery, new {idPizza = id});
            }
            return intRowsAffected;
        }
    }
}