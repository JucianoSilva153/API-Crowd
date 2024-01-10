using System.Text.Json.Serialization;

namespace API.Models;

public class ProjectoModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string FundoPretendido  { get; set; }
    public string Descricao { get; set; }
    
    public string estadoFinanciamento { get; set; }
    public string dataMeta{get; set;}
    
    public int TipoProjectoId { get; set; }
    public TipoProjectoModel? TipoProjecto { get; set; }

    public int RealizadorId { get; set; }
    public RealizadorModel? Realizador { get; set; }
    
    public ICollection<VerificacaoModel>? Verificoes { get; set; }
    
    public ICollection<FinanciamentoProjectoModel>? Financiamentos { get; set; }
}