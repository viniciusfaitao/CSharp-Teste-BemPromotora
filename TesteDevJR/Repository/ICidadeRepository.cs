using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDevJR.Entities;

namespace TesteDevJR.Repository
{
    public interface ICidadeRepository
    {

        int Add(Cidade cidade);
        List<Cidade> GetCidades();
        List<Cidade> GetCidadesPorUF();
        Cidade Get(int Codigo);
        int Edit(Cidade cidade);
        int Delete(int Codigo);
    }
}
