using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessgame.Model.Pecas;

namespace Chessgame.Model
{
    // Representa o estado do tabuleiro e regras básicas de movimentação/checagem.
    internal class Tabuleiro
    {
        private List<Peca> pecas = new List<Peca>();

        // Cria uma cópia do tabuleiro para simular movimentos sem alterar o original.
        public Tabuleiro Clone()
        {
            var copia = new Tabuleiro();
            foreach (Peca p in pecas)
            {
                copia.AdicionarPeca(p.Clone());            
            }
            return copia;
        }

        // Adiciona uma peça ao tabuleiro.
        public void AdicionarPeca(Peca peca)
        {
            pecas.Add(peca);
        }

        // Remove uma peça do tabuleiro (capturas).
        public void RemoverPeca(Peca peca)
        {
            pecas.Remove(peca);
        }

        // Busca a peça em uma posição específica.
        public Peca GetPeca(Posicao p)
        {
            return pecas.Find(pecas => pecas.corrente.x == p.x && pecas.corrente.y == p.y);
        }

        //        public Peca GetPeca(int x, int y)
        //        {
        //            return pecas.Find(pecas => pecas.corrente.x == x && pecas.corrente.y == y);
        //        }

        // Garante que a posição está dentro do tabuleiro (0..7).
        public bool EstaNoLimite (Posicao p)
        {
            return p.x >= 0 && p.x <= 7 && p.y >= 0 && p.y <= 7;
        }

        // Move uma peça, tratando captura e marcando como movida.
        public void MoverPeca (Peca p, Posicao destino)
        {
            Peca pecadestino = GetPeca(destino);
            if (pecadestino != null && pecadestino.Cor != p.Cor)
            {
                RemoverPeca(pecadestino);
            }
            p.atualizaPosicao(destino); 
            p.MarcarComoMovida();

        }
        // Verifica se o rei da cor informada está sob ataque.
        public bool EstaEmXeque(CorPeca cor)
        {
            Peca rei = pecas.Find(peca => peca is Rei && peca.Cor == cor);
            foreach (Peca peca in pecas)
            {
                if (peca.Cor != cor)
                {
                    peca.LimparMovimentos();
                    peca.preencheListaPos(this);
                    foreach (Posicao pos in peca.possiveisMovimentos)
                    {
                        if (pos.x == rei.corrente.x && pos.y == rei.corrente.y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Verifica empate por afogamento (sem movimentos legais e sem estar em xeque).
        public bool EstaEmEmpate(CorPeca cor)
        {
            if (EstaEmXeque(cor))
            {
                return false;
            }

            foreach (Peca peca in pecas)
            {
                if (peca.Cor != cor)
                {
                    continue;
                }

                peca.LimparMovimentos();
                peca.preencheListaPos(this);
                foreach (Posicao pos in peca.possiveisMovimentos)
                {
                    if (MovimentoValido(peca, pos, out _))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        

        // Verifica se a cor está em xeque-mate (sem movimentos legais que evitem o xeque).
        public bool EstaEmXequeMate(CorPeca cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca peca in pecas)
            {
                if (peca.Cor == cor)
                {
                    peca.LimparMovimentos();
                    peca.preencheListaPos(this);
                    foreach (Posicao pos in peca.possiveisMovimentos)
                    {
                        Tabuleiro clone = this.Clone();
                        Peca pecaClone = clone.GetPeca(peca.corrente);
                        clone.MoverPeca(pecaClone, pos);
                        if (!clone.EstaEmXeque(cor))
                        {
                            return false;
                        }
                    }   
                }
            }
            return true;
        }

        // Simula o movimento e verifica se o rei fica em xeque.
        public bool MovimentoDeixaReiEmXeque(Peca peca, Posicao destino)
        {
            Tabuleiro clone = Clone();
            Peca pecaClone = clone.GetPeca(peca.corrente);
            clone.MoverPeca(pecaClone, destino);
            return clone.EstaEmXeque(peca.Cor);
        }

        // Valida o movimento contra regras da peça, captura e xeque.
        public bool MovimentoValido(Peca peca, Posicao destino, out string? motivo)
        {
            motivo = null;
            peca.LimparMovimentos();
            peca.preencheListaPos(this);

            bool movimentoNaLista = peca.possiveisMovimentos.Any(p => p.x == destino.x && p.y == destino.y);
            if (!movimentoNaLista)
            {
                motivo = "Movimento inválido.";
                return false;
            }

            Peca pecaDestino = GetPeca(destino);
            if (pecaDestino != null && pecaDestino.Cor == peca.Cor)
            {
                motivo = "Não é possível capturar uma peça da mesma cor.";
                return false;
            }

            if (MovimentoDeixaReiEmXeque(peca, destino))
            {
                motivo = "Esse movimento deixa seu rei em xeque.";
                return false;
            }

            return true;
        }


    }
}
