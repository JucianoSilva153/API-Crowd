using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace API.Models;

public class TipoProjectoModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    public ICollection<ProjectoModel>? Projectos { get; set; }
}