using Chessgame.Model;
using Chessgame.Model.Pecas;
using System;


List<Peca> J1 = new();
List<Peca> J2 = new();

Random randNum = new Random((int)DateTime.Now.Ticks);


Game game = new();
Torre rei = new();
Rainha cavalo = new();
cavalo.corrente.x = 4;
cavalo.corrente.y = 3;

game.pecas.Add(rei);
game.pecas.Add(cavalo);


rei.corrente.x = 4;
rei.corrente.y = 0;


rei.preencheListaPos(J1, J2);

game.imprimirTabuleiro();
game.mostrarMovimentos(rei);


Console.WriteLine("Chess Game o/");
game.mostrarMovimentos(cavalo);