using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaChamado
{
    public RepositorioChamado repositorioChamado;
    public RepositorioEquipamento repositorioEquipamento;
    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar chamado");
        Console.WriteLine("2 - Editar chamado");
        Console.WriteLine("3 - Excluir chamado");
        Console.WriteLine("4 - Visualizar chamado");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro de chamado");
        Console.WriteLine("---------------------------------");

        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine();

        DateTime dataAbertura = DateTime.Now;

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
            eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao
            );
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite o ID do equipamento que deseja selecionar");
        int idEquipamentoSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = null;

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            if (eq.id == idEquipamentoSelecionado)
            {
                equipamentoSelecionado = eq;
                break;
            }
        }

        Chamado novoChamado = new Chamado();
        novoChamado.titulo = titulo;
        novoChamado.descricao = descricao;
        novoChamado.dataAbertura = dataAbertura;
        novoChamado.equipamento = equipamentoSelecionado;

        repositorioChamado.Cadastrar(novoChamado);

        Console.WriteLine($"Chamado {novoChamado.titulo} foi cadastro com sucesso!");
        Console.ReadLine();
    }
    public void Editar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de Chamado");
        Console.WriteLine("---------------------------------");

        Chamado[] chamadosSalvos = repositorioChamado.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
            "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
        );

        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamado ch = chamadosSalvos[i];

            if (ch == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
                ch.id,
                ch.titulo,
                ch.descricao,
                ch.dataAbertura.ToShortDateString(),
                ch.equipamento.nome
            );
        }

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o id do registro que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine();

        Console.WriteLine("---------------------------------");

        Equipamento[] equipamentosSalvos = repositorioEquipamento.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
            "Id", "Nome", "Preço de Aquisição", "Data de Fabricação"
        );

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                eq.id, eq.nome, eq.precoAquisicao, eq.dataFabricacao
            );
        }

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o id do equipamento que deseja selecionar: ");
        int idEquipamentoSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = null;

        for (int i = 0; i < equipamentosSalvos.Length; i++)
        {
            Equipamento eq = equipamentosSalvos[i];

            if (eq == null)
                continue;

            if (eq.id == idEquipamentoSelecionado)
            {
                equipamentoSelecionado = eq;
                break;
            }
        }

        Chamado chamadoAtualizado = new Chamado();
        chamadoAtualizado.titulo = titulo;
        chamadoAtualizado.descricao = descricao;
        chamadoAtualizado.equipamento = equipamentoSelecionado;

        repositorioChamado.Editar(idSelecionado, chamadoAtualizado);

        Console.WriteLine($"O chamado {titulo} foi editado com sucesso!");
        Console.ReadLine();
    }
    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de Chamado");
        Console.WriteLine("---------------------------------");

        Chamado[] chamadosSalvos = repositorioChamado.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
            "Id", "Título", "Descrição", "Data de Abertura", "Equipamento"
        );

        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamado ch = chamadosSalvos[i];

            if (ch == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
                ch.id,
                ch.titulo,
                ch.descricao,
                ch.dataAbertura.ToShortDateString(),
                ch.equipamento.nome
            );
        }

        Console.WriteLine("---------------------------------");
        Console.Write("Digite o id do registro que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        repositorioChamado.Excluir(idSelecionado);

        Console.WriteLine($"O chamado foi excluído com sucesso!");
        Console.ReadLine();
    }
    public void Visualizar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de Chamados");
        Console.WriteLine("---------------------------------");

        Chamado[] chamadosSalvos = repositorioChamado.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
            "Id", "Título", "Descrição", "Data de abertura", "Equipamento"
        );

        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamado ch = chamadosSalvos[i];

            if (ch == null)
                continue;

            Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -30} | {3, -17} | {4, -15}",
            ch.id,
            ch.titulo,
            ch.descricao,
            ch.dataAbertura.ToShortDateString(),
            ch.equipamento.nome
        );

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }
    }
}