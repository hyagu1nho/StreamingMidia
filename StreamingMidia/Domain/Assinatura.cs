namespace StreamingMidia.Domain;

public enum PlanoAssinatura
{
    Gratuito,
    Premium
}

public class Assinatura
{
    public PlanoAssinatura Plano { get; set; }
    public DateTime DataVencimento { get; set; }

    public Assinatura(PlanoAssinatura plano, DateTime dataVencimento)
    {
        Plano = plano;
        DataVencimento = dataVencimento;
    }

    public bool EstaAtiva()
    {
        return DateTime.Now <= DataVencimento;
    }

    // Regra de negócio 1: apenas Premium pode fazer download
    public bool PermiteDownload()
    {
        return Plano == PlanoAssinatura.Premium && EstaAtiva();
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"   Plano: {Plano} | Vencimento: {DataVencimento:dd/MM/yyyy} | Ativa: {(EstaAtiva() ? "Sim" : "Não")}");
    }
}