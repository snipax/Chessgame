using chessGame;
using System;


List<Peca> J1 = new();
List<Peca> J2 = new();

Random randNum = new Random((int)DateTime.Now.Ticks);

for (int i = 0; i < 8; i++)
{
    Peca ptemp = new Peca();
    ptemp.corrente.x = randNum.Next();
    ptemp.corrente.y = randNum.Next();
    J1.Add(ptemp);
    ptemp.corrente.x = randNum.Next();
    ptemp.corrente.y = randNum.Next();
    J2.Add(ptemp);
}

Peca Rei = new Peca();

Rei.tipoPeca = 0;

Rei.corrente.x = 4;
Rei.corrente.y = 1;


Console.WriteLine("Chess Game o/");