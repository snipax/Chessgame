using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessgame.Model.Pecas;
using Chessgame.View;

namespace Chessgame.Model
{
    internal class Game
    {
        private readonly Tabuleiro _tabuleiro;
        private readonly Visualizador _visualizador;
        private CorPeca _turnoAtual;

        public Game()
        {
            _tabuleiro = new Tabuleiro();
            _visualizador = new Visualizador(_tabuleiro);
            _turnoAtual = CorPeca.Branco;
        }

        public void AdicionarPecaPosicao(Peca peca, Posicao pos)
        {
            peca.atualizaPosicao(pos);
            _tabuleiro.AdicionarPeca(peca);
        }

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
                if (_tabuleiro.EstaEmXeque(_turnoAtual))
                {
                    Console.WriteLine("Xeque!");
                }

                int pecax;
                while (true)
                {
                    Console.Write("Selecione a peça para mover (Coloque a coordenada X): ");
                    if (int.TryParse(Console.ReadLine(), out pecax) && pecax >= 0 && pecax <= 7)
                            break;
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
                int pecay;
                while (true)
                {
                    Console.Write("Selecione a peça para mover (Coloque a coordenada Y): ");
                    if (int.TryParse(Console.ReadLine(), out pecay) && pecay >= 0 && pecay <= 7)
                            break;
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }

                Peca? pecaSelecionada = _tabuleiro.GetPeca(new Posicao(pecax, pecay));
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
                int destinoEntradax;
                while (true)
                {
                    Console.WriteLine("Digite a coordenada X de destino (0-7): ");
                    if (int.TryParse(Console.ReadLine(), out destinoEntradax) && destinoEntradax >= 0 && destinoEntradax <= 7)
                        break;
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
                int destinoEntraday;
                while (true)
                { 
                    Console.WriteLine("Digite a coordenada Y de destino (0-7): ");
                    if (int.TryParse(Console.ReadLine(), out destinoEntraday) && destinoEntraday >= 0 && destinoEntraday <= 7)
                        break;
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
                Posicao destino = new Posicao(destinoEntradax, destinoEntraday);
                bool movimentoValido = pecaSelecionada.possiveisMovimentos.Any(p => p.x == destino.x && p.y == destino.y);
                if (!movimentoValido)
                {
                    Console.WriteLine("Movimento inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    continue;
                }
                _tabuleiro.MoverPeca(pecaSelecionada, destino);
                _turnoAtual = _turnoAtual == CorPeca.Branco ? CorPeca.Preto : CorPeca.Branco;
            }
        }
    }
}