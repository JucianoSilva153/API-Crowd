using System.Globalization;
using API.Entities;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Repository;

public class Projectos : IProjectoServices
{
    private readonly BdContext _context;

    public Projectos(BdContext context)
    {
        _context = context;
    }

    public async Task<RequestResponse> RetornarProjecto(int id)
    {
        ProjectoModel? projecto;

        try
        {
            projecto = await _context.Projetos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (projecto == null)
                return new RequestResponse()
                {
                    Mensagem = "Nenhum Projecto Encontrado",
                    Sucesso = false
                };
        }
        catch (System.Exception e)
        {
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Projecto Retornado com Sucesso",
            Sucesso = true,
            Target = projecto
        };
    }

    public async Task<RequestResponse> RetornarProjectos()
    {
        List<ProjectoModel> listProjectos = new List<ProjectoModel>();
        try
        {
            listProjectos = await _context.Projetos.AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Projectos Listados Com sucesso",
            Sucesso = true,
            Target = listProjectos
        };
    }

    public async Task<RequestResponse> AdicionarNovoProjecto(ProjectoModel projecto)
    {
        try
        {
            await _context.Projetos.AddAsync(projecto);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Projecto Adicionado Com Sucesso!!",
            Sucesso = true,
            Target = projecto
        };
    }

    public async Task<RequestResponse> ApagarProjecto(int ProjectoId)
    {
        try
        {
            var projetoARemover = await _context
                .Projetos.AsNoTracking()
                .FirstAsync(p => p.Id == ProjectoId);

            _context.Projetos.Remove(projetoARemover);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse { Mensagem = "Projecto Removido com sucesso!", Sucesso = true };
    }

    public async Task<RequestResponse> AtualizarProjecto(ProjectoModel novoProjecto)
    {
        try
        {
            _context.Projetos.Update(
                new ProjectoModel
                {
                    Id = novoProjecto.Id,
                    Verificoes = novoProjecto.Verificoes,
                    TipoProjecto = novoProjecto.TipoProjecto,
                    TipoProjectoId = novoProjecto.TipoProjectoId
                }
            );

            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Projecto Alterado com Sucesso",
            Sucesso = true,
            Target = novoProjecto
        };
    }
}

public class TiposProjectos : ITiposProjectoServices
{
    private readonly BdContext context;

    public TiposProjectos(BdContext _context)
    {
        context = _context;
    }

    public async Task<RequestResponse> NovoTipoProjecto(TipoProjectoModel tipo)
    {
        try
        {
            await context.TiposProjecto.AddAsync(tipo);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Novo Projecto Adicionado com Sucesso",
            Sucesso = true,
            Target = tipo
        };
    }

    public async Task<RequestResponse> ListarTiposProjecto()
    {
        var listaTipoProjecto = new List<TipoProjectoModel>();
        try
        {
            listaTipoProjecto = await context.TiposProjecto.AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Tipos de Projeto listado com sucesso!!",
            Sucesso = true,
            Target = listaTipoProjecto
        };
    }

    public async Task<RequestResponse> ApagarTipoProjecto(int tipoProjectoId)
    {
        try
        {
            var tipoApagar = await context
                .TiposProjecto.AsNoTracking()
                .FirstAsync(p => p.Id == tipoProjectoId);

            context.TiposProjecto.Remove(tipoApagar);

            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Tipo de projecto apagado com sucesso!!",
            Sucesso = true
        };
    }

    public async Task<RequestResponse> AtualizarTiposProjecto(TipoProjectoModel tipo)
    {
        try
        {
            context.TiposProjecto.Update(
                new TipoProjectoModel { Id = tipo.Id, Projectos = tipo.Projectos }
            );

            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Tipo de Projecto Atualizado com sucesso",
            Sucesso = true,
            Target = tipo
        };
    }
}

public class Detalhes : IDetalhesServices
{
    private readonly BdContext context;

    public Detalhes(BdContext _context)
    {
        context = _context;
    }

    public async Task<RequestResponse> AdicionarDetalhe(DetalheModel detalhe)
    {
        try
        {
            await context.Detalhes.AddAsync(detalhe);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Sucesso",
            Sucesso = true,
            Target = detalhe
        };
    }

    public Task<RequestResponse> ListarDetalhes()
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> ApagarDetalhe(int DetalheId)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> AtualizarDetalhes(DetalheModel detalhe)
    {
        throw new NotImplementedException();
    }
}

public class Contas : IContaServices
{
    private readonly BdContext context;

    public Contas(BdContext _context)
    {
        context = _context;
    }

    public async Task<RequestResponse> EntrarConta(string email, string password)
    {
        var conta = new ContaModel();
        try
        {
            conta = await context
                .Contas.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email && c.password == password);

            if (conta == null)
                return new RequestResponse { Mensagem = "Conta nao existe", Sucesso = false };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Conto retornada com Sucesso",
            Target = conta,
            Sucesso = true
        };
    }
}

public class Realizadores : IRealizadorServices
{
    private readonly BdContext context;

    public Realizadores(BdContext _context)
    {
        context = _context;
    }

    public async Task<RequestResponse> AdicionarRealizador(RealizadorModel realizador)
    {
        try
        {
            var novaConta = await context.Contas.AddAsync(realizador.Conta);
            await context.SaveChangesAsync();

            var novoRealizador = await context.Realizadores.AddAsync(
                new RealizadorModel { Conta = novaConta.Entity, ContaId = novaConta.Entity.Id }
            );
            await context.SaveChangesAsync();

            novaConta.Entity.RealizadorId = novoRealizador.Entity.Id;
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse { Mensagem = "Sucesso", Sucesso = true };
    }
}

public class TiposFinanciadores : ITipoFinanciadorServices
{
    private readonly BdContext context;

    public TiposFinanciadores(BdContext _context)
    {
        context = _context;
    }

    public async Task<RequestResponse> NovoTipoFinanciador(TipoFinanciadorModel tipoFinanciador)
    {
        try
        {
            await context.TiposFinanciador.AddAsync(tipoFinanciador);

            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse { Mensagem = "Sucesso", Sucesso = true };
    }

    public Task<RequestResponse> AlterarTipoFinanciador(TipoFinanciadorModel tipoFinanciador)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> ApagarTipoFinanciador(int tipoFinanciadorId)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> ListarTiposFinanciador()
    {
        throw new NotImplementedException();
    }
}

public class Financiadores : IFinanciadorServices
{
    private readonly BdContext context;

    public Financiadores(BdContext _context)
    {
        context = _context;
    }

    public async Task<RequestResponse> AdicionarFinanciador(FinanciadorModel financiador)
    {
        try
        {
            var novaConta = await context.Contas.AddAsync(financiador.Conta);
            await context.SaveChangesAsync();

            var novoFinanciador = await context.Financiadores.AddAsync(
                new FinanciadorModel
                {
                    TipoFinanciadorId = financiador.TipoFinanciadorId,
                    ContaId = novaConta.Entity.Id,
                    Conta = novaConta.Entity
                }
            );
            await context.SaveChangesAsync();

            novaConta.Entity.FinanciadorId = novoFinanciador.Entity.Id;
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse { Mensagem = "Sucesso", Sucesso = true };
    }

    public Task<RequestResponse> ListarFinanciadores()
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> ApagarFinanciador(int FinanciadorId)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> AtualizarFinanciador(FinanciadorModel financiador)
    {
        throw new NotImplementedException();
    }
}

public class TiposFinanciamentos : ITipoFinanciamentoServices
{
    private readonly BdContext context;

    public TiposFinanciamentos(BdContext _context)
    {
        context = _context;
    }

    public async Task<RequestResponse> NovoTipoFinanciamento(
        TipoFinanciamentoModel tipoFinanciamento
    )
    {
        try
        {
            await context.TiposFinanciamento.AddAsync(tipoFinanciamento);

            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Sucesso",
            Sucesso = true,
            Target = tipoFinanciamento
        };
    }

    public Task<RequestResponse> AlterarTipoFinanemnto(TipoFinanciamentoModel tipoFinanciamento)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> ApagarTipoFinamento(int tipoFinanciamentoId)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> ListarTiposFinamento()
    {
        throw new NotImplementedException();
    }
}

public class Verificacoes : IVerificacoesServices
{
    private readonly BdContext context;

    public Verificacoes(BdContext _context)
    {
        context = _context;
    }

    public Task<RequestResponse> NovaVerificacao(VerificacaoModel verificacao)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> AlterarVerificao(VerificacaoModel verificacao)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> ApagarVerificacao(int verificacaoId)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> ListarVerificacoes()
    {
        throw new NotImplementedException();
    }
}

public class Financiamentos : IFinanciamentoProjectoServices
{
    private readonly BdContext context;

    public Financiamentos(BdContext _context)
    {
        context = _context;
    }

    public Task<RequestResponse> ApagarFinanciamento(int FinanciamentoId)
    {
        throw new NotImplementedException();
    }

    public Task<RequestResponse> AtualizarFinanciamento(FinanciamentoProjectoModel financiamento)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> FinanciarProjecto(FinanciamentoProjectoModel financiamento)
    {
        try
        {
            var projecto = await context.Projetos.FirstOrDefaultAsync(
                p => p.Id == financiamento.ProjectoId
            );

            var fundoTotal = (int)(await FundoTotal(projecto.Id)).Target;

            if (fundoTotal != int.Parse(projecto.FundoPretendido))
            {
                await context.FinanciamentosProjecto.AddAsync(
                    new FinanciamentoProjectoModel
                    {
                        TipoFinanciamentoId = financiamento.TipoFinanciamentoId,
                        FinanciadorId = financiamento.FinanciadorId,
                        ProjectoId = financiamento.ProjectoId,
                        doacao = financiamento.doacao,
                        DataCriacao = financiamento.DataCriacao,
                    }
                );
                projecto.estadoFinanciamento = "Em Andamento";
                context.Projetos.Update(projecto);

                await context.SaveChangesAsync();
            }
            else
            {
                projecto.estadoFinanciamento = "Terminado";
                context.Projetos.Update(projecto);

                await context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse { Mensagem = "Sucesso", Sucesso = true };
    }

    public Task<RequestResponse> ListarFinanciamentos()
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> NumeroFinanciadoresProjecto(int IdProjecto)
    {
        List<FinanciadorModel> financiadores = new List<FinanciadorModel>();

        try
        {
            var financiamentos = await context
                .FinanciamentosProjecto.Where(c => c.ProjectoId == IdProjecto)
                .ToListAsync();

            if (financiamentos == null)
                return new RequestResponse
                {
                    Mensagem = "Financiadores para este projecto nao Encontrados",
                    Sucesso = false
                };

            foreach (var financiamento in financiamentos)
            {
                var financiador = await context
                    .Financiadores.Where(f => f.Id == financiamento.FinanciadorId)
                    .FirstAsync();

                financiadores.Add(financiador);
            }
        }
        catch (System.Exception e)
        {
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Financiadores Retornados com Sucesso",
            Sucesso = true,
            Target = financiadores.Count
        };
    }

    public async Task<RequestResponse> DiasRestantes(int IdProjecto)
    {
        int diasRestantes = 0;
        try
        {
            var projecto = await context.Projetos.FirstAsync(c => c.Id == IdProjecto);

            if (projecto == null)
                return new RequestResponse
                {
                    Mensagem = "Projecto nao Encontrado",
                    Sucesso = false
                };

            var dataNow = DateTime.Now;

            DateTime dataMeta = DateTime.Parse(projecto.dataMeta);

            TimeSpan tempo = dataMeta - dataNow;
            diasRestantes = tempo.Days;
        }
        catch (System.Exception e)
        {
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Tempo Restante Calculado com Sucess",
            Sucesso = true,
            Target = diasRestantes
        };
    }

    public async Task<RequestResponse> FundoTotal(int IdProjecto)
    {
        int doacaoTotal = 0;
        try
        {
            var financiamentos = await context
                .FinanciamentosProjecto.Where(c => c.ProjectoId == IdProjecto)
                .ToListAsync();

            if (financiamentos == null)
                return new RequestResponse
                {
                    Mensagem = "Projecto nao existe ou sem doacoes",
                    Sucesso = false
                };

            foreach (var financiamento in financiamentos)
            {
                doacaoTotal += int.Parse(financiamento.doacao);
            }
        }
        catch (System.Exception e)
        {
            return new RequestResponse { Mensagem = e.Message, Sucesso = false };
        }

        return new RequestResponse
        {
            Mensagem = "Total de doacoes calculado com sucesso",
            Sucesso = true,
            Target = doacaoTotal
        };
    }
}
