using Radar.DALFactory;
using Radar.IDAL;
using Radar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.BLL
{
    public class PercursoBLL
    {
        private IPercursoDAL _percursoDB;
        private IPercursoPontoDAL _pontoDB;

        public PercursoBLL()
        {
            _percursoDB = PercursoDALFactory.create();
            _pontoDB = PercursoPontoDALFactory.create();
        }

        private void atualizar(PercursoInfo percurso) {
            if (percurso != null)
                percurso.Pontos = _pontoDB.listar(percurso.Id);
        }

        public IList<PercursoInfo> listar() {
            IList<PercursoInfo> percursos = _percursoDB.listar();
            foreach (PercursoInfo percurso in _percursoDB.listar()) {
                atualizar(percurso);
            }
            return percursos;
        }

        public PercursoInfo pegar(int id) {
            PercursoInfo percurso = _percursoDB.pegar(id);
            atualizar(percurso);
            return percurso;
        }

        public int gravar(PercursoInfo percurso) {
            return _percursoDB.gravar(percurso);
        }

        public int gravarPonto(PercursoPontoInfo ponto) {
            return _pontoDB.gravar(ponto);
        }

        public void excluir(int id)
        {
            PercursoInfo percurso = _percursoDB.pegar(id);
            foreach (PercursoPontoInfo ponto in percurso.Pontos)
                _pontoDB.excluir(ponto.Id);
            _percursoDB.excluir(id);
        }
    }
}
