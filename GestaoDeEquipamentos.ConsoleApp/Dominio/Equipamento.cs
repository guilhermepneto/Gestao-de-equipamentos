using GestaoDeEquipamentos.ConsoleApp.Utilidades;

namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Equipamento
{
    public int id { get; private set; }
    public string Nome { get; private set; }
    public decimal PrecoAquisicao { get; private set; }
    public DateTime DataFabricacao { get; private set; }


    public Equipamento(string nome, decimal precoAquisicao, DateTime dataFabricacao)
    {
        id = GeradorIds.ObterIdsEquipamento();

        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
    }

    public void Atualizar(Equipamento equipamentoAtualizado)
    {
        Nome = equipamentoAtualizado.Nome;
        PrecoAquisicao = equipamentoAtualizado.PrecoAquisicao;
        DataFabricacao = equipamentoAtualizado.DataFabricacao;
    }

}
