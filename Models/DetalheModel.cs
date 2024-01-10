namespace API.Models;

public class DetalheModel
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public int FinanciamentoProjectoId { get; set; }
    public FinanciamentoProjectoModel? FinanciamentoProjecto { get; set; }
}