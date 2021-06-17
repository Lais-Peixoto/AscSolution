using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repositories;

namespace WebAPI
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly ApplicationContext _contexto;
            private readonly IAlunoRepository _alunoRepository;

            public DataService(ApplicationContext contexto, IAlunoRepository alunoRepository)
            {
                _contexto = contexto;
                _alunoRepository = alunoRepository;
            }

            public void InicializaDB()
            {
                // criação
                _contexto.Database.Migrate();

                // leitura
                List<Estudante> estudantes = _alunoRepository.GetEstudantes();

                //gravacao
                _alunoRepository.SaveAlunos(estudantes);
            }
        }
    }
}
