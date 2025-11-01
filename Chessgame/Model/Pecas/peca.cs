using System;
using System.Collections.Generic;

namespace Chessgame.Model.Pecas
{

    public enum CorPeca
    {
        Branco,
        Preto
    }
    internal class Posicao
    {
        public int x { get; set; }
        public int y { get; set; }

        public Posicao(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


        internal abstract class Peca
        {
            public Posicao corrente { get; protected set; } = new Posicao(0, 0);
            public CorPeca Cor { get; protected set; }
            public bool JaMoveu { get; protected set; }
            public bool statusPeça { get; private set; }
            public List<Posicao> possiveisMovimentos { get; protected set; } = new();
            public abstract string Simbolo { get; }
            public Peca(CorPeca cor)
            {
                this.Cor = cor;
                this.JaMoveu = false;
                this.statusPeça = true;
            }
        public abstract void preencheListaPos(Tabuleiro tabuleiro);
        public void LimparMovimentos()
        {
            possiveisMovimentos.Clear();
        }
        public virtual void atualizaPosicao(Posicao novaPosicao)
        {
            corrente = novaPosicao;
            JaMoveu = true;
        }
        public void atualizaStatus(bool novoStatus)
        {
            statusPeça = novoStatus;
        }

    }
}