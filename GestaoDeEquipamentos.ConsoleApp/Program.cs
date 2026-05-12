using GestaoDeEquipamentos.ConsoleApp.Dominio;

DateTime dataAgora = DateTime.Now;

while (true)
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

    if (opcaoMenu == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenu == "1")
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
    }
    else if (opcaoMenu == "2")
    {
    }
    else if (opcaoMenu == "3")
    {
    }
    else if (opcaoMenu == "4")
    {
    }
}