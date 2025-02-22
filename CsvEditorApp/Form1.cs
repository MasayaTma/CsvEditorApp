using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsvEditorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                string fileContent = await Task.Run(() => File.ReadAllText(filePath));

                // 読み込んだ内容をテキストボックスに表示
                txtEditor.Text = fileContent;

                // CSVデータをDataGridViewに表示
                await Task.Run(() => DisplayCsvData(fileContent));
            }
        }

        // 表示ボタン: TextBoxの内容をカンマ区切りでDataGridViewに表示
        private async void btnDisplay_Click(object sender, EventArgs e)
        {
            await Task.Run(() => DisplayCsvData(txtEditor.Text));
        }

        // CSVデータをDataGridViewに表示する共通メソッド
        private void DisplayCsvData(string csvContent)
        {
            string[] lines = csvContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            DataGridView dataGridView = dgvCsv;

            // UIスレッドをブロックしないようにする
            dataGridView.Invoke(new Action(() =>
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                // 列の追加（最初の行にカラム名を設定）
                if (lines.Length > 0)
                {
                    string[] columns = lines[0].Split(',');

                    foreach (var column in columns)
                    {
                        dataGridView.Columns.Add(column.Trim(), column.Trim());
                    }

                    // 行の追加（最初の行はヘッダーとして、2行目以降をデータとして追加）
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] rowValues = lines[i].Split(',');

                        // 空白行は無視
                        if (rowValues.Length == 0 || string.IsNullOrWhiteSpace(string.Join("", rowValues)))
                        {
                            continue;
                        }

                        dataGridView.Rows.Add(rowValues);
                    }
                }

                // 列幅の自動調整
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }));
        }

        // テキストボックスに選択したセルの値を表示
        private void dgvCsv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCsv.SelectedCells.Count > 0)
            {
                txtEditor.Text = dgvCsv.SelectedCells[0].Value?.ToString();
            }
        }

        // テキストボックスの内容が変更されたときにDataGridViewのセルを更新
        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            if (dgvCsv.SelectedCells.Count > 0)
            {
                dgvCsv.SelectedCells[0].Value = txtEditor.Text;
            }
        }

        // 変更内容をCSVファイルとして保存するボタン
        private void btnSaveCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                SaveCsvData(filePath);
            }
        }

        // DataGridViewの内容をCSV形式で保存
        private void SaveCsvData(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // ヘッダー行を追加
            for (int i = 0; i < dgvCsv.Columns.Count; i++)
            {
                csvContent.Append(dgvCsv.Columns[i].HeaderText);
                if (i < dgvCsv.Columns.Count - 1) csvContent.Append(",");
            }
            csvContent.AppendLine();

            // データ行を追加
            foreach (DataGridViewRow row in dgvCsv.Rows)
            {
                for (int i = 0; i < dgvCsv.Columns.Count; i++)
                {
                    csvContent.Append(row.Cells[i].Value?.ToString());
                    if (i < dgvCsv.Columns.Count - 1) csvContent.Append(",");
                }
                csvContent.AppendLine();
            }

            // ファイルに書き込む
            File.WriteAllText(filePath, csvContent.ToString());
        }

        // フォーム読み込み時に設定する処理
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCsv.SelectionChanged += dgvCsv_SelectionChanged;
        }
    }
}
　