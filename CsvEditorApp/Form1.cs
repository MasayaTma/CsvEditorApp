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
        private List<string[]> csvData = new List<string[]>();  // CSVデータを保持するリスト

        public Form1()
        {
            InitializeComponent();

            // DataGridViewの設定
            dgvCsv.VirtualMode = true;
            dgvCsv.CellValueNeeded += dgvCsv_CellValueNeeded;
            dgvCsv.RowPostPaint += dgvCsv_RowPostPaint;  // メソッド名を正しく記述
            dgvCsv.CellClick += dgvCsv_CellClick;
        }

        // フォームのLoadイベントハンドラを追加
        private void Form1_Load(object sender, EventArgs e)
        {
            // 必要な初期化処理をここに記述します
            // 例：フォントやスタイルの設定など
            dgvCsv.DefaultCellStyle.Font = new Font("Consolas", 10);
        }

        // CSVファイルを読み込むボタンのクリックイベント
        private async void btnLoadCsv_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを表示
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSVファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // 非同期でCSVデータを読み込み
                await LoadCsvAsync(filePath);
            }
        }

        // CSVデータを読み込むメソッド
        private async Task LoadCsvAsync(string filePath)
        {
            csvData.Clear();

            using (var reader = new StreamReader(filePath))
            {
                // ヘッダーを読み込み
                string headerLine = await reader.ReadLineAsync();
                string[] headers = headerLine.Split(',');

                // DataGridViewの列設定
                Invoke(new Action(() =>
                {
                    dgvCsv.ColumnCount = headers.Length;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dgvCsv.Columns[i].HeaderText = headers[i].Trim();
                    }
                }));

                // データ行を読み込み
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] fields = line.Split(',');
                    csvData.Add(fields);
                }
            }

            // 行数を設定
            Invoke(new Action(() =>
            {
                dgvCsv.RowCount = csvData.Count;
            }));
        }

        // DataGridViewの仮想モードでセルの値を提供
        private void dgvCsv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < csvData.Count)
            {
                string[] row = csvData[e.RowIndex];
                if (e.ColumnIndex >= 0 && e.ColumnIndex < row.Length)
                {
                    e.Value = row[e.ColumnIndex];
                }
            }
        }

        // 行番号を描画するイベントハンドラ
        private void dgvCsv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 行番号を計算
            int rowNumber = e.RowIndex + 1;

            // 行ヘッダーの描画
            var rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgvCsv.RowHeadersWidth, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, rowNumber.ToString(), dgvCsv.RowHeadersDefaultCellStyle.Font, rect, dgvCsv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        // セルがクリックされたときに呼ばれるイベント
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
            if (dgvCsv.CurrentCell != null)
            {
                int rowIndex = dgvCsv.CurrentCell.RowIndex;
                int colIndex = dgvCsv.CurrentCell.ColumnIndex;

                if (rowIndex >= 0 && rowIndex < csvData.Count)
                {
                    csvData[rowIndex][colIndex] = txtEditor.Text;
                    dgvCsv.InvalidateCell(colIndex, rowIndex);
                }
            }
        }
    }
}
