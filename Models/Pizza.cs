using System.Text.Json.Serialization;

namespace Pizzas.API.Models;

public class Pizza {
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public bool Vegetariana { get; set; }
    public int Precio { get; set; }
    public string Descripcion { get; set; } = "";

}