using Radar.Model;
using Xamarin.Forms;

namespace Radar
{
    internal class MapaPagePercurso : Page
    {
        private PercursoInfo percurso;

        public MapaPagePercurso(PercursoInfo percurso)
        {
            this.percurso = percurso;
        }
    }
}