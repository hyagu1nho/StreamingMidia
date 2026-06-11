namespace StreamingMidia.Domain;

public abstract class Midia
{
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int DuracaoEmMinutos { get; set; }

    public Midia(string titulo, string genero, int duracaoEmMinutos)
    {
        Titulo = titulo;
        Genero = genero;
        DuracaoEmMinutos = duracaoEmMinutos;
    }

    public abstract void ExibirDetalhes();

    public override string ToString()
    {
        return $"{Titulo} ({Genero}) - {DuracaoEmMinutos} min";
    }
}