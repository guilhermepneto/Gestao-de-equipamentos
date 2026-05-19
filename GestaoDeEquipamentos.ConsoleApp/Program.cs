using GestaoDeEquipamentos.ConsoleApp.Dominio;

int contadorIdsEquipamentos = 1;
Equipamento[] equipamentosSalvos = new Equipamento[100];

int contadorIdsChamados = 1;
Chamado[] chamadosSalvos = new Chamado[100];

Equipamento equipamentoTeste = new Equipamento();
equipamentoTeste.id = contadorIdsEquipamentos++;
equipamentoTeste.nome = "Notebook Dell";
equipamentoTeste.precoAquisicao = 2000;
equipamentoTeste.dataFabricacao = DateTime.Parse("02/02/2020");

equipamentosSalvos[0] = equipamentoTeste;

Chamado chamadoTeste = new Chamado();
chamadoTeste.id = contadorIdsChamados++;
chamadoTeste.titulo = "Display quebrado";
chamadoTeste.descricao = "O display liga mas não tem brilho.";
chamadoTeste.equipamento = equipamentoTeste;

equipamentosSalvos[0] = equipamentoTeste;

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{

    string? opcaoMenuPrincipal = telaPrincipal.ObterOpcaoMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenuPrincipal == "1")
    {
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
                equipamento.id = contadorIdsEquipamentos++;
                equipamento.nome = nome;
                equipamento.precoAquisicao = precoAquisicao;
                equipamento.dataFabricacao = dataFabricacao;

                for (int i = 0; i < equipamentosSalvos.Length; i++)
                {
                    if (equipamentosSalvos[i] == null)
                    {
                        equipamentosSalvos[i] = equipamento;
                        break;
                    }
                }

                Console.WriteLine($"Equipamento {equipamento.nome} foi cadastro com sucesso!");
                Console.ReadLine();
            }

            else if (opcaoMenu == "2")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Edição de Equipamentos");
                Console.WriteLine("---------------------------------");

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

                for (int i = 0; i < equipamentosSalvos.Length; i++)
                {
                    Equipamento equipamentoSelecionado = equipamentosSalvos[i];

                    if (equipamentoSelecionado == null)
                        continue;

                    if (equipamentoSelecionado.id == idSelecionado)
                    {
                        equipamentoSelecionado.nome = nome;
                        equipamentoSelecionado.precoAquisicao = precoAquisicao;
                        equipamentoSelecionado.dataFabricacao = dataFabricacao;
                        break;
                    }
                }

                Console.WriteLine($"Equipamento {nome} foi editado com sucesso!");
                Console.ReadLine();
            }

            else if (opcaoMenu == "3")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Exclusão de Equipamentos");
                Console.WriteLine("---------------------------------");

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

                for (int i = 0; i < equipamentosSalvos.Length; i++)
                {
                    Equipamento equipamentoSelecionado = equipamentosSalvos[i];

                    if (equipamentoSelecionado == null)
                        continue;

                    if (equipamentoSelecionado.id == idSelecionado)
                    {
                        equipamentosSalvos[i] = null;
                        break;
                    }

                }

                Console.WriteLine($"Equipamento foi excluído com sucesso!");
                Console.ReadLine();
            }

            else if (opcaoMenu == "4")
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Visualização de Equipamentos");
                Console.WriteLine("---------------------------------");

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
    }

    else if (opcaoMenuPrincipal == "2")
    {
        while (true)
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


