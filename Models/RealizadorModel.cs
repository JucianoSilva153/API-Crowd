namespace API.Models;

public class RealizadorModel
{
    public int Id { get; set; }
    public int ContaId { get; set; }
    public ContaModel Conta { get; set; }
    
    
    public ICollection<ProjectoModel>? Projectos { get; set; }
}