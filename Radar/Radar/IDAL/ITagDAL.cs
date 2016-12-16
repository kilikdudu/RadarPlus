using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.IDAL
{
    public interface ITagDAL
    {
        IList<TagInfo> listar();
		IList<TagInfo> listarTag(int id);
        TagInfo pegar(int idTag);
        int gravar(TagInfo tag);
        void excluir(int id);
    }
}
