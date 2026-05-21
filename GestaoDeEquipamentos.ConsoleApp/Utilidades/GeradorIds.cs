namespace GestaoDeEquipamentos.ConsoleApp.Utilidades;

public static class GeradorIds
{
    private static int contadorIdsEquipamentos = 1;
    private static int contadorIdsChamados = 1;

    public static int ObterIdsEquipamento()
    {
        return contadorIdsEquipamentos++;
    }

    public static int ObterIdChamado()
    {
        return contadorIdsChamados++;
    }

}