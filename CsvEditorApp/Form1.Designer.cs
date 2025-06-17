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
        /// <param name="disposing">マネージド リソースを破棄する場合は true、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // デザイナーコンポーネントの解放
            }
            base.Dispose(disposing);  // ベースクラスの Dispose を呼び出し
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            // テキスト編集用の TextBox を生成
            this.txtEditor = new System.Windows.Forms.TextBox();
            // CSV表示用の DataGridView を生成
            this.dgvCsv = new System.Windows.Forms.DataGridView();
            // CSV読み込みボタンを生成
            this.btnLoadCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsv)).BeginInit();
            this.SuspendLayout();

            // 
            // txtEditor
            // 
            // テキストボックスをフォーム上部にアンカー設定
            this.txtEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditor.Location = new System.Drawing.Point(12, 41);
            this.txtEditor.Multiline = true; // 複数行入力を許可
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(760, 51);
            this.txtEditor.TabIndex = 0;
            // テキスト変更時に呼び出すイベントハンドラの登録
            this.txtEditor.TextChanged += new System.EventHandler(this.txtEditor_TextChanged);

            // 
            // dgvCsv
            // 
            // DataGridView をフォーム中央にアンカー設定
            this.dgvCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsv.Location = new System.Drawing.Point(12, 98);
            this.dgvCsv.Name = "dgvCsv";
            this.dgvCsv.RowTemplate.Height = 21;
            this.dgvCsv.Size = new System.Drawing.Size(760, 350);
            this.dgvCsv.TabIndex = 1;
            this.dgvCsv.VirtualMode = true; // 仮想モードで高速表示
            // セル値提供イベント
            this.dgvCsv.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvCsv_CellValueNeeded);
            // 行番号描画イベント
            this.dgvCsv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCsv_RowPostPaint);
            // セルクリックイベント
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
            // クリック時のイベントハンドラ登録
            this.btnLoadCsv.Click += new System.EventHandler(this.btnLoadCsv_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 461); // フォームサイズ設定
            // コントロールをフォームに追加
            this.Controls.Add(this.btnLoadCsv);
            this.Controls.Add(this.dgvCsv);
            this.Controls.Add(this.txtEditor);
            this.Name = "Form1";
            this.Text = "CSV Editor"; // フォームタイトル
            // フォームロード時のイベントハンドラ登録
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // フォーム上の UI 要素
        private System.Windows.Forms.TextBox txtEditor;
        private System.Windows.Forms.DataGridView dgvCsv;
        private System.Windows.Forms.Button btnLoadCsv;
    }
}
