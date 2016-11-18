using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.IBLL
{
    public interface IAudio
    {
        void play(string[] arquivos);
        void play(string arquivo);
    }
}
