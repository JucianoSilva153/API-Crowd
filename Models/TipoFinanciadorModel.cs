namespace API.Models;

public class TipoFinanciadorModel
{
    public int Id { get; set; }
    public string Nome { get; set; }


    public ICollection<FinanciadorModel>? Financiadores { get; set; }
}