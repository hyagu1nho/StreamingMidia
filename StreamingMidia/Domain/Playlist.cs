namespace StreamingMidia.Domain;

public class Playlist
{
    public string Nome { get; set; }
    private List<Midia> _midias = new List<Midia>();

    public Playlist(string nome)
    {
        Nome = nome;
    }

    public void AdicionarMidia(Midia midia)
    {
        _midias.Add(midia);
        Console.WriteLine($"    '{midia.Titulo}' adicionada à playlist '{Nome}'");
    }

    // Sobrecarga: adicionar com posição específica
    public void AdicionarMidia(Midia midia, int posicao)
    {
        _midias.Insert(posicao, midia);
        Console.WriteLine($"    '{midia.Titulo}' adicionada na posição {posicao} da playlist '{Nome}'");
    }

    public void RemoverMidia(Midia midia)
    {
        _midias.Remove(midia);
        Console.WriteLine($"    '{midia.Titulo}' removida da playlist '{Nome}'");
    }

    // Regra de negócio 3: calcula duração total
    public int CalcularDuracaoTotal()
    {
        return _midias.Sum(m => m.DuracaoEmMinutos);
    }

    public List<Midia> GetMidias()
    {
        return _midias;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"\n Playlist: {Nome} | Total: {CalcularDuracaoTotal()} min");
        foreach (var midia in _midias)
        {
            midia.ExibirDetalhes(); // polimorfismo aqui
        }
    }
}