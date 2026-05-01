using System;
using System.Collections.Generic;

namespace Chessgame.Model.Pecas
{

    // Cores possíveis das peças.
    public enum CorPeca
    {
        Branco,
        Preto
    }
    // Representa uma posição (x, y) no tabuleiro.
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


        // Classe base para todas as peças: cor, posição atual e movimentos possíveis.
        internal abstract class Peca
        {
            public Posicao corrente { get; protected set; } = new Posicao(0, 0);
            public CorPeca Cor { get; protected set; }
            public bool JaMoveu { get; protected set; }
            public List<Posicao> possiveisMovimentos { get; protected set; } = new();
            public abstract string Simbolo { get; }
            public Peca(CorPeca cor)
            {
                this.Cor = cor;
                this.JaMoveu = false;
            }

            // Clona a peça para simulações sem alterar o original.
            public abstract Peca Clone();

        // Marca a peça como já movimentada (usado por regras como o peão).
        internal void MarcarComoMovida() => JaMoveu = true;

        // Preenche a lista de movimentos válidos considerando o tabuleiro atual.
        public abstract void preencheListaPos(Tabuleiro tabuleiro);
        // Limpa a lista de movimentos possíveis.
        public void LimparMovimentos()
        {
            possiveisMovimentos.Clear();
        }
        // Atualiza a posição atual da peça.
        public virtual void atualizaPosicao(Posicao novaPosicao)
        {
            corrente = novaPosicao;
        }


    }
}