namespace API.Models;

public class FinanciadorModel
{
    public int Id { get; set; }
    public int ContaId { get; set; }
    public ContaModel Conta { get; set; }


    public int TipoFinanciadorId { get; set; }
    public TipoFinanciadorModel? TipoFinanciador { get; set; }

    public ICollection<FinanciamentoProjectoModel>? FinanciamentosProjecto { get; set; }
}