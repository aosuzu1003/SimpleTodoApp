using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.IO;

namespace SimpleTodoApp
{
    public partial class Form1 : Form
    {
        //タスクを格納するリスト
        List<string> tasks = new List<string>();
        //タスクを管理するテキストファイル
        string filePath = "tasks.txt";

        public Form1()
        {
            InitializeComponent();
            LoadTasks();
        }

        //テキストファイルからタスクを読み込む
        private void LoadTasks()
        {
            //テキストファイルが存在したら
            if (File.Exists(filePath))
            {
                //テキストファイルの内容をリストに格納
                tasks.AddRange(File.ReadAllLines(filePath));
                //タスクリストの内容をリストボックスに追加
                listBoxTasks.Items.AddRange(tasks.ToArray());
            }
        }

        //追加ボタン押下時
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //テキストボックスが空以外なら
            if (!string.IsNullOrWhiteSpace(textBoxTask.Text))
            {
                //テキストボックスの内容をリストに格納
                tasks.Add(textBoxTask.Text);
                //タスクボックスの内容をリストボックスに追加
                listBoxTasks.Items.Add(textBoxTask.Text);
                //テキストボックスをクリアする
                textBoxTask.Clear();
                //ファイルを保存する
                File.WriteAllLines(filePath, tasks);
            }
        }

        //削除ボタン押下時
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //リストボックス内のアイテムが選択されていたら
            if (listBoxTasks.SelectedItem != null)
            {
                //リストから選択中のアイテムを削除
                tasks.Remove(listBoxTasks.SelectedItem.ToString());
                //リストボックスから選択中のアイテムを削除
                listBoxTasks.Items.Remove(listBoxTasks.SelectedItem);
                //ファイルを保存
                File.WriteAllLines(filePath, tasks);
            }
        }
    }
}
