using AlgoritmosDeOrdenacao.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmosDeOrdenacao
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BubbleSort_Click(object sender, EventArgs e)
        {

            BubbleSort bubble = new BubbleSort();
            bubble.Show();
            Hide(); 
        }

        private void SelectionSort_Click(object sender, EventArgs e)
        {
            SelectionSort selection = new SelectionSort();
            selection.Show();
            Hide();

        }


        private void QuickSort_Click(object sender, EventArgs e)
        {
            QuickSort quick = new QuickSort();
            quick.Show();
            Hide();

        }

        private void InsertionSort_Click(object sender, EventArgs e)
        {
            InsertionSort sort = new InsertionSort();
            sort.Show();
            Hide();
        }

        private void MergeSort_Click(object sender, EventArgs e)
        {
            MergeSort merge = new MergeSort();
            merge.Show();
            Hide();
        }
    }
}
