using API.Models;

namespace API.Repository;

public interface IProjectoServices
{
    Task<RequestResponse> RetornarProjectos();
    Task<RequestResponse> RetornarProjecto(int id);
    Task<RequestResponse> AdicionarNovoProjecto(ProjectoModel projecto);
    Task<RequestResponse> ApagarProjecto(int ProjectoId);
    Task<RequestResponse> AtualizarProjecto(ProjectoModel novoProjecto);
}

public interface ITiposProjectoServices
{
    Task<RequestResponse> NovoTipoProjecto(TipoProjectoModel tipo);
    Task<RequestResponse> ListarTiposProjecto();
    Task<RequestResponse> AtualizarTiposProjecto(TipoProjectoModel tipo);
    Task<RequestResponse> ApagarTipoProjecto(int tipoProjectoId);
}

public interface IDetalhesServices
{
    Task<RequestResponse> AdicionarDetalhe(DetalheModel detalhe);
    Task<RequestResponse> AtualizarDetalhes(DetalheModel detalhe);
    Task<RequestResponse> ListarDetalhes();
    Task<RequestResponse> ApagarDetalhe(int DetalheId);
}

public interface IFinanciadorServices
{
    Task<RequestResponse> AdicionarFinanciador(FinanciadorModel financiador);
    Task<RequestResponse> AtualizarFinanciador(FinanciadorModel financiador);
    Task<RequestResponse> ListarFinanciadores();
    Task<RequestResponse> ApagarFinanciador(int FinanciadorId);
}

public interface IFinanciamentoProjectoServices
{
    Task<RequestResponse> FinanciarProjecto(FinanciamentoProjectoModel financiamento);
    Task<RequestResponse> ApagarFinanciamento(int FinanciamentoId);
    Task<RequestResponse> AtualizarFinanciamento(FinanciamentoProjectoModel financiamento);
    Task<RequestResponse> ListarFinanciamentos();
    Task<RequestResponse> NumeroFinanciadoresProjecto(int IdProjecto);
    Task<RequestResponse> DiasRestantes(int IdProjecto);
    Task<RequestResponse> FundoTotal(int IdProjecto);

}

public interface ITipoFinanciadorServices
{
    Task<RequestResponse> NovoTipoFinanciador(TipoFinanciadorModel tipoFinanciador);
    Task<RequestResponse> AlterarTipoFinanciador(TipoFinanciadorModel tipoFinanciador);
    Task<RequestResponse> ListarTiposFinanciador();
    Task<RequestResponse> ApagarTipoFinanciador(int tipoFinanciadorId);
}

public interface ITipoFinanciamentoServices
{
    Task<RequestResponse> NovoTipoFinanciamento(TipoFinanciamentoModel tipoFinanciamento);
    Task<RequestResponse> AlterarTipoFinanemnto(TipoFinanciamentoModel tipoFinanciamento);
    Task<RequestResponse> ListarTiposFinamento();
    Task<RequestResponse> ApagarTipoFinamento(int tipoFinanciamentoId);
}

public interface IVerificacoesServices
{
    Task<RequestResponse> NovaVerificacao(VerificacaoModel verificacao);
    Task<RequestResponse> AlterarVerificao(VerificacaoModel verificacao);
    Task<RequestResponse> ListarVerificacoes();
    Task<RequestResponse> ApagarVerificacao(int verificacaoId);
}

public interface IContaServices
{
    public Task<RequestResponse> EntrarConta(string email, string password);
}

public interface IRealizadorServices
{
    Task<RequestResponse> AdicionarRealizador(RealizadorModel realizador);
}