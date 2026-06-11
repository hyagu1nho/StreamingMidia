namespace StreamingMidia.Domain;

public class Usuario
{
    public string Nome { get; set; }
    public Assinatura Assinatura { get; private set; } // composição
    private List<Playlist> _playlists = new List<Playlist>();

    public Usuario(string nome, PlanoAssinatura plano, DateTime dataVencimento)
    {
        Nome = nome;
        Assinatura = new Assinatura(plano, dataVencimento); // composição: Usuario cria a Assinatura
    }

    public void AdicionarPlaylist(Playlist playlist)
    {
        _playlists.Add(playlist);
    }

    public List<Playlist> GetPlaylists()
    {
        return _playlists;
    }

    // Regra de negócio 2: recomenda gênero mais presente nas playlists do usuário
    public string RecomendarGenero()
    {
        var todasMidias = _playlists.SelectMany(p => p.GetMidias()).ToList();

        if (todasMidias.Count == 0)
            return "Nenhuma mídia encontrada para recomendar.";

        var generoMaisOuvido = todasMidias
            .GroupBy(m => m.Genero)
            .OrderByDescending(g => g.Count())
            .First().Key;

        return generoMaisOuvido;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($" Usuário: {Nome}");
        Assinatura.ExibirDetalhes();
        Console.WriteLine($"   Playlists: {_playlists.Count}");
    }
}