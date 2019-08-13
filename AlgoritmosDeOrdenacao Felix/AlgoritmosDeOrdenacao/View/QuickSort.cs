﻿using System;
using System.IO;
using System.Windows.Forms;

namespace AlgoritmosDeOrdenacao.View
{
    public partial class QuickSort : Form
    {
        //"""""""""Puxei pra ká pra todo mundo poder usar
        long Movimentos = 0;
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
            //cria variavel para capturar quantidade de movimentos
            //Pega data de agora
            DateTime a = DateTime.Now;
            //valor recebe os dados ja organizados
            valor = OrdenaQuickSort(valor, 0, valor.Length - 1, a); //******* ADICIONAR ESSA LINHA VERIFICANDO A MANEIRA DE CRIAR O ALGORITMO

            //"""""""""Puxei pra ká, embaixo da primeira recursão
            //Pega data de agora
            DateTime b = DateTime.Now;
            //apresenta em messageBox o tempo de duraçao da atividade
            MessageBox.Show("Tempo de execucao: " + b.Subtract(a).TotalSeconds + " Segundos");
            //apresenta em messageBox a quantidade de movimentos realizados
            MessageBox.Show("Ocorreu um total de " + Movimentos + " Movimentos");
            //"""""""""

            //Apresenta os valores organizados no RichTxtBx
            for (int i = 0; i < valor.Length; i++)
            {
                RichTxtBxValores.AppendText(valor[i] + "\n");
            }

            //chama metodo que sobrescreve o arquivo
            //EscreverArquivo(caminho, valor);                                                  //******* ADICIONAR ESSA LINHA PARA ESCREVER NO ARQUIVO OS VALORES
        }
        //"""""""""Tirei o Static
        int[] OrdenaQuickSort(int[] valor, int primeiro, int ultimo, DateTime a)
        {
            int baixo, alto, meio, pivo, repositorio;
            baixo = primeiro;
            alto = ultimo;
            meio = (int)((baixo + alto) / 2);
            pivo = valor[meio];

            while (baixo <= alto)
            {
                while (valor[baixo] < pivo)
                    baixo++;
                while (valor[alto] > pivo)
                    alto--;
                if (baixo < alto)
                {
                    repositorio = valor[baixo];
                    valor[baixo++] = valor[alto];
                    valor[alto--] = repositorio;
                    Movimentos++;    
                }
                else if (baixo == alto)
                {
                    Movimentos++;
                    baixo++;
                    alto--;
                }

            }
            if (alto > primeiro)
            {
                OrdenaQuickSort(valor, primeiro, alto, a);
            }else if (baixo < ultimo)
            { 
                OrdenaQuickSort(valor, baixo, ultimo, a);
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