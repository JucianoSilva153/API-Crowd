namespace API.Models;

public class TipoFinanciamentoModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ICollection<FinanciamentoProjectoModel>? FinanciamentoProjecto { get; set; }
}