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
            this.txt_analyzed = new System.Windows.Forms.TextBox();
            this.pnlCheckbox = new System.Windows.Forms.Panel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.SuspendLayout();
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("B Yekan", 11F);
            this.txt_search.Location = new System.Drawing.Point(158, 15);
            this.txt_search.Name = "txt_search";
            this.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_search.Size = new System.Drawing.Size(212, 30);
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
            // txt_analyzed
            // 
            this.txt_analyzed.Location = new System.Drawing.Point(158, 64);
            this.txt_analyzed.Name = "txt_analyzed";
            this.txt_analyzed.Size = new System.Drawing.Size(212, 20);
            this.txt_analyzed.TabIndex = 3;
            // 
            // pnlCheckbox
            // 
            this.pnlCheckbox.AutoScroll = true;
            this.pnlCheckbox.Location = new System.Drawing.Point(376, 50);
            this.pnlCheckbox.Name = "pnlCheckbox";
            this.pnlCheckbox.Size = new System.Drawing.Size(220, 325);
            this.pnlCheckbox.TabIndex = 7;
            // 
            // panelEx1
            // 
            this.panelEx1.AutoScroll = true;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Font = new System.Drawing.Font("B Zar", 9.25F);
            this.panelEx1.Location = new System.Drawing.Point(12, 91);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelEx1.Size = new System.Drawing.Size(348, 284);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 399);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.pnlCheckbox);
            this.Controls.Add(this.txt_analyzed);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_analyzed;
        private System.Windows.Forms.Panel pnlCheckbox;
        private DevComponents.DotNetBar.PanelEx panelEx1;
    }
}

