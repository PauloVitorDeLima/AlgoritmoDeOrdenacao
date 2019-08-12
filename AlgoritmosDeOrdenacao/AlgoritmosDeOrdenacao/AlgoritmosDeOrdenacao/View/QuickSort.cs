using System;
using System.IO;
using System.Windows.Forms;

namespace AlgoritmosDeOrdenacao.View
{
    public partial class QuickSort : Form
    {
        public QuickSort()
        {
            InitializeComponent();
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            //Limpa RichTxtBx
            RichTxtBxValores.Clear();

            //caminho recebe o local onde o usuario escolher o arquivo txt
            String caminho = EscolherArquivo();

            //valor recebe os valores contidos no arquivo de texto que será lido
            int[] valor = Array.ConvertAll(LerArquivo(caminho), s => int.Parse(s));

            //valor recebe os dados ja organizados
            //valor = OrdenaQuickSort(valor, valor.Length);                                     //******* ADICIONAR ESSA LINHA VERIFICANDO A MANEIRA DE CRIAR O ALGORITMO

            //Apresenta os valores organizados no RichTxtBx
            for (int i = 0; i < valor.Length; i++)
            {
                RichTxtBxValores.AppendText(valor[i] + "\n");
            }

            //chama metodo que sobrescreve o arquivo
            //EscreverArquivo(caminho, valor);                                                  //******* ADICIONAR ESSA LINHA PARA ESCREVER NO ARQUIVO OS VALORES
        }

        /*

           COLOCAR AQUI O CODIGO DO ALGORITMO!!








        */

        //Metodo de Escolher Arquivo
        public String EscolherArquivo()
        {
            //instancia o OpenFileDialog (File Explorer)
            OpenFileDialog dialog = new OpenFileDialog();

            //Titulo do file explorer
            dialog.Title = "Arquivo de texto para ordenar";

            //filtro de quais tipos de arquivos serao aceitos, no caso tudo que termine com .txt
            dialog.Filter = "Arquivos texto | *.txt";

            //instancia o resultado da busca
            DialogResult resposta = dialog.ShowDialog();
            
            //se a busca for realizada escreve o caminho no campo de texto
            if (resposta == DialogResult.OK)
            {
                TxtPath.Text = dialog.FileName;
            }

            //retorna o caminho de texto mesmo se o resultado for nulo
            return TxtPath.Text;
        }
        
        //Metodo para ler conteudo do arquivo de texto
        public String[] LerArquivo(String caminho)
        {

            //um array de String recebe todo conteudo do arquivo
            String[] arquivo = File.ReadAllLines(caminho);
            
            //retorna o arquivo
            return arquivo;
        }

        //Metodo para escrever no arquivo
        public void EscreverArquivo(String caminho, int[] valor)
        {
            //instancia para sobrescrever no arquivo selecionado
            StreamWriter writer = new StreamWriter(caminho, false);
        
            //usando escrever
            using (writer)
            {
            
                //escreve todos os valores do Valor no arquivo
                for (int i = 0; i < valor.Length; i++)
                {
                    writer.Write(valor[i] + "\n");
                }
            }
        }

        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            Hide();
        }
    }
}
