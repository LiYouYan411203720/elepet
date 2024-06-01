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
using System.Reflection;

namespace elepet
{
    public partial class Form1 : Form
    {
        private int hunger = 50;
        private int time = 0;
        private Timer timer;
        private DateTime startTime;
        private Label lblElapsedTime;
        private Label lblPetSpeech;
        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }
        private void InitializeControls()
        {
            // 初始化控制項
            timer = new Timer();

            // 設定控制項屬性
            label1.Text = "你的寵物飢餓指數：50";
            label4.Text = "請餵我!!!";
            timer.Interval = 1000; // 1秒


            // 添加事件處理器
            timer.Tick += timerUpdate_Tick;

            // 啟動計時器
            timer.Start();
        }
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            // 每秒更新寵物狀態
            hunger -= 1;
            time += 1;
            UpdatePetStatus();
            TimeSpan elapsedTime = DateTime.Now - startTime;
            label2.Text = $"現在時間: {elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}";
            if (hunger <= 0)
            {
                timer.Stop();
                if (time >= 50 && time < 70) { MessageBox.Show($"遊戲結束！您的寵物存活了{time}秒\n它在世上的意義是什麼?"); }
                if (time >= 70 && time < 90) { MessageBox.Show($"遊戲結束！您的寵物存活了{time}秒\n嗯嗯!有沒有感覺電腦舒服些啦?"); }
                if (time >= 90 && time < 120) { MessageBox.Show($"遊戲結束！您的寵物存活了{time}秒\n哇!你的存貨還不少ㄟ!!"); }
                if (time >= 120 && time < 150) { MessageBox.Show($"遊戲結束！您的寵物存活了{time}秒\n值得嘉獎的成績!!被你餵得飽飽的!"); }
                if (time >= 150) { MessageBox.Show($"遊戲結束！您的寵物存活了{time}秒\n感謝款待!你應該沒有餵我很重要的東西吧:D"); }
                Close(); // 關閉應用程式
            }
        }
        private void UpdatePetStatus()
        {
            label1.Text = $"你的寵物飢餓指數：{hunger}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 寵物被餵食
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "選擇要餵給寵物的文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 模擬寵物吃文件的過程
                    string filePath = openFileDialog.FileName;
                    File.Delete(filePath);
                    hunger += 10; // 增加飽足感
                    string[] phrases = new string[]
                       { "呼嚕...好滿足呀！","太美味了，謝謝你！","我還想要更多！","這是我最喜歡的！","你是最好的主人！","這真是口感天堂！"};
                    Random random = new Random();
                    int index = random.Next(phrases.Length);
                    label4.Text = phrases[index]; // 更新標籤文字
                    MessageBox.Show("寵物已經吃掉了文件！");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"無法刪除文件：{ex.Message}");
                }
                // 寵物被餵食
                UpdatePetStatus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
