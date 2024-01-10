namespace API.Models;

public class VerificacaoModel
{
    public int Id { get; set; }
    public string Detalhes { get; set; }
    public string TipoVerificacao { get; set; }
    public bool Verificado { get; set; }

    public int ProjectId { get; set; }
    public ProjectoModel? Projecto { get; set; }
    
    public int FinanciamentoProjectoId { get; set; }
    public FinanciamentoProjectoModel? FinanciamentoProjecto { get; set; }
}