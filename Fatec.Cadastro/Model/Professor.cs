using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Cadastro.Model
{
    class Professor : Pessoa
    {
        public List<string> Materias { get; set; }
    }
}
