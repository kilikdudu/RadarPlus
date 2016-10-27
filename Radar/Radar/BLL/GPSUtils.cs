using Radar.Factory;
using Radar.Model;
using Radar.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public static class GPSUtils
    {
        public static void atualizarPosicao(LocalizacaoInfo local) {
            RadarBLL regraRadar = RadarFactory.create();
            PercursoBLL regraPercurso = PercursoFactory.create();
            regraRadar.calcularLocalizacao(local);
            if (MapaPage.Atual != null)
                MapaPage.Atual.atualizarPosicao(local);
            regraPercurso.executarGravacao(local);
        }
    }
}
