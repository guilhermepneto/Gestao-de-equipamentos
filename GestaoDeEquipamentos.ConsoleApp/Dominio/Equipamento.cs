namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Equipamento
{
    public int id;
    public string nome;
    public decimal precoAquisicao;
    public DateTime dataFabricacao;


    public Equipamento(string nome, decimal precoAquisicao, DateTime dataFabricacao)
    {
        this.nome = nome;
        this.precoAquisicao = precoAquisicao;
        this.dataFabricacao = dataFabricacao;
    }

}
