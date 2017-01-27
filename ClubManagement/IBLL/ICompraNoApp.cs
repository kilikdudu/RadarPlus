using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.IBLL
{
    public interface ICompraNoApp
    {
        bool comprar(string idProduto);
        bool possuiProduto(string idProduto);
    }
}
