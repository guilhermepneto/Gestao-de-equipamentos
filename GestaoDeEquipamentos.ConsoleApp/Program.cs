using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;

int contadorIdsChamados = 1;
Chamado[] chamadosSalvos = new Chamado[100];

TelaPrincipal telaPrincipal = new TelaPrincipal();

TelaEquipamento telaEquipamento = new TelaEquipamento();

while (true)
{

    string? opcaoMenuPrincipal = telaPrincipal.ObterOpcaoMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        if (opcaoMenuPrincipal == "1")
        {
            string? opcaoMenu = telaEquipamento.ObterOpcaoMenu();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }
            if (opcaoMenu == "1")
                telaEquipamento.Cadastrar();

            else if (opcaoMenu == "2")
                telaEquipamento.Editar();

            else if (opcaoMenu == "3")
                telaEquipamento.Excluir();

            else if (opcaoMenu == "4")
                telaEquipamento.Visualizar();
        }
        else if (opcaoMenuPrincipal == "2")
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

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
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

                Console.WriteLine(
                    "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                    "Id", "Nome", "Preço de Aquisição", "Data de fabricação"
                    );

                for (int i = 0; i < telaEquipamento.equipamentosSalvos.Length; i++)
                {
                    Equipamento eq = telaEquipamento.equipamentosSalvos[i];

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

                for (int i = 0; i < telaEquipamento.equipamentosSalvos.Length; i++)
                {
                    Equipamento eq = telaEquipamento.equipamentosSalvos[i];

                    if (eq == null)
                        continue;

                    if (eq.id == idEquipamentoSelecionado)
                    {
                        equipamentoSelecionado = eq;
                        break;
                    }
                }

                Chamado novoChamado = new Chamado();
                novoChamado.id = contadorIdsChamados++;
                novoChamado.titulo = titulo;
                novoChamado.descricao = descricao;
                novoChamado.dataAbertura = dataAbertura;
                novoChamado.equipamento = equipamentoSelecionado;

                for (int i = 0; i < chamadosSalvos.Length; i++)
                {
                    if (chamadosSalvos[i] == null)
                    {
                        chamadosSalvos[i] = novoChamado;
                        break;
                    }
                }

                Console.WriteLine($"Chamado {novoChamado.titulo} foi cadastro com sucesso!");
                Console.ReadLine();
            }

            else if (opcaoMenu == "2")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Edição de Chamado");
                Console.WriteLine("---------------------------------");
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
                Console.WriteLine(
                    "{0, -7} | {1, -15} | {2, -20} | {3, -15}",
                    "Id", "Nome", "Preço de Aquisição", "Data de Fabricação"
                );

                for (int i = 0; i < telaEquipamento.equipamentosSalvos.Length; i++)
                {
                    Equipamento eq = telaEquipamento.equipamentosSalvos[i];

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

                for (int i = 0; i < telaEquipamento.equipamentosSalvos.Length; i++)
                {
                    Equipamento eq = telaEquipamento.equipamentosSalvos[i];

                    if (eq == null)
                        continue;

                    if (eq.id == idEquipamentoSelecionado)
                    {
                        equipamentoSelecionado = eq;
                        break;
                    }
                }

                for (int i = 0; i < chamadosSalvos.Length; i++)
                {
                    Chamado chamadoSelecionado = chamadosSalvos[i];

                    if (chamadoSelecionado == null)
                        continue;

                    if (chamadoSelecionado.id == idSelecionado)
                    {
                        chamadoSelecionado.titulo = titulo;
                        chamadoSelecionado.descricao = descricao;
                        chamadoSelecionado.equipamento = equipamentoSelecionado;
                        break;
                    }
                }

                Console.WriteLine($"O chamado {titulo} foi editado com sucesso!");
                Console.ReadLine();
            }

            else if (opcaoMenu == "3")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Exclusão de Chamado");
                Console.WriteLine("---------------------------------");
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

                for (int i = 0; i < chamadosSalvos.Length; i++)
                {
                    Chamado chamadoSelecionado = chamadosSalvos[i];

                    if (chamadoSelecionado == null)
                        continue;

                    if (chamadoSelecionado.id == idSelecionado)
                    {
                        chamadosSalvos[i] = null;
                        break;
                    }
                }

                Console.WriteLine($"O chamado foi excluído com sucesso!");
                Console.ReadLine();
            }

            else if (opcaoMenu == "4")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Visualização de Chamados");
                Console.WriteLine("---------------------------------");

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
                    ch.id, ch.titulo, ch.descricao, ch.dataAbertura.ToShortDateString(), ch.equipamento.nome
                );

                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadLine();
                }
            }
        }
    }
}


