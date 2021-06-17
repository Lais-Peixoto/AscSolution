using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Aluno : BaseModel
    {
        public Aluno()
        {
        }

        public Aluno(string chamada, string turma, float nota1, float nota2, float nota3)
        {
            Chamada = chamada;
            Turma = turma;
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
        }

        [Required]
        public string Chamada { get; set; }
        [Required]
        public string Turma { get; set; }
        [Required]
        public float Nota1 { get; set; }
        [Required]
        public float Nota2 { get; set; }
        [Required]
        public float Nota3 { get; set; }

        // Propriedades que serão calculadas..
        public float Media { get; set; }
        public float ProvaFinal { get; set; }
        public string Situacao { get; set; }
    }
}
