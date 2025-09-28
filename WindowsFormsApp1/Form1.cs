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
            ofd.InitialDirectory = @"C:\";
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
            ofd.InitialDirectory = @"C:\";
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
    }
}
