namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

using GestaoDeEquipamentos.ConsoleApp.Dominio;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento;
    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar equipamento");
        Console.WriteLine("2 - Editar equipamento");
        Console.WriteLine("3 - Excluir equipamento");
        Console.WriteLine("4 - Visualizar equipamentos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o preço de aquisição do equipamento: ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento: ");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

        Equipamento equipamento = new Equipamento();
        equipamento.nome = nome;
        equipamento.precoAquisicao = precoAquisicao;
        equipamento.dataFabricacao = dataFabricacao;

        RepositorioEquipamento.Cadastrar(equipamento);

        Console.WriteLine($"Equipamento {equipamento.nome} foi cadastro com sucesso!");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Equipamentos");
        Console.WriteLine("---------------------------------");

        Equipamento[] equipamentosSalvos = repositorioEquipamento.SelecionarTodos();

        Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
           "Id", "Nome", "Preço de Aquisição", "Data de fabricação"
           );

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite o ID do registro que deseja editar");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o preço de aquisição do equipamento: ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento: ");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

        Equipamento equipamentoAtualizado = new Equipamento();
        equipamentoSelecionado.nome = equipamentoAtualizado.nome;
        equipamentoSelecionado.precoAquisicao = equipamentoAtualizado.precoAquisicao;
        equipamentoSelecionado.dataFabricacao = equipamentoAtualizado.dataFabricacao;

        RepositorioEquipamento.Editar(idSelecionado, equipamentoAtualizado);

        Console.WriteLine($"Equipamento {nome} foi editado com sucesso!");
        Console.ReadLine();
    }

    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de Equipamentos");
        Console.WriteLine("---------------------------------");

        Equipamento[] equipamentosSalvos = repositorioEquipamento.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            "Id", "Nome", "Preço de Aquisição", "Data de fabricação"
            );

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite o ID do registro que deseja excluir");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        repositorioEquipamento.Excluir(idSelecionado);

        Console.WriteLine($"Equipamento foi excluído com sucesso!");
        Console.ReadLine();
    }

    public void Visualizar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de Equipamentos");
        Console.WriteLine("---------------------------------");

        Equipamento[] equipamentosSalvos = repositorioEquipamento.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            "Id", "Nome", "Preço de Aquisição", "Data de fabricação"
            );

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione ENTER para continuar");
        Console.ReadLine();
    }
}