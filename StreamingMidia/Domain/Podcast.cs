namespace StreamingMidia.Domain;

public class Podcast : Midia
{
    public string Apresentador { get; set; }
    public int NumeroEpisodio { get; set; }

    public Podcast(string titulo, string genero, int duracaoEmMinutos, string apresentador, int numeroEpisodio)
        : base(titulo, genero, duracaoEmMinutos)
    {
        Apresentador = apresentador;
        NumeroEpisodio = numeroEpisodio;
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"   Podcast: {Titulo} - Ep. {NumeroEpisodio}");
        Console.WriteLine($"   Apresentador: {Apresentador}");
        Console.WriteLine($"   Gênero: {Genero} | Duração: {DuracaoEmMinutos} min");
    }
}