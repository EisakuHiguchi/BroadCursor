using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace broadcursor
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // フォームと表示させたいテキストと
            BroadCursor bc = new BroadCursor(this, "active");
            // カーソルで動かしたいコントロールを渡すだけ
            bc.addControl(monthCalendar1);
            bc.addControl(listBox1);
            bc.addControl(textBox1);
            bc.addControl(button1);
            
        }
    }
}
