using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 入力側「参照」ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, EventArgs e)
        {
            //ダイアログボックスのインスタンスを生成
            OpenFileDialog ofd = new OpenFileDialog();

            //ダイアログボックスのプロパティ設定
            ofd.Title = "入力ファイルを選択してください。";
            ofd.InitialDirectory = @"C:\Users\warab\source\repos\WindowsFormsApp1\testData";
            ofd.Filter = "text(*.txt)|*.txt";

            //ファイル選択ダイアログボックス表示
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = ofd.FileName;
            }
            else
            {
                txtInput.Text = "";
            }
        }

        /// <summary>
        /// 出力側「参照」ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutput_Click(object sender, EventArgs e)
        {
            //ダイアログボックスのインスタンスを生成
            SaveFileDialog ofd = new SaveFileDialog();

            //ダイアログボックスのプロパティ設定
            ofd.Title = "出力ファイルを選択してください。";
            ofd.InitialDirectory = @"C:\Users\warab\source\repos\WindowsFormsApp1\testData";
            ofd.Filter = "text(*.txt)|*.txt";

            //ファイル選択ダイアログボックス表示
            if ( ofd.ShowDialog() == DialogResult.OK )
            {
                txtOutput.Text = ofd.FileName;
            }
            else
            {
                txtOutput.Text = "";
            }
        }

        /// <summary>
        /// 「実行」ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click_1(object sender, EventArgs e)
        {
            //入力ファイル及び出力ファイルの選択状況をチェック
            if (txtInput.Text == "" || txtOutput.Text == "")
            {
                MessageBox.Show("入力ファイルまたは出力ファイルが選択されていません。");
                return;
            }
            //◆◆◆　メイン処理　◆◆◆
            //
            //入出力ファイルがが共に指定された場合、入力ファイルを開く
            Encoding encoding_SJIS = Encoding.GetEncoding("Shift_JIS");
            int rcdCnt = 0;
            using (StreamReader sr = new StreamReader(txtInput.Text, encoding_SJIS))
            using (StreamWriter sw = new StreamWriter(txtOutput.Text, false, encoding_SJIS))
            {
                //インプットファイルを1行ずつ読み込む
                while (sr.Peek() >= 0)
                {
                    //データを読み込む
                    string inpData = sr.ReadLine();

                    //年齢が15歳以上のデータのみ、出力ファイルに出力する
                    //※年齢は、入力出たの15桁目から3桁にセットされている
                    //該当位置に不詳（VVV）が含まれる場合があるため、15歳以上かどうか判定する前に除外する
                    if (inpData.Substring(14, 3) == "VVV")
                    {
                        //不詳のため処理なし
                    }
                    else
                    {
                        if (Convert.ToInt32(inpData.Substring(14, 3)) >= 15)
                        {
                            //15歳以上のレコード数のカウント
                            rcdCnt += 1;

                            //出力ファイルに書き込む
                            sw.WriteLine(inpData);
                        }
                    }
                }
            }

            //全てのレコードを処理し終わったら対象となったレコード件数をメッセージで表示
            MessageBox.Show("15歳以上のレコード数は「" + rcdCnt.ToString() + "」件でした。");
        }

        /// <summary>
        /// 「終了」ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click_1(object sender, EventArgs e)
        {
            //フォームを閉じる
            this.Close();
        }
    }
}
