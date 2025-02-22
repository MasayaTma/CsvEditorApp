namespace CsvEditorApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtEditor = new System.Windows.Forms.TextBox();
            this.dgvCsv = new System.Windows.Forms.DataGridView();
            this.btnLoadCsv = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnSaveCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsv)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtEditor
            // 
            this.txtEditor.Location = new System.Drawing.Point(0, 23);
            this.txtEditor.Margin = new System.Windows.Forms.Padding(0);
            this.txtEditor.Multiline = true;
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(888, 509);
            this.txtEditor.TabIndex = 2;
            this.txtEditor.TextChanged += new System.EventHandler(this.txtEditor_TextChanged);
            // 
            // dgvCsv
            // 
            this.dgvCsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCsv.Location = new System.Drawing.Point(0, 78);
            this.dgvCsv.Name = "dgvCsv";
            this.dgvCsv.RowTemplate.Height = 21;
            this.dgvCsv.Size = new System.Drawing.Size(888, 454);
            this.dgvCsv.TabIndex = 3;
            // 
            // btnLoadCsv
            // 
            this.btnLoadCsv.Location = new System.Drawing.Point(0, 2);
            this.btnLoadCsv.Name = "btnLoadCsv";
            this.btnLoadCsv.Size = new System.Drawing.Size(105, 23);
            this.btnLoadCsv.TabIndex = 4;
            this.btnLoadCsv.Text = "CSV読込";
            this.btnLoadCsv.UseVisualStyleBackColor = true;
            this.btnLoadCsv.Click += new System.EventHandler(this.btnLoadCsv_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(111, 2);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 5;
            this.btnDisplay.Text = "表示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnSaveCsv
            // 
            this.btnSaveCsv.Location = new System.Drawing.Point(192, 2);
            this.btnSaveCsv.Name = "btnSaveCsv";
            this.btnSaveCsv.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCsv.TabIndex = 6;
            this.btnSaveCsv.Text = "保存";
            this.btnSaveCsv.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 532);
            this.Controls.Add(this.btnSaveCsv);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnLoadCsv);
            this.Controls.Add(this.dgvCsv);
            this.Controls.Add(this.txtEditor);
            this.Name = "Form1";
            this.Text = "CSV Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtEditor;
        private System.Windows.Forms.DataGridView dgvCsv;
        private System.Windows.Forms.Button btnLoadCsv;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnSaveCsv;
    }
}
