using System;
using System.IO;
using System.Windows.Forms;

namespace AlgoritmosDeOrdenacao.View
{
    public partial class BubbleSort : Form
    {
        
        public BubbleSort()
        {
            InitializeComponent();
            
        }


        //cria variavel para capturar quantidade de movimentos
        long Movimentos = 0;

        private void SelectFile_Click(object sender, EventArgs e)
        {
            //Limpa RichTxtBx 
            RichTxtBxValores.Clear();
            //desativa a ação do botão para aguardar o fim do processo
            ButtonMenu.Enabled = false;
            
            //caminho recebe o local onde o usuario escolher o arquivo txt
            String caminho = EscolherArquivo();
            try
            {
                //Alerta que a ordenacao esta ocorrendo
                RichTxtBxValores.AppendText("\n A Ordenação está sendo realizada, por favor aguarde!!");

                //valor recebe os valores contidos no arquivo de texto que será lido
                int[] valor = Array.ConvertAll(LerArquivo(caminho), s => int.Parse(s));

                //Pega data de agora
                DateTime a = DateTime.Now;

                //metodo que organiza os dados
                valor = OrdenaBubbleSort(valor, valor.Length);

                //Pega data de agora
                DateTime b = DateTime.Now;
                //apresenta em messageBox o tempo de duraçao da atividade
                MessageBox.Show("Tempo de execucao: " + b.Subtract(a).TotalSeconds + " Segundos");
                //apresenta em messageBox a quantidade de movimentos realizados
                MessageBox.Show("Ocorreu um total de " + Movimentos + " Movimentos");

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
                valor = null;
                //adicionar para sobrescrever arquivo
                //EscreverArquivo(caminho, valor);                                                 //******* ADICIONAR ESSA LINHA PARA ESCREVER NO ARQUIVO OS VALORES
            }
            catch (Exception ex)
            {

            }
            //ativa a ação do botão 
            ButtonMenu.Enabled = true;
        }
        //Metodo para ordernar com Bubble
        private int[] OrdenaBubbleSort(int[] valor, int n)
        {
            //para o tamanho for maior ou igual a 1
            for (int j = n; j >= 1; j--)
            {
                //para o i menor que o tamanho - 1
                for (int i = 0; i < n - 1; i++) {
                    //se o valor no index for maior que o valor no index + 1
                    if (valor[i] > valor[i + 1])
                        {
                        //cria variavel temporaria recebendo o valor do index 
                        int temporario = valor[i];
                        //o valor recebe o valor do index + 1
                        valor[i] = valor[i + 1];
                        //e o valor do index + 1 recebe o numero temporario
                        valor[i + 1] = temporario;
                        //conta que ocorreu uma movimentacao
                        //Application.DoEvents();
                        Movimentos++;
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
        //retorna ao menu escondendo a tela na qual se encontra   
        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            Hide();
        }
    }
}
