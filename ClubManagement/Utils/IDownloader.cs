using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Utils
{
    public interface IDownloader
    {
        void download(string url);
    }
}
