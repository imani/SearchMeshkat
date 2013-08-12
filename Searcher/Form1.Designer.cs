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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.pnlCheckbox = new System.Windows.Forms.Panel();
            this.pageNavigator1 = new DevComponents.DotNetBar.Controls.PageNavigator();
            this.cmb_Sort = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.pagelabel = new System.Windows.Forms.Label();
            this.lblRPP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPhrase = new System.Windows.Forms.Button();
            this.btnAnd = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnXor = new System.Windows.Forms.Button();
            this.btnRoot = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.highlighter1.SetHighlightColor(this.txt_search, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
            this.highlighter1.SetHighlightOnFocus(this.txt_search, true);
            this.txt_search.Location = new System.Drawing.Point(12, 32);
            this.txt_search.Name = "txt_search";
            this.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_search.Size = new System.Drawing.Size(385, 28);
            this.txt_search.TabIndex = 0;
            this.txt_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("2  Karim", 12F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(403, 32);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(107, 28);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "بیاب";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_analyzed
            // 
            this.txt_analyzed.Font = new System.Drawing.Font("B Nazanin", 8.75F);
            this.txt_analyzed.Location = new System.Drawing.Point(156, 128);
            this.txt_analyzed.Name = "txt_analyzed";
            this.txt_analyzed.ReadOnly = true;
            this.txt_analyzed.Size = new System.Drawing.Size(300, 25);
            this.txt_analyzed.TabIndex = 3;
            // 
            // panelEx1
            // 
            this.panelEx1.AutoScroll = true;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Font = new System.Drawing.Font("B Zar", 10F);
            this.highlighter1.SetHighlightColor(this.panelEx1, DevComponents.DotNetBar.Validator.eHighlightColor.Green);
            this.panelEx1.Location = new System.Drawing.Point(12, 159);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelEx1.Size = new System.Drawing.Size(444, 390);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 8;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX1.Location = new System.Drawing.Point(627, 97);
            this.labelX1.Name = "labelX1";
            this.labelX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX1.Size = new System.Drawing.Size(135, 27);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "جستجو در ...";
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // pnlCheckbox
            // 
            this.pnlCheckbox.AutoScroll = true;
            this.highlighter1.SetHighlightColor(this.pnlCheckbox, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            this.pnlCheckbox.Location = new System.Drawing.Point(479, 130);
            this.pnlCheckbox.Name = "pnlCheckbox";
            this.pnlCheckbox.Size = new System.Drawing.Size(283, 428);
            this.pnlCheckbox.TabIndex = 7;
            // 
            // pageNavigator1
            // 
            // 
            // 
            // 
            this.pageNavigator1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageNavigator1.Location = new System.Drawing.Point(15, 555);
            this.pageNavigator1.Name = "pageNavigator1";
            this.pageNavigator1.NextPageTooltip = "صفحه بعد";
            this.pageNavigator1.PreviousPageTooltip = "صفحه قبل";
            this.pageNavigator1.Size = new System.Drawing.Size(444, 17);
            this.pageNavigator1.TabIndex = 0;
            this.pageNavigator1.Text = "pageNavigator1";
            // 
            // cmb_Sort
            // 
            this.cmb_Sort.DisplayMember = "Text";
            this.cmb_Sort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Sort.FormattingEnabled = true;
            this.cmb_Sort.ItemHeight = 18;
            this.cmb_Sort.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmb_Sort.Location = new System.Drawing.Point(479, 67);
            this.cmb_Sort.Name = "cmb_Sort";
            this.cmb_Sort.Size = new System.Drawing.Size(121, 24);
            this.cmb_Sort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Sort.TabIndex = 10;
            this.cmb_Sort.SelectedIndexChanged += new System.EventHandler(this.cmb_Sort_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.FontSize = 10F;
            this.comboItem1.Text = "شباهت";
            // 
            // comboItem2
            // 
            this.comboItem2.FontSize = 10F;
            this.comboItem2.Text = "کتاب";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("B Nazanin", 12.25F, System.Drawing.FontStyle.Bold);
            this.labelX2.Location = new System.Drawing.Point(606, 64);
            this.labelX2.Name = "labelX2";
            this.labelX2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX2.Size = new System.Drawing.Size(122, 27);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = "مرتب سازی بر اساس";
            // 
            // pagelabel
            // 
            this.pagelabel.Location = new System.Drawing.Point(175, 556);
            this.pagelabel.Name = "pagelabel";
            this.pagelabel.Size = new System.Drawing.Size(139, 16);
            this.pagelabel.TabIndex = 12;
            // 
            // lblRPP
            // 
            this.lblRPP.Location = new System.Drawing.Point(12, 132);
            this.lblRPP.Name = "lblRPP";
            this.lblRPP.Size = new System.Drawing.Size(138, 17);
            this.lblRPP.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "کوئری";
            // 
            // btnPhrase
            // 
            this.btnPhrase.Location = new System.Drawing.Point(15, 66);
            this.btnPhrase.Name = "btnPhrase";
            this.btnPhrase.Size = new System.Drawing.Size(57, 23);
            this.btnPhrase.TabIndex = 21;
            this.btnPhrase.Text = "عبارت";
            this.btnPhrase.UseVisualStyleBackColor = true;
            this.btnPhrase.Click += new System.EventHandler(this.btnPhrase_Click);
            // 
            // btnAnd
            // 
            this.btnAnd.Location = new System.Drawing.Point(172, 66);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(57, 23);
            this.btnAnd.TabIndex = 24;
            this.btnAnd.Text = "باید باشد";
            this.btnAnd.UseVisualStyleBackColor = true;
            this.btnAnd.Click += new System.EventHandler(this.btnAnd_Click);
            // 
            // btnOr
            // 
            this.btnOr.Location = new System.Drawing.Point(251, 66);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(57, 23);
            this.btnOr.TabIndex = 27;
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnNot
            // 
            this.btnNot.Location = new System.Drawing.Point(329, 66);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(57, 23);
            this.btnNot.TabIndex = 28;
            this.btnNot.Text = "نباید باشد";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnXor
            // 
            this.btnXor.Location = new System.Drawing.Point(15, 95);
            this.btnXor.Name = "btnXor";
            this.btnXor.Size = new System.Drawing.Size(57, 23);
            this.btnXor.TabIndex = 29;
            this.btnXor.Text = "XOR";
            this.btnXor.UseVisualStyleBackColor = true;
            this.btnXor.Click += new System.EventHandler(this.btnXor_Click);
            // 
            // btnRoot
            // 
            this.btnRoot.Location = new System.Drawing.Point(90, 95);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(57, 23);
            this.btnRoot.TabIndex = 30;
            this.btnRoot.Text = "ریشه";
            this.btnRoot.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(172, 95);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(57, 23);
            this.button8.TabIndex = 31;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(251, 95);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(57, 23);
            this.button9.TabIndex = 32;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(329, 95);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(57, 23);
            this.button10.TabIndex = 33;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "فاصله",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(90, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(57, 25);
            this.comboBox1.TabIndex = 34;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 576);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.btnRoot);
            this.Controls.Add(this.btnXor);
            this.Controls.Add(this.btnNot);
            this.Controls.Add(this.btnOr);
            this.Controls.Add(this.btnAnd);
            this.Controls.Add(this.btnPhrase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRPP);
            this.Controls.Add(this.pagelabel);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cmb_Sort);
            this.Controls.Add(this.pageNavigator1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.pnlCheckbox);
            this.Controls.Add(this.txt_analyzed);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Font = new System.Drawing.Font("B Nazanin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "موتور جستجو مشکات";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_analyzed;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private System.Windows.Forms.Panel pnlCheckbox;
        private DevComponents.DotNetBar.Controls.PageNavigator pageNavigator1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_Sort;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private System.Windows.Forms.Label pagelabel;
        private System.Windows.Forms.Label lblRPP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnRoot;
        private System.Windows.Forms.Button btnXor;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Button btnAnd;
        private System.Windows.Forms.Button btnPhrase;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

