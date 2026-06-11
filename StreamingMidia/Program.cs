using StreamingMidia.Domain;

// --- Dados ---
var musica1 = new Musica("Blinding Lights", "Pop", 3, "The Weeknd", "After Hours");
var musica2 = new Musica("HUMBLE.", "Hip-Hop", 2, "Kendrick Lamar", "DAMN.");
var musica3 = new Musica("Bohemian Rhapsody", "Rock", 6, "Queen", "A Night at the Opera");
var musica4 = new Musica("Starboy", "Pop", 4, "The Weeknd", "Starboy");

var filme1 = new Filme("Interstellar", "Ficção Científica", 169, "Christopher Nolan", "12 anos");
var filme2 = new Filme("Parasita", "Drama", 132, "Bong Joon-ho", "16 anos");
var filme3 = new Filme("O Poderoso Chefão", "Crime", 175, "Francis Ford Coppola", "16 anos");

var podcast1 = new Podcast("Flow", "Entretenimento", 120, "Igor 3K", 350);
var podcast2 = new Podcast("Nerdcast", "Tecnologia", 90, "Jovem Nerd", 700);
var podcast3 = new Podcast("Huberman Lab", "Ciência", 150, "Andrew Huberman", 180);

var playlist1 = new Playlist("Hits do Momento");
playlist1.AdicionarMidia(musica1);
playlist1.AdicionarMidia(musica2);
playlist1.AdicionarMidia(musica4);
playlist1.AdicionarMidia(filme1);

var playlist2 = new Playlist("Clássicos");
playlist2.AdicionarMidia(musica3);
playlist2.AdicionarMidia(filme2);
playlist2.AdicionarMidia(filme3);

var playlist3 = new Playlist("Conhecimento");
playlist3.AdicionarMidia(podcast1);
playlist3.AdicionarMidia(podcast2);
playlist3.AdicionarMidia(podcast3);

var usuario1 = new Usuario("Hyago", PlanoAssinatura.Premium, new DateTime(2025, 12, 31));
usuario1.AdicionarPlaylist(playlist1);
usuario1.AdicionarPlaylist(playlist2);

var usuario2 = new Usuario("Ana", PlanoAssinatura.Gratuito, new DateTime(2024, 1, 1));
usuario2.AdicionarPlaylist(playlist3);

var usuario3 = new Usuario("Carlos", PlanoAssinatura.Premium, new DateTime(2026, 6, 30));
usuario3.AdicionarPlaylist(playlist2);
usuario3.AdicionarPlaylist(playlist3);

var usuarios = new List<Usuario> { usuario1, usuario2, usuario3 };

// --- Menu ---
bool executando = true;
while (executando)
{
    Console.Clear();
    Console.WriteLine("╔══════════════════════════════════╗");
    Console.WriteLine("║        StreamingMidia v1.0       ║");
    Console.WriteLine("╠══════════════════════════════════╣");
    Console.WriteLine("║ 1. Listar usuários               ║");
    Console.WriteLine("║ 2. Ver playlists de um usuário   ║");
    Console.WriteLine("║ 3. Ver detalhes de uma playlist  ║");
    Console.WriteLine("║ 4. Verificar permissão download  ║");
    Console.WriteLine("║ 5. Recomendar gênero             ║");
    Console.WriteLine("║ 6. Adicionar mídia à playlist    ║");
    Console.WriteLine("║ 0. Sair                          ║");
    Console.WriteLine("╚══════════════════════════════════╝");
    Console.Write("\nEscolha: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("=== Usuários ===");
            foreach (var u in usuarios)
                u.ExibirDetalhes();
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("=== Selecione o usuário ===");
            for (int i = 0; i < usuarios.Count; i++)
                Console.WriteLine($"{i + 1}. {usuarios[i].Nome}");
            Console.Write("Escolha: ");
            if (int.TryParse(Console.ReadLine(), out int idxU) && idxU >= 1 && idxU <= usuarios.Count)
            {
                var u = usuarios[idxU - 1];
                Console.WriteLine($"\nPlaylists de {u.Nome}:");
                foreach (var p in u.GetPlaylists())
                    Console.WriteLine($"  - {p.Nome} ({p.CalcularDuracaoTotal()} min)");
            }
            break;

        case "3":
            Console.Clear();
            var todasPlaylists = new List<Playlist> { playlist1, playlist2, playlist3 };
            Console.WriteLine("=== Selecione a playlist ===");
            for (int i = 0; i < todasPlaylists.Count; i++)
                Console.WriteLine($"{i + 1}. {todasPlaylists[i].Nome}");
            Console.Write("Escolha: ");
            if (int.TryParse(Console.ReadLine(), out int idxP) && idxP >= 1 && idxP <= todasPlaylists.Count)
                todasPlaylists[idxP - 1].ExibirDetalhes();
            break;

        case "4":
            Console.Clear();
            Console.WriteLine("=== Permissão de Download ===");
            foreach (var u in usuarios)
            {
                var permite = u.Assinatura.PermiteDownload();
                Console.WriteLine($"{u.Nome}: {(permite ? "✅ Pode baixar" : "❌ Não pode baixar")}");
            }
            break;

        case "5":
            Console.Clear();
            Console.WriteLine("=== Recomendação por Gênero ===");
            foreach (var u in usuarios)
                Console.WriteLine($"{u.Nome}: gênero recomendado → {u.RecomendarGenero()}");
            break;

        case "6":
            Console.Clear();
            var midias = new List<Midia> { musica1, musica2, musica3, musica4, filme1, filme2, filme3, podcast1, podcast2, podcast3 };
            var pls = new List<Playlist> { playlist1, playlist2, playlist3 };
            Console.WriteLine("=== Selecione a mídia ===");
            for (int i = 0; i < midias.Count; i++)
                Console.WriteLine($"{i + 1}. {midias[i]}");
            Console.Write("Escolha: ");
            if (int.TryParse(Console.ReadLine(), out int idxM) && idxM >= 1 && idxM <= midias.Count)
            {
                Console.WriteLine("\n=== Selecione a playlist ===");
                for (int i = 0; i < pls.Count; i++)
                    Console.WriteLine($"{i + 1}. {pls[i].Nome}");
                Console.Write("Escolha: ");
                if (int.TryParse(Console.ReadLine(), out int idxPl) && idxPl >= 1 && idxPl <= pls.Count)
                    pls[idxPl - 1].AdicionarMidia(midias[idxM - 1]);
            }
            break;

        case "0":
            executando = false;
            Console.WriteLine("Saindo...");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    if (executando)
    {
        Console.Write("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}