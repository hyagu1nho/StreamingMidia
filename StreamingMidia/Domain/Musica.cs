namespace StreamingMidia.Domain;

public class Musica : Midia
{
    public string Artista { get; set; }
    public string Album { get; set; }

    public Musica(string titulo, string genero, int duracaoEmMinutos, string artista, string album)
        : base(titulo, genero, duracaoEmMinutos)
    {
        Artista = artista;
        Album = album;
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"   Música: {Titulo}");
        Console.WriteLine($"   Artista: {Artista} | Album: {Album}");
        Console.WriteLine($"   Gênero: {Genero} | Duração: {DuracaoEmMinutos} min");
    }
}