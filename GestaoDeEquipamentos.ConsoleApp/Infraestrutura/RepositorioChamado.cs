using GestaoDeEquipamentos.ConsoleApp.Dominio;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{

    private Chamado[] chamadosSalvos = new Chamado[100];

    public void Cadastrar(Chamado novoChamado)
    {
        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            if (chamadosSalvos[i] == null)
            {
                chamadosSalvos[i] = novoChamado;
                break;
            }
        }
    }
    public void Editar(int idSelecionado, Chamado chamadoAtualizado)
    {
        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamado chamadoSelecionado = chamadosSalvos[i];

            if (chamadoSelecionado == null)
                continue;

            if (chamadoSelecionado.Id == idSelecionado)
            {
                chamadoSelecionado.Atualizar(chamadoAtualizado);
                break;
            }
        }
    }

    public void Excluir(int idSelecionado)
    {
        for (int i = 0; i < chamadosSalvos.Length; i++)
        {
            Chamado chamadoSelecionado = chamadosSalvos[i];

            if (chamadoSelecionado == null)
                continue;

            if (chamadoSelecionado.Id == idSelecionado)
            {
                chamadosSalvos[i] = null;
                break;
            }
        }
    }

    public Chamado[] SelecionarTodos()
    {
        return chamadosSalvos;
    }
}