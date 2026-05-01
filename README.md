# Chessgame

Projeto iniciado na aula de Programação Orientada a Objetos (POO) com foco em arquitetura e princípios SOLID. O objetivo é simular uma partida de xadrez no console, organizando as responsabilidades em camadas simples de domínio e apresentação.

## Visão geral
- Jogo de xadrez em console (movimentos por coordenadas como `e2 e4`).
- Estruturação em classes de domínio para tabuleiro, peças e regras.
- Separação de responsabilidades entre lógica de jogo e visualização.
- Implementado em C# com .NET 8.

## Estrutura do projeto
- `Chessgame/Program.cs`: ponto de entrada.
- `Chessgame/Model/Game.cs`: fluxo principal do jogo (turnos, validações, loop).
- `Chessgame/Model/Tabuleiro.cs`: regras e estado do tabuleiro.
- `Chessgame/Model/Pecas/*`: peças e movimentos.
- `Chessgame/View/Visualizador.cs`: saída no console.

## Principais conceitos aplicados

### POO
- **Encapsulamento**: estado e operações das peças e do tabuleiro ficam centralizados nas classes correspondentes.
- **Herança**: `Peca` é a classe base para as peças específicas (`Rei`, `Rainha`, `Torre`, `Bispo`, `Cavalo`, `Peao`).
- **Polimorfismo**: cada peça implementa suas regras de movimento em `preencheListaPos`.
- **Abstração**: a classe `Game` orquestra o jogo sem expor detalhes internos das peças.

### SOLID
- **S (Single Responsibility)**: cada classe tem um papel claro (ex.: `Visualizador` apenas imprime, `Tabuleiro` gerencia regras e estado).
- **O (Open/Closed)**: novas peças podem ser adicionadas estendendo `Peca` sem alterar o fluxo principal.
- **L (Liskov Substitution)**: instâncias de `Peca` podem ser substituídas por peças concretas sem quebrar a lógica.
- **I (Interface Segregation)**: as classes mantêm contratos mínimos e focados, evitando acoplamento excessivo.
- **D (Dependency Inversion)**: o fluxo de jogo depende de abstrações do domínio, não de detalhes específicos de UI.

## Requisitos
- .NET 8 SDK

## Como executar
1. Abra o projeto no Visual Studio.
2. Defina o projeto `Chessgame` como inicializador.
3. Execute com `F5`.

Ou via CLI:
1. `dotnet build`
2. `dotnet run --project Chessgame`

## Como jogar
- O jogo solicita um movimento no formato: `e2 e4`.
- O sistema valida o movimento, aplica capturas e alterna o turno.
- O jogo termina com xeque-mate ou empate por afogamento.
