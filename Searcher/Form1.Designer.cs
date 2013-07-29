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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.SuspendLayout();
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.highlighter1.SetHighlightColor(this.txt_search, DevComponents.DotNetBar.Validator.eHighlightColor.Orange);
            this.highlighter1.SetHighlightOnFocus(this.txt_search, true);
            this.txt_search.Location = new System.Drawing.Point(93, 19);
            this.txt_search.Name = "txt_search";
            this.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_search.Size = new System.Drawing.Size(277, 28);
            this.txt_search.TabIndex = 0;
            this.txt_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("2  Karim", 14F, System.Drawing.FontStyle.Bold);
            this.btn_search.Location = new System.Drawing.Point(12, 15);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 44);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "بیاب";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_analyzed
            // 
            this.txt_analyzed.Font = new System.Drawing.Font("B Nazanin", 8.75F);
            this.txt_analyzed.Location = new System.Drawing.Point(93, 77);
            this.txt_analyzed.Name = "txt_analyzed";
            this.txt_analyzed.ReadOnly = true;
            this.txt_analyzed.Size = new System.Drawing.Size(277, 25);
            this.txt_analyzed.TabIndex = 3;
            // 
            // panelEx1
            // 
            this.panelEx1.AutoScroll = true;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Font = new System.Drawing.Font("B Zar", 10F);
            this.highlighter1.SetHighlightColor(this.panelEx1, DevComponents.DotNetBar.Validator.eHighlightColor.Green);
            this.panelEx1.Location = new System.Drawing.Point(12, 119);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelEx1.Size = new System.Drawing.Size(358, 372);
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
            this.labelX1.Location = new System.Drawing.Point(524, 44);
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
            this.pnlCheckbox.Location = new System.Drawing.Point(376, 77);
            this.pnlCheckbox.Name = "pnlCheckbox";
            this.pnlCheckbox.Size = new System.Drawing.Size(283, 432);
            this.pnlCheckbox.TabIndex = 7;
            // 
            // pageNavigator1
            // 
            // 
            // 
            // 
            this.pageNavigator1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageNavigator1.Location = new System.Drawing.Point(12, 492);
            this.pageNavigator1.Name = "pageNavigator1";
            this.pageNavigator1.NextPageTooltip = "صفحه بعد";
            this.pageNavigator1.PreviousPageTooltip = "صفحه قبل";
            this.pageNavigator1.Size = new System.Drawing.Size(358, 17);
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
            this.cmb_Sort.Location = new System.Drawing.Point(376, 19);
            this.cmb_Sort.Name = "cmb_Sort";
            this.cmb_Sort.Size = new System.Drawing.Size(121, 24);
            this.cmb_Sort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Sort.TabIndex = 10;
            this.cmb_Sort.SelectedIndexChanged += new System.EventHandler(this.cmb_Sort_SelectedIndexChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("B Nazanin", 12.25F, System.Drawing.FontStyle.Bold);
            this.labelX2.Location = new System.Drawing.Point(500, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX2.Size = new System.Drawing.Size(122, 27);
            this.labelX2.TabIndex = 11;
            this.labelX2.Text = "مرتب سازی بر اساس";
           
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 521);
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
    }
}

