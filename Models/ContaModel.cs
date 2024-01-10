namespace API.Models;

public class ContaModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Contacto { get; set; }
    public string Genero { get; set; }
    public string Ocupacao { get; set; }
    public string BilheteIdentidade { get; set; }

    public string password { get; set; }


    public int FinanciadorId { get; set; }
    public FinanciadorModel? Financiador { get; set; }

    public int RealizadorId { get; set; }
    public RealizadorModel? Realizador { get; set; }
}