using chessGame;
using System;


List<Peca> J1 = new();
List<Peca> J2 = new();

Random randNum = new Random((int)DateTime.Now.Ticks);


Game game = new();
Rei Rei = new();


Rei.corrente.x = 4;
Rei.corrente.y = 0;
game.pecas.Add(Rei);

Rei.preencheListaPos(J1, J2);
Rei.imprimirListaPosicoes();
game.imprimirTabuleiro();


Console.WriteLine("Chess Game o/");