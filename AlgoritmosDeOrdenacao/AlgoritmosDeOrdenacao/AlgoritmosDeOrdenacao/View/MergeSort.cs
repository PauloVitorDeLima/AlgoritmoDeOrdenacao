using System;
using System.IO;
using System.Windows.Forms;

namespace AlgoritmosDeOrdenacao.View
{
    public partial class MergeSort : Form
    {
        public MergeSort()
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

            valor = OrdenaMergeSort(valor, valor.Length);

            //Pega data de agora
            DateTime b = DateTime.Now;

            //apresenta em messageBox o tempo de duraçao da atividade
            MessageBox.Show("Tempo de execucao: " + b.Subtract(a).TotalSeconds + " Segundos");

            //apresenta em messageBox a quantidade de movimentos realizados
            MessageBox.Show("Ocorreu um total de " + Movimentos + " Movimentos");

            //Limpa RichTxtBx
            RichTxtBxValores.Clear();

            int UmDecimo = (int)(valor.Length / 10);
            int Metade = (int)(valor.Length / 2);
            //meio = (int)((baixo + alto) / 2);
            //Apresenta os valores organizados no RichTxtBx
            for (int i = 0; i < UmDecimo; i++)
            {
                Application.DoEvents();
                RichTxtBxValores.AppendText(valor[i] + "\n");
            }
            DialogResult continuarMetade = MessageBox.Show("Foi feito 1 décimo do tamanho total, Deseja continuar até a metade?", "Continuar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (continuarMetade.ToString().ToUpper() == "YES")
            {
                for (int i = UmDecimo; i < Metade; i++)
                {
                    Application.DoEvents();
                    RichTxtBxValores.AppendText(valor[i] + "\n");
                }
                DialogResult continuarFinal = MessageBox.Show("Foi feito até a metade, Deseja continuar até o Final?", "Continuar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (continuarFinal.ToString().ToUpper() == "YES")
                {
                    for (int i = Metade; i < valor.Length; i++)
                    {
                        Application.DoEvents();
                        RichTxtBxValores.AppendText(valor[i] + "\n");
                    }

                }

            }
            //desativa a ação do botão para aguardar o fim do processo
            ButtonMenu.Enabled = true;

            //adicionar para sobrescrever arquivo
            //EscreverArquivo(caminho, valor);                                                 //******* ADICIONAR ESSA LINHA PARA ESCREVER NO ARQUIVO OS VALORES
        }
        //Metodo para ordernar com Merge
        private int[] OrdenaMergeSort(int[] valor, int n)
        {

            int TamAtual;
            int inicio;
            

            for (TamAtual = 1; TamAtual <= n - 1; TamAtual = 2 * TamAtual)
            {
                for (inicio = 0; inicio < n-1; inicio += 2 * TamAtual)
                {
                    int meio = inicio + TamAtual - 1;

                    int fim = Math.Min(inicio + 2 * TamAtual - 1, n - 1);
                    
                    OrdenaMergePrincipal(valor, inicio, meio, fim);
                };
            }
            return valor;
        }

        public void OrdenaMergePrincipal(int[] valor, int inicio, int meio, int fim) {
            int i, j, k;
            int n1 = meio - inicio + 1;
            
            int n2 = fim - meio;
            if (n2 < 0)
            {
                return;
            }
            int[] InicioArray = new int[n1];
            int[] FimArray = new int[n2];

            for (i = 0; i < n1; i++)
            { 
                InicioArray[i] = valor[inicio + i];
            }
            for (j = 0; j < n2; j++)
            {
                FimArray[j] = valor[meio + 1 + j];
            }
            i = 0;
            j = 0;
            k = inicio;

            while (i < n1 && j < n2)
            {
                if (InicioArray[i] <= FimArray[j])
                {
                    valor[k] = InicioArray[i];

                    i++;
                }
                else
                {
                    valor[k] = FimArray[j];
                    //Application.DoEvents();
                    Movimentos++;
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                valor[k] = InicioArray[i];
               // Application.DoEvents();
                Movimentos++;
                i++;
                k++;
            }
            while (j < n2)
            {
                valor[k] = FimArray[j];
                //Application.DoEvents();
                Movimentos++;
                j++;
                k++;
            }
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
