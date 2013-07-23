namespace Searcher
{
    partial class Form1
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
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.txt_analyzed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("B Yekan", 11F);
            this.txt_search.Location = new System.Drawing.Point(158, 15);
            this.txt_search.Name = "txt_search";
            this.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_search.Size = new System.Drawing.Size(431, 30);
            this.txt_search.TabIndex = 0;
            this.txt_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("B Yekan", 12F);
            this.btn_search.Location = new System.Drawing.Point(57, 8);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 34);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "بیاب";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_result
            // 
            this.txt_result.Font = new System.Drawing.Font("B Yekan", 8.25F);
            this.txt_result.Location = new System.Drawing.Point(27, 139);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ReadOnly = true;
            this.txt_result.Size = new System.Drawing.Size(562, 402);
            this.txt_result.TabIndex = 2;
            this.txt_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_analyzed
            // 
            this.txt_analyzed.Location = new System.Drawing.Point(158, 64);
            this.txt_analyzed.Name = "txt_analyzed";
            this.txt_analyzed.Size = new System.Drawing.Size(429, 20);
            this.txt_analyzed.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 553);
            this.Controls.Add(this.txt_analyzed);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.TextBox txt_analyzed;
    }
}

