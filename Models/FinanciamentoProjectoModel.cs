namespace API.Models;

public class FinanciamentoProjectoModel
{
    public int Id { get; set; }
    public string DataCriacao { get; set; }
    public string doacao { get; set; }
    
    public int TipoFinanciamentoId { get; set; }
    public TipoFinanciamentoModel? TipoFinanciamento { get; set; }

    public ICollection<DetalheModel>? Detalhes { get; set; }

    public int FinanciadorId { get; set; }
    public FinanciadorModel? Financiador { get; set; }

    public int ProjectoId { get; set; }
    public ProjectoModel? Projecto { get; set; }
}