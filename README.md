# AscSolution

Aplicação para Web que lista o resultado do ano letivo para 60 alunos divididos entre 3 turmas e o resultado do campeonato
com os 5 melhores alunos do período letivo.
Cada aluno possui 3 notas de provas, a média do ano letivo e a situação no final do ano (aprovado ou reprovado), 
além do seu número de chamada, a nota da prova final (caso necessário) e sua respectiva turma.
Os alunos classificados para participar do campeonato são os 5 de maior média e o resultado é dado pela média
ponderada da prova especial com a média do aluno no ano letivo.

### Regras:

- Média do ano letivo: média ponderada das três provas tal que as provas 2 e 3 possuem respectivamente pesos 20% e 40% maiores que a primeira prova.
- Situação do aluno no ano letivo: "Aprovado", se a média for maior que 6. "Reprovado", se a média for menor que 4 e em "Prova Final" caso contrário.
O aluno em "Prova Final" somente será aprovado se a média da nota da prova final com a média do ano letivo for maior ou igual a 5.
- Critério de classificação para o campeonato: os 5 alunos com as maiores médias do ano letivo
- Regra da competição: O resultado do campeonato é a média ponderada de todas provas feitas com peso 1 e a prova especial que terá peso 2

### Funcionalidades:

- Lista resultado de todos os alunos no ano letivo
- Filtro por "Situação" do ano letivo
- Ordenação (crescente ou decrescente) por "Média" do ano letivo
- Lista o resultado dos cinco melhores alunos no campeonato

### Descrição Técnica do Projeto:

- Linguagens: C# (back-end) e JavaScript/TypeScript(front-end)
- Framework: .NET Core 5.0, Entity Framework Core 5.0.7, SqlServer 5.0.6, Angular 12.0.4
- IDE: Visual Studio Code e Visual Studio 2019
- Dados: Armazenados com SqlServer usando Entity Framework Core

### Foto da Aplicação Funcionando (back-end e front-end):

![Aplicação em Funcionamento](https://github.com/Lais-Peixoto/AscSolution/blob/main/FotosDaAplica%C3%A7%C3%A3o.png)
