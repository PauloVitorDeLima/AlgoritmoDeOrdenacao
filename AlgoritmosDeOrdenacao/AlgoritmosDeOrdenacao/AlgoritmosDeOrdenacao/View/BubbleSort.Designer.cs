namespace AlgoritmosDeOrdenacao.View
{
    partial class BubbleSort
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
            this.SelectFile = new System.Windows.Forms.Button();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.RichTxtBxValores = new System.Windows.Forms.RichTextBox();
            this.ButtonMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(12, 12);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(148, 44);
            this.SelectFile.TabIndex = 0;
            this.SelectFile.Text = "Selecionar arquivo";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // TxtPath
            // 
            this.TxtPath.Location = new System.Drawing.Point(12, 73);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.ReadOnly = true;
            this.TxtPath.Size = new System.Drawing.Size(532, 20);
            this.TxtPath.TabIndex = 2;
            // 
            // RichTxtBxValores
            // 
            this.RichTxtBxValores.Location = new System.Drawing.Point(12, 110);
            this.RichTxtBxValores.Name = "RichTxtBxValores";
            this.RichTxtBxValores.Size = new System.Drawing.Size(532, 341);
            this.RichTxtBxValores.TabIndex = 3;
            this.RichTxtBxValores.Text = "";
            // 
            // ButtonMenu
            // 
            this.ButtonMenu.Location = new System.Drawing.Point(396, 12);
            this.ButtonMenu.Name = "ButtonMenu";
            this.ButtonMenu.Size = new System.Drawing.Size(148, 44);
            this.ButtonMenu.TabIndex = 8;
            this.ButtonMenu.Text = "Voltar ao Menu";
            this.ButtonMenu.UseVisualStyleBackColor = true;
            this.ButtonMenu.Click += new System.EventHandler(this.ButtonMenu_Click);
            // 
            // BubbleSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 463);
            this.Controls.Add(this.ButtonMenu);
            this.Controls.Add(this.RichTxtBxValores);
            this.Controls.Add(this.TxtPath);
            this.Controls.Add(this.SelectFile);
            this.Name = "BubbleSort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BubbleSort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.RichTextBox RichTxtBxValores;
        private System.Windows.Forms.Button ButtonMenu;
    }
}