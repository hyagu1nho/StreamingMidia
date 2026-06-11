namespace StreamingMidia.Domain;

public class Filme : Midia
{
    public string Diretor { get; set; }
    public string Classificacao { get; set; }

    public Filme(string titulo, string genero, int duracaoEmMinutos, string diretor, string classificacao)
        : base(titulo, genero, duracaoEmMinutos)
    {
        Diretor = diretor;
        Classificacao = classificacao;
    }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"🎬 Filme: {Titulo}");
        Console.WriteLine($"   Diretor: {Diretor} | Classificação: {Classificacao}");
        Console.WriteLine($"   Gênero: {Genero} | Duração: {DuracaoEmMinutos} min");
    }
}