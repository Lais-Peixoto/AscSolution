using System.Collections.Generic;

namespace WebAPI.Repositories
{
    public interface IAlunoRepository
    {
        List<Estudante> GetEstudantes();
        void SaveAlunos(List<Estudante> estudantes);
    }
}