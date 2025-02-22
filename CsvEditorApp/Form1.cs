using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CsvEditorApp
{
    public partial class Form1 : Form
    {
        private string[] csvLines;
        private bool isRowNumberDrawn = false;  // 行番号が描画されたかどうかを示すフラグ

        public Form1()
        {
            InitializeComponent();
            dgvCsv.VirtualMode = true;
            dgvCsv.CellValueNeeded += DgvCsv_CellValueNeeded;

            // 行番号の描画イベントを追加
            dgvCsv.RowPostPaint += dgvCsv_RowPostPaint;
        }

        // CSVファイルを読み込むボタン
        private async void btnLoadCsv_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを開く
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // 非同期でCSVの内容を読み込み
                csvLines = await Task.Run(() => File.ReadAllLines(filePath));

                // DataGridViewの行数を設定（仮想モードで管理する行数）
                dgvCsv.RowCount = csvLines.Length;

                // 列の設定（CSVの1行目を列名にする場合）
                string[] columns = csvLines[0].Split(',');
                dgvCsv.ColumnCount = columns.Length;

                // 列名の設定
                for (int i = 0; i < columns.Length; i++)
                {
                    dgvCsv.Columns[i].HeaderText = columns[i].Trim();
                }

                // プログレスバーの更新処理など
            }
        }

        // VirtualModeのCellValueNeededイベントハンドラ
        private void DgvCsv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            // 行と列を取得して、仮想的にデータを提供
            if (e.RowIndex < csvLines.Length)
            {
                string[] row = csvLines[e.RowIndex].Split(',');

                // 必要なセルの値を設定
                e.Value = row[e.ColumnIndex].Trim();
            }
        }

        // 行番号の描画を最初の1回だけ行うイベント
        private void dgvCsv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // もし行番号が既に描画されたなら、それ以上は描画しない
            if (isRowNumberDrawn)
            {
                return;
            }

            // 行番号を1から始める
            int rowIndex = e.RowIndex + 1;

            // 行ヘッダーの矩形領域を取得
            var rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvCsv.RowHeadersWidth, e.RowBounds.Height);

            using (var graphics = e.Graphics)
            {
                // フォントを指定（例: Consolas, サイズ10）
                var font = new Font("Consolas", 10);
                var brush = Brushes.Black;

                // 行番号を描画
                graphics.DrawString(rowIndex.ToString(), font, brush, rect, StringFormat.GenericDefault);
            }

            // 行番号を描画したことを示すフラグを設定
            isRowNumberDrawn = true;
        }

        // 保存処理や他の機能は省略（元のコードを参考にしてください）
    }
}

