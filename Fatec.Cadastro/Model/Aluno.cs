using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Cadastro.Model
{
    class Aluno : Pessoa
    {
        public int RA { get; set; }
        public List<string> Aulas { get; set; }
    }
}
