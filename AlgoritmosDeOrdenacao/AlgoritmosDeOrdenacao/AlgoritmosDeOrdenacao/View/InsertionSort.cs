using System;
using System.IO;
using System.Windows.Forms;

namespace AlgoritmosDeOrdenacao.View
{
    public partial class InsertionSort : Form
    {
        public InsertionSort()
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
            try
            {


                //valor recebe os valores contidos no arquivo de texto que será lido
                int[] valor = Array.ConvertAll(LerArquivo(caminho), s => int.Parse(s));

                //Pega data de agora
                DateTime a = DateTime.Now;

                //valor recebe os dados ja organizados
                valor = OrdenaInsertionSort(valor, valor.Length);

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
                valor = null;
                //adicionar para sobrescrever arquivo
                //EscreverArquivo(caminho, valor);                                                 //******* ADICIONAR ESSA LINHA PARA ESCREVER NO ARQUIVO OS VALORES
            }
            catch (Exception ex)
            {

            }
            //desativa a ação do botão para aguardar o fim do processo
            ButtonMenu.Enabled = true;


        }
        //Metodo para ordernar com Insertion
        public int[] OrdenaInsertionSort(int[] valor, int n)
        {
            
            //Cria variavel temporaria, uma Flag e uma para marcar os movimentos
            int Temp, Flag; 
            //para o i = 1 for menor que o tamanho do array 
            for (int i = 1; i < n; i++)
            {
                //valor temporario recebe o valor no index i
                Temp = valor[i];
                //flag alterada para 0
                Flag = 0;
                //j recebe o i - 1, ate q j for maior ou igual a 0 e a flag for diferente de 1
                for(int j = i - 1; j>=0 && Flag != 1;){
                    //se o valor temporario for menor que o valor no index j
                    if (Temp < valor[j])
                    {
                        //valor no index j + 1 recebe o valor do index j
                        valor[j + 1] = valor[j];
                        j--;
                        //valor  no index j + 1 recebe o valor temporario
                        valor[j + 1] = Temp;
                        //Contabiliza uma movimentacao
                        Movimentos++;
                       // Application.DoEvents();
                    }
                    else
                    {
                        //flag se torna 1
                        Flag = 1;
                       // Application.DoEvents();
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
            //retorna ao menu escondendo a tela na qual se encontra
            MainMenu menu = new MainMenu();
            menu.Show();
            Hide();
        }
    }
}
