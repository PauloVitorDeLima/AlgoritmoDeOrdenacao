﻿using System;
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

        private void SelectFile_Click(object sender, EventArgs e)
        {
            //Limpa RichTxtBx 
            RichTxtBxValores.Clear();

            //caminho recebe o local onde o usuario escolher o arquivo txt
            String caminho = EscolherArquivo();
            
            //valor recebe os valores contidos no arquivo de texto que será lido
            int[] valor = Array.ConvertAll(LerArquivo(caminho), s => int.Parse(s));
            
            //valor recebe os dados ja organizados
            valor = OrdenaSelectionSort(valor, valor.Length);                                      //******* ADICIONAR ESSA LINHA VERIFICANDO A MANEIRA DE CRIAR O ALGORITMO

            //Apresenta os valores organizados no RichTxtBx
            for (int i = 0; i < valor.Length; i++)
            {
                RichTxtBxValores.AppendText(valor[i] + "\n");
            }
            //chama metodo que sobrescreve o arquivo
            //EscreverArquivo(caminho, valor);                                                 //******* ADICIONAR ESSA LINHA PARA ESCREVER NO ARQUIVO OS VALORES
        }

        static int[] OrdenaSelectionSort(int[] valor, int n)
        {
            //Pega data de agora
            DateTime a = DateTime.Now;
            long Comparacoes = 0;
            //cria variavel para capturar quantidade de movimentos
            long Movimentos = 0;
            int temp;
            int flag;

            for (int i = 1; i < n; i++) {
                temp = valor[i];
                flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1; ) {
                    if (temp < valor[j])
                    {
                        valor[j + 1] = valor[j];
                        j--;
                        valor[j + 1] = temp;
                        Movimentos++;
                        Comparacoes++;
                    }
                    else
                    {
                        flag = 1;
                        Comparacoes++;
                    }
                }
            }
            //Pega data de agora
            DateTime b = DateTime.Now;
            //apresenta em messageBox o tempo de duraçao da atividade
            MessageBox.Show("Tempo de execucao: " + b.Subtract(a).TotalSeconds + " Segundos");
            //Comparacoes realizadas ao total
            MessageBox.Show("Quantidade de comparações: " + Comparacoes);
            //apresenta em messageBox a quantidade de movimentos realizados
            MessageBox.Show("Ocorreu um total de " + Movimentos + " Movimentos");
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
