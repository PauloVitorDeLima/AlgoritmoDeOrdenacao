using System;
using System.IO;
using System.Windows.Forms;

namespace AlgoritmosDeOrdenacao.View
{
    public partial class SelectionSort : Form
    {
        public SelectionSort()
        {
            InitializeComponent();
        }
        long Movimentos = 0;
        private void SelectFile_Click(object sender, EventArgs e)
        {
            //Limpa RichTxtBx 
            RichTxtBxValores.Clear();
            //desativa a ação do botão para aguardar o fim do processo
            ButtonMenu.Enabled = false;
            //Alerta que a ordenacao esta ocorrendo
            RichTxtBxValores.AppendText("\n A Ordenação está sendo realizada, por favor aguarde!!");
            //caminho recebe o local onde o usuario escolher o arquivo txt
            String caminho = EscolherArquivo();

            //valor recebe os valores contidos no arquivo de texto que será lido
            int[] valor = Array.ConvertAll(LerArquivo(caminho), s => int.Parse(s));

            //Pega data de agora
            DateTime a = DateTime.Now;
           
            //valor recebe os dados ja organizados
            valor = OrdenaSelectionSort(valor, valor.Length);                                      //******* ADICIONAR ESSA LINHA VERIFICANDO A MANEIRA DE CRIAR O ALGORITMO

            //Pega data de agora
            DateTime b = DateTime.Now;


            //apresenta em messageBox o tempo de duraçao da atividade
            MessageBox.Show("Tempo de execucao: " + b.Subtract(a).TotalSeconds + " Segundos");

            //apresenta em messageBox a quantidade de movimentos realizados
            MessageBox.Show("Ocorreu um total de " + Movimentos + " Movimentos");

            //Limpa RichTxtBx
            RichTxtBxValores.Clear();
            int PrimeiraParte;
            int SegundaParte;
            if (valor.Length > 100000)
            {
                PrimeiraParte = (int)(valor.Length / 1000);
                SegundaParte = (int)(valor.Length / 100);
            }
            else
            {
                PrimeiraParte = (int)(valor.Length / 10);
                SegundaParte = (int)(valor.Length / 2);
            }
            //Apresenta os valores organizados no RichTxtBx
            for (int i = 0; i < PrimeiraParte; i++)
            {
                Application.DoEvents();
                RichTxtBxValores.AppendText(valor[i] + "\n");
            }
            DialogResult continuarMetade = MessageBox.Show("Foi a Primeira parte do arquivo, Deseja continuar?", "Continuar",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (continuarMetade.ToString().ToUpper() == "YES")
            {
                for (int i = PrimeiraParte; i < SegundaParte; i++)
                {
                    Application.DoEvents();
                    RichTxtBxValores.AppendText(valor[i] + "\n");
                }
                DialogResult continuarFinal = MessageBox.Show("Foi a Segunda parte do arquivo, Deseja continuar até o Final?", "Continuar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (continuarFinal.ToString().ToUpper() == "YES")
                {
                    for (int i = SegundaParte; i < valor.Length; i++)
                    {
                        Application.DoEvents();
                        RichTxtBxValores.AppendText(valor[i] + "\n");
                    }

                }

            }
            //desativa a ação do botão para aguardar o fim do processo
            ButtonMenu.Enabled = true;


            //chama metodo que sobrescreve o arquivo
            //EscreverArquivo(caminho, valor);                                                 //******* ADICIONAR ESSA LINHA PARA ESCREVER NO ARQUIVO OS VALORES
        }

        private int[] OrdenaSelectionSort(int[] valor, int n)
        {
            int temp;
            int flag;

            for (int i = 1; i < n; i++)
            {
                temp = valor[i];
                flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (temp < valor[j])
                    {
                        //Application.DoEvents();
                        valor[j + 1] = valor[j];
                        j--;
                        valor[j + 1] = temp;
                        Movimentos++;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
            }
            return valor;
        }
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
