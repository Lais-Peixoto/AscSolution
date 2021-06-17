using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationContext _contexto;
        private readonly DbSet<Aluno> _dbSet;

        public AlunoRepository(ApplicationContext contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<Aluno>();
        }

        public List<Estudante> GetEstudantes()
        {
            var nomeArquivoTxt = "Notas.txt";
            var estudantes = new List<Estudante>();

            using (FileStream fs = new FileStream(nomeArquivoTxt, FileMode.Open))
            using (var leitor = new StreamReader(fs))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    string[] campos = linha.Split('\t');

                    var estudante = new Estudante();
                    estudante.Chamada = campos[0];
                    estudante.Turma = campos[1];
                    estudante.Nota1 = float.Parse(campos[2]);
                    estudante.Nota2 = float.Parse(campos[3]);
                    estudante.Nota3 = float.Parse(campos[4]);

                    var aux = (decimal)((estudante.Nota1 + 1.2 * estudante.Nota2 + 1.4 * estudante.Nota3) / (1 + 1.2 + 1.4));
                    aux = Math.Round(aux, 1);

                    var media = (float)(aux);
                    estudante.Media = media;

                    if (media > 6)
                    {
                        estudante.Situacao = "APROVADO";
                        estudante.ProvaFinal = -1;
                    }
                    else if (media < 4)
                    {
                        estudante.Situacao = "REPROVADO";
                        estudante.ProvaFinal = -1;
                    }
                    else
                    {
                        var rnd = new Random();

                        var auxPF = (decimal)(rnd.NextDouble() * 10);
                        auxPF = Math.Round(auxPF, 1);

                        var auxMF = (decimal)((media + estudante.ProvaFinal) / 2);
                        auxMF = Math.Round(auxMF, 1);

                        estudante.ProvaFinal = (float)(auxPF);
                        media = (float)auxMF;
                        estudante.Media = media;

                        if (media >= 5)
                        {
                            estudante.Situacao = "APROVADO";
                        }
                        else
                        {
                            estudante.Situacao = "REPROVADO";
                        }
                    }

                    estudantes.Add(estudante);
                }
            }

            return estudantes;
        }

        public void SaveAlunos(List<Estudante> estudantes)
        {
            foreach (var estudante in estudantes)
            {
                if (!_dbSet.Where(p => p.Chamada == estudante.Chamada).Any())
                {
                    var novoAluno = new Aluno(estudante.Chamada, estudante.Turma, estudante.Nota1, estudante.Nota2, estudante.Nota3);
                    novoAluno.Media = estudante.Media;
                    novoAluno.ProvaFinal = estudante.ProvaFinal;
                    novoAluno.Situacao = estudante.Situacao;

                    _dbSet.Add(novoAluno);
                }
                _contexto.SaveChanges();
            }
        }
    }

    public class Estudante
    {
        public string Chamada { get; set; }
        public string Turma { get; set; }
        public float Nota1 { get; set; }
        public float Nota2 { get; set; }
        public float Nota3 { get; set; }

        public float Media { get; set; }
        public float ProvaFinal { get; set; }
        public string Situacao { get; set; }
    }
}
