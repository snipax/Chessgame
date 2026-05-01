using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessgame.Model.Pecas;
using Chessgame.View;

namespace Chessgame.Model
{
    // Controla o fluxo principal do jogo (turnos, entrada do usuário e validações).
    internal class Game
    {
        private readonly Tabuleiro _tabuleiro;
        private readonly Visualizador _visualizador;
        private CorPeca _turnoAtual;

        // Construtor prepara tabuleiro, visualizador e define o turno inicial.
        public Game()
        {
            _tabuleiro = new Tabuleiro();
            _visualizador = new Visualizador(_tabuleiro);
            _turnoAtual = CorPeca.Branco;
        }

        // Coloca uma peça no tabuleiro e sincroniza a posição interna da peça.
        public void AdicionarPecaPosicao(Peca peca, Posicao pos)
        {
            peca.atualizaPosicao(pos);
            _tabuleiro.AdicionarPeca(peca);
        }

        // Posiciona todas as peças nas posições iniciais.
        public void IniciarJogo()
        {
            for (int x = 0; x < 8; x++)
            {
                AdicionarPecaPosicao(new Peao(CorPeca.Branco), new Posicao(x, 1));
                AdicionarPecaPosicao(new Peao(CorPeca.Preto), new Posicao(x, 6));
            }
            AdicionarPecaPosicao(new Torre(CorPeca.Branco), new Posicao(0, 0));
            AdicionarPecaPosicao(new Cavalo(CorPeca.Branco), new Posicao(1, 0));
            AdicionarPecaPosicao(new Bispo(CorPeca.Branco), new Posicao(2, 0));
            AdicionarPecaPosicao(new Rainha(CorPeca.Branco), new Posicao(3, 0));
            AdicionarPecaPosicao(new Rei(CorPeca.Branco), new Posicao(4, 0));
            AdicionarPecaPosicao(new Bispo(CorPeca.Branco), new Posicao(5, 0));
            AdicionarPecaPosicao(new Cavalo(CorPeca.Branco), new Posicao(6, 0));
            AdicionarPecaPosicao(new Torre(CorPeca.Branco), new Posicao(7, 0));

            AdicionarPecaPosicao(new Torre(CorPeca.Preto), new Posicao(0, 7));
            AdicionarPecaPosicao(new Cavalo(CorPeca.Preto), new Posicao(1, 7));
            AdicionarPecaPosicao(new Bispo(CorPeca.Preto), new Posicao(2, 7));
            AdicionarPecaPosicao(new Rainha(CorPeca.Preto), new Posicao(3, 7));
            AdicionarPecaPosicao(new Rei(CorPeca.Preto), new Posicao(4, 7));
            AdicionarPecaPosicao(new Bispo(CorPeca.Preto), new Posicao(5, 7));
            AdicionarPecaPosicao(new Cavalo(CorPeca.Preto), new Posicao(6, 7));
            AdicionarPecaPosicao(new Torre(CorPeca.Preto), new Posicao(7, 7));
        }

        // Loop principal: imprime estado, lê jogada, valida e move peças.
        public void ExecutarLoopDeJogo()
        {
            while (true)
            {
                Console.Clear();
                _visualizador.imprimirTabuleiro();
                Console.WriteLine($"Turno atual: {_turnoAtual}");
                if (_tabuleiro.EstaEmXequeMate(_turnoAtual))
                {
                    Console.WriteLine($"Xeque-mate! {_turnoAtual} perdeu.");
                    break;
                }
                if (_tabuleiro.EstaEmEmpate(_turnoAtual))
                {
                    Console.WriteLine("Empate por afogamento!");
                    break;
                }
                if (_tabuleiro.EstaEmXeque(_turnoAtual))
                {
                    Console.WriteLine("Xeque!");
                }

                Posicao origem;
                Posicao destino;
                // Loop de leitura/validação da entrada do usuário.
                while (true)
                {
                    Console.Write("Digite o movimento (ex: e2 e4): ");
                    string? entrada = Console.ReadLine();
                    if (TryParseMovimento(entrada, out origem, out destino))
                    {
                        break;
                    }
                    Console.WriteLine("Entrada inválida. Use o formato e2 e4.");
                }

                Peca? pecaSelecionada = _tabuleiro.GetPeca(origem);
                if (pecaSelecionada == null)
                {
                    Console.WriteLine("Peça inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    continue;
                }
                if (pecaSelecionada.Cor != _turnoAtual)
                {
                    Console.WriteLine("Escolha uma peça de sua cor. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    continue;
                }
                _visualizador.mostrarMovimentos(pecaSelecionada);
                if (!_tabuleiro.MovimentoValido(pecaSelecionada, destino, out string? motivo))
                {
                    Console.WriteLine($"{motivo} Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    continue;
                }
                Peca? pecaDestino = _tabuleiro.GetPeca(destino);
                bool foiCaptura = pecaDestino != null && pecaDestino.Cor != pecaSelecionada.Cor;
                _tabuleiro.MoverPeca(pecaSelecionada, destino);
                bool houvePromocao = TentarPromocao(pecaSelecionada, destino);
                if (foiCaptura)
                {
                    Console.WriteLine("Captura realizada. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
                if (houvePromocao)
                {
                    Console.WriteLine("Peão promovido. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
                _turnoAtual = _turnoAtual == CorPeca.Branco ? CorPeca.Preto : CorPeca.Branco;
            }
        }

        // Converte texto do tipo "e2 e4" em duas posições do tabuleiro.
        private static bool TryParseMovimento(string? entrada, out Posicao origem, out Posicao destino)
        {
            origem = new Posicao(0, 0);
            destino = new Posicao(0, 0);
            if (string.IsNullOrWhiteSpace(entrada))
            {
                return false;
            }

            string[] partes = entrada.Trim().ToLowerInvariant().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length != 2)
            {
                return false;
            }

            if (!TryParsePosicao(partes[0], out origem) || !TryParsePosicao(partes[1], out destino))
            {
                return false;
            }

            return true;
        }

        // Converte um texto como "e2" em coordenadas numéricas internas.
        private static bool TryParsePosicao(string texto, out Posicao posicao)
        {
            posicao = new Posicao(0, 0);
            if (texto.Length != 2)
            {
                return false;
            }

            char coluna = texto[0];
            char linha = texto[1];
            if (coluna < 'a' || coluna > 'h')
            {
                return false;
            }

            if (linha < '1' || linha > '8')
            {
                return false;
            }

            int x = coluna - 'a';
            int y = linha - '1';
            posicao = new Posicao(x, y);
            return true;
        }

        // Promove o peão ao chegar na última fileira e substitui pela peça escolhida.
        private bool TentarPromocao(Peca pecaMovida, Posicao destino)
        {
            if (pecaMovida is not Peao)
            {
                return false;
            }

            int ultimaLinha = pecaMovida.Cor == CorPeca.Branco ? 7 : 0;
            if (destino.y != ultimaLinha)
            {
                return false;
            }

            Peca pecaPromovida = CriarPecaPromovida(pecaMovida.Cor);
            _tabuleiro.RemoverPeca(pecaMovida);
            AdicionarPecaPosicao(pecaPromovida, destino);
            return true;
        }

        // Solicita a peça desejada e cria a nova instância para a promoção.
        private static Peca CriarPecaPromovida(CorPeca cor)
        {
            while (true)
            {
                Console.Write("Promover para (Q/T/B/C): ");
                string? escolha = Console.ReadLine()?.Trim().ToUpperInvariant();
                switch (escolha)
                {
                    case "Q":
                        return new Rainha(cor);
                    case "T":
                        return new Torre(cor);
                    case "B":
                        return new Bispo(cor);
                    case "C":
                        return new Cavalo(cor);
                }

                Console.WriteLine("Escolha inválida. Use Q, T, B ou C.");
            }
        }
    }
}