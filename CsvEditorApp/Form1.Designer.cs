using System;
using System.Windows.Forms;
using System.Drawing;

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
            this.txtEditor = new System.Windows.Forms.TextBox();
            this.dgvCsv = new System.Windows.Forms.DataGridView();
            this.btnLoadCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEditor
            // 
            this.txtEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditor.Location = new System.Drawing.Point(12, 41);
            this.txtEditor.Multiline = true;
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(760, 51);
            this.txtEditor.TabIndex = 0;
            this.txtEditor.TextChanged += new System.EventHandler(this.txtEditor_TextChanged);
            // 
            // dgvCsv
            // 
            this.dgvCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsv.Location = new System.Drawing.Point(12, 98);
            this.dgvCsv.Name = "dgvCsv";
            this.dgvCsv.RowTemplate.Height = 21;
            this.dgvCsv.Size = new System.Drawing.Size(760, 350);
            this.dgvCsv.TabIndex = 1;
            this.dgvCsv.VirtualMode = true;
            this.dgvCsv.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvCsv_CellValueNeeded);
            this.dgvCsv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCsv_RowPostPaint);
            this.dgvCsv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCsv_CellClick);
            // 
            // btnLoadCsv
            // 
            this.btnLoadCsv.Location = new System.Drawing.Point(12, 12);
            this.btnLoadCsv.Name = "btnLoadCsv";
            this.btnLoadCsv.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCsv.TabIndex = 2;
            this.btnLoadCsv.Text = "CSV読込";
            this.btnLoadCsv.UseVisualStyleBackColor = true;
            this.btnLoadCsv.Click += new System.EventHandler(this.btnLoadCsv_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
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

        private System.Windows.Forms.TextBox txtEditor;
        private System.Windows.Forms.DataGridView dgvCsv;
        private System.Windows.Forms.Button btnLoadCsv;
    }
}
