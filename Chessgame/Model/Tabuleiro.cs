using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessgame.Model.Pecas;

namespace Chessgame.Model
{
    internal class Tabuleiro
    {
        private List<Peca> pecas = new List<Peca>();

        public Tabuleiro Clone()
        {
            var copia = new Tabuleiro();
            foreach (Peca p in pecas)
            {
                copia.AdicionarPeca(p.Clone());            
            }
            return copia;
        }

        public void AdicionarPeca(Peca peca)
        {
            pecas.Add(peca);
        }

        public void RemoverPeca(Peca peca)
        {
            pecas.Remove(peca);
        }

        public Peca GetPeca(Posicao p)
        {
            return pecas.Find(pecas => pecas.corrente.x == p.x && pecas.corrente.y == p.y);
        }

//        public Peca GetPeca(int x, int y)
//        {
//            return pecas.Find(pecas => pecas.corrente.x == x && pecas.corrente.y == y);
//        }
        public bool EstaNoLimite (Posicao p)
        {
            return p.x >= 0 && p.x <= 7 && p.y >= 0 && p.y <= 7;
        }

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


    }
}
