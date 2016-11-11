using ClubManagement.Utils;
using Radar.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Controls
{
    public class DownloaderAtualizacao: DownloaderProcessar
    {
        private const string NOME_ARQUIVO = "maparadar.txt";

        public DownloaderAtualizacao()
        {
            this.aoCompletar += (sender, nomeArquivo) =>
            {
                if (_janela != null)
                {
                    _janela.Titulo = "Aguarde alguns segundos...";
                    _janela.Progresso = 1;
                    _janela.Descricao = "";
                }

                if (ArquivoUtils.existe(NOME_ARQUIVO))
                {
                    if (_janela != null)
                    {
                        _janela.Titulo = "Processando arquivo...";
                        _janela.Progresso = 0;
                        _janela.Descricao = "";
                    }
                    var task = Task.Factory.StartNew(() =>
                    {
                        string arquivo = ArquivoUtils.abrirTexto(NOME_ARQUIVO);
                        using (StringReader reader = new StringReader(arquivo))
                        {
                            string line;
                            int i = 0;
                            while ((line = reader.ReadLine()) != null)
                            {
                                ThreadUtils.RunOnUiThread(() =>
                                {
                                    processarArquivo(i, i);
                                });
                                i++;
                            }
                        }
                        MensagemUtils.avisar(nomeArquivo);
                        fecharPopup();
                    });
                    //task.Start();
                }
                else
                    MensagemUtils.avisar("Arquivo não encontrado!");

            };
        }

        public void download() {
            download(Configuracao.UrlAtualizacao, NOME_ARQUIVO);
        }


    }
}
