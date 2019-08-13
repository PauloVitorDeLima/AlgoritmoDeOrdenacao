namespace AlgoritmosDeOrdenacao
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BubbleSort = new System.Windows.Forms.Button();
            this.SelectionSort = new System.Windows.Forms.Button();
            this.InsertionSort = new System.Windows.Forms.Button();
            this.QuickSort = new System.Windows.Forms.Button();
            this.MergeSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BubbleSort
            // 
            this.BubbleSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BubbleSort.Location = new System.Drawing.Point(35, 37);
            this.BubbleSort.Name = "BubbleSort";
            this.BubbleSort.Size = new System.Drawing.Size(135, 45);
            this.BubbleSort.TabIndex = 0;
            this.BubbleSort.Text = "Bubble Sort";
            this.BubbleSort.UseVisualStyleBackColor = true;
            this.BubbleSort.Click += new System.EventHandler(this.BubbleSort_Click);
            // 
            // SelectionSort
            // 
            this.SelectionSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SelectionSort.Location = new System.Drawing.Point(392, 37);
            this.SelectionSort.Name = "SelectionSort";
            this.SelectionSort.Size = new System.Drawing.Size(135, 45);
            this.SelectionSort.TabIndex = 1;
            this.SelectionSort.Text = "Selection Sort";
            this.SelectionSort.UseVisualStyleBackColor = true;
            this.SelectionSort.Click += new System.EventHandler(this.SelectionSort_Click);
            // 
            // InsertionSort
            // 
            this.InsertionSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.InsertionSort.Location = new System.Drawing.Point(35, 153);
            this.InsertionSort.Name = "InsertionSort";
            this.InsertionSort.Size = new System.Drawing.Size(135, 45);
            this.InsertionSort.TabIndex = 2;
            this.InsertionSort.Text = "Insertion Sort";
            this.InsertionSort.UseVisualStyleBackColor = true;
            this.InsertionSort.Click += new System.EventHandler(this.InsertionSort_Click);
            // 
            // QuickSort
            // 
            this.QuickSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.QuickSort.Location = new System.Drawing.Point(392, 153);
            this.QuickSort.Name = "QuickSort";
            this.QuickSort.Size = new System.Drawing.Size(135, 45);
            this.QuickSort.TabIndex = 3;
            this.QuickSort.Text = "Quick Sort";
            this.QuickSort.UseVisualStyleBackColor = true;
            this.QuickSort.Click += new System.EventHandler(this.QuickSort_Click);
            // 
            // MergeSort
            // 
            this.MergeSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MergeSort.Location = new System.Drawing.Point(225, 246);
            this.MergeSort.Name = "MergeSort";
            this.MergeSort.Size = new System.Drawing.Size(135, 45);
            this.MergeSort.TabIndex = 4;
            this.MergeSort.Text = "Merge Sort";
            this.MergeSort.UseVisualStyleBackColor = true;
            this.MergeSort.Click += new System.EventHandler(this.MergeSort_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 312);
            this.Controls.Add(this.MergeSort);
            this.Controls.Add(this.QuickSort);
            this.Controls.Add(this.InsertionSort);
            this.Controls.Add(this.SelectionSort);
            this.Controls.Add(this.BubbleSort);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BubbleSort;
        private System.Windows.Forms.Button SelectionSort;
        private System.Windows.Forms.Button InsertionSort;
        private System.Windows.Forms.Button QuickSort;
        private System.Windows.Forms.Button MergeSort;
    }
}

