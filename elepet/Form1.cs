using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elepet
{
    public partial class Form1 : Form
    {
        private int hunger = 100;
        private Label lblHunger;
        private Button btnFeed;
        private Timer timerUpdate;
        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }
        private void InitializeControls()
        {
            // 初始化控制項
            timerUpdate = new Timer();

            // 設定控制項屬性
            label1.Text = "飢餓：100";
            timerUpdate.Interval = 1000; // 1秒


            // 添加事件處理器
            timerUpdate.Tick += timerUpdate_Tick;

            // 啟動計時器
            timerUpdate.Start();
        }
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            // 每秒更新寵物狀態
            hunger -= 1;
            UpdatePetStatus();
        }
        private void UpdatePetStatus()
        {
            label1.Text = $"飢餓：{hunger}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 寵物被餵食
            hunger += 10;
            UpdatePetStatus();
        }
    }
}
