using System.ComponentModel.DataAnnotations;

namespace APISuperHeroi.Model
{
    public class SuperPoderes
    {
        [Key]
        public int Id { get; set; }
        public string? SuperPoder { get; set; }
        public string? Descricao { get; set; }
      
        public static List<SuperPoderes> ObterOpcoesIniciais()
        {
            return new List<SuperPoderes>
        {
            new SuperPoderes { Id = 1, SuperPoder = "Voo", Descricao = "Habilidade de voar." },                              
            new SuperPoderes { Id = 2, SuperPoder = "Força sobre-humana", Descricao = "Força muito além dos limites humanos." },
            new SuperPoderes { Id = 3, SuperPoder = "Hiper velocidade", Descricao = "Capacidade de se mover em velocidades extremas." },
            new SuperPoderes { Id = 4, SuperPoder = "Telepatia", Descricao = "Capacidade de ler mentes e se comunicar mentalmente." },
            new SuperPoderes { Id = 5, SuperPoder = "Invisibilidade", Descricao = "Capacidade de se tornar invisível aos olhos." },
            new SuperPoderes { Id = 6, SuperPoder = "Manipulação do tempo", Descricao = "Controle sobre o fluxo do tempo." },
            new SuperPoderes { Id = 7, SuperPoder = "Controle elemental", Descricao = "Domínio sobre os elementos naturais: água, fogo, terra, ar." },
            new SuperPoderes { Id = 8, SuperPoder = "Telecinese", Descricao = "Habilidade de mover objetos com a mente." },
            new SuperPoderes { Id = 9, SuperPoder = "Transformação de forma", Descricao = "Capacidade de alterar a aparência física." },
            new SuperPoderes { Id = 10, SuperPoder = "Geração de campo de força", Descricao = "Criação de uma barreira de proteção invisível." },
            new SuperPoderes { Id = 11, SuperPoder = "Cura acelerada", Descricao = "Capacidade de se curar rapidamente de ferimentos." },
            new SuperPoderes { Id = 12, SuperPoder = "Viagem interdimensional", Descricao = "Deslocamento entre diferentes dimensões." }

        };
        }
    }
}
