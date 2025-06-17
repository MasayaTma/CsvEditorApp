using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CsvEditorApp
{
    public partial class Form1 : Form
    {
        // CSVデータを保持するリスト
        private List<string[]> csvData = new List<string[]>();

        public Form1()
        {
            InitializeComponent(); // WinForm の初期化

            // DataGridView を仮想モードで動作させ、必要なイベントハンドラを登録
            dgvCsv.VirtualMode = true;                     // 大量データでも高速表示
            dgvCsv.CellValueNeeded += dgvCsv_CellValueNeeded; // セルの値を遅延供給
            dgvCsv.RowPostPaint += dgvCsv_RowPostPaint;       // 行番号描画
            dgvCsv.CellClick += dgvCsv_CellClick;             // セルクリック時の処理
        }

        // フォームロード時の初期化処理
        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView のフォント設定
            dgvCsv.DefaultCellStyle.Font = new Font("Consolas", 10);
        }

        // [CSV読み込み] ボタン押下時のイベント
        private async void btnLoadCsv_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを表示
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSVファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    // 非同期で CSV を読み込む
                    await LoadCsvAsync(filePath);
                }
            }
        }

        // 非同期で CSV ファイルを読み込むメソッド
        private async Task LoadCsvAsync(string filePath)
        {
            csvData.Clear(); // 既存データをクリア

            using (var reader = new StreamReader(filePath))
            {
                // ヘッダー行を読み込む
                string headerLine = await reader.ReadLineAsync();
                string[] headers = headerLine.Split(',');

                // UI スレッドで列ヘッダーを設定
                Invoke(new Action(() =>
                {
                    dgvCsv.ColumnCount = headers.Length;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dgvCsv.Columns[i].HeaderText = headers[i].Trim();
                    }
                }));

                // データ行を 1 行ずつ読み込む
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] fields = line.Split(',');
                    csvData.Add(fields); // リストに追加
                }
            }

            // UI スレッドで行数を設定
            Invoke(new Action(() =>
            {
                dgvCsv.RowCount = csvData.Count;
            }));
        }

        // 仮想モード時にセルの値を提供するイベント
        private void dgvCsv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < csvData.Count)
            {
                string[] row = csvData[e.RowIndex];
                if (e.ColumnIndex >= 0 && e.ColumnIndex < row.Length)
                {
                    e.Value = row[e.ColumnIndex]; // セルに表示する値を設定
                }
            }
        }

        // 行番号を行ヘッダーに描画するイベント
        private void dgvCsv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int rowNumber = e.RowIndex + 1; // 行番号は 1 始まり
            var rect = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                dgvCsv.RowHeadersWidth,
                e.RowBounds.Height);

            // 行ヘッダー部分にテキスト描画
            TextRenderer.DrawText(
                e.Graphics,
                rowNumber.ToString(),
                dgvCsv.RowHeadersDefaultCellStyle.Font,
                rect,
                dgvCsv.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        // セルクリック時に選択セルの値を TextBox に表示
        private void dgvCsv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtEditor.Text = dgvCsv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? string.Empty;
            }
        }

        // TextBox の内容が変わったときに CSV データも更新
        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            if (dgvCsv.CurrentCell != null)
            {
                int rowIndex = dgvCsv.CurrentCell.RowIndex;
                int colIndex = dgvCsv.CurrentCell.ColumnIndex;

                if (rowIndex >= 0 && rowIndex < csvData.Count)
                {
                    // リスト内のデータを更新し、セルを再描画
                    csvData[rowIndex][colIndex] = txtEditor.Text;
                    dgvCsv.InvalidateCell(colIndex, rowIndex);
                }
            }
        }
    }
}
