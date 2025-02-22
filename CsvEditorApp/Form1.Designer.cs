using System;
using System.Drawing;
using System.Windows.Forms;

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

        // フォームの読み込み時に呼ばれるイベント
        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridViewにフォントを設定
            dgvCsv.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 10);

        }

        // DataGridViewでセルがクリックされたときに呼ばれるイベント
        private void dgvCsv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DataGridViewで選択されたセルがある場合
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // 選択されたセルの内容をTextBoxに表示
                txtEditor.Text = dgvCsv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? string.Empty;
            }
        }


        // TextBoxの内容が変更されたときに呼ばれるイベント
        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            // DataGridViewで選択されているセルがある場合
            if (dgvCsv.SelectedCells.Count > 0)
            {
                // 最初に選択されているセルを取得
                DataGridViewCell selectedCell = dgvCsv.SelectedCells[0];

                // テキストボックスの内容をセルに反映
                selectedCell.Value = txtEditor.Text;
            }
        }

        // Displayボタンがクリックされたときのイベント
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // 必要に応じて処理を追加
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
            this.txtEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEditor.Location = new System.Drawing.Point(0, 0);
            this.txtEditor.Margin = new System.Windows.Forms.Padding(0);
            this.txtEditor.Multiline = true;
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(888, 46);
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
            this.dgvCsv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCsv_RowPostPaint);
            // 
            // btnLoadCsv
            // 
            this.btnLoadCsv.Location = new System.Drawing.Point(0, 49);
            this.btnLoadCsv.Name = "btnLoadCsv";
            this.btnLoadCsv.Size = new System.Drawing.Size(105, 23);
            this.btnLoadCsv.TabIndex = 4;
            this.btnLoadCsv.Text = "CSV読込";
            this.btnLoadCsv.UseVisualStyleBackColor = true;
            this.btnLoadCsv.Click += new System.EventHandler(this.btnLoadCsv_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(127, 49);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 5;
            this.btnDisplay.Text = "表示";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 532);
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
    }
}