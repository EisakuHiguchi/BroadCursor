using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace broadcursor
{
    class BroadCursor
    {
        List<Control> XItems;
        List<Control> YItems;
        int cursorindex = 0;

        Form1 f;
        Label cl = new Label();

        public BroadCursor(Form1 form, string text)
        {
            f = form;
            cl.Text = text;
            f.Controls.Add(cl);

            XItems = new List<Control>();
            YItems = new List<Control>();
        }

        public void addControl(Control c)
        {
            c.KeyUp += new KeyEventHandler(Control_KeyUp);
            c.Leave += new EventHandler(Control_Leave);
            addXYControl(c);
        }

        public void addXYControl(Control c)
        {
            XItems.Add(c);
            YItems.Add(c);

            // 一つずつ追加するのでこれでソートできるはず。
            // ソートについては甘々の可能性あり

            foreach(Control e in XItems)
            {
                if(e.Location.X > c.Location.X) XItems.Insert(XItems.IndexOf(e) - 1,c);
            }

            foreach (Control e in YItems)
            {
                if (e.Location.Y > c.Location.Y) YItems.Insert(YItems.IndexOf(e) - 1, c);
            }
        }

        public void addControl(List<Control> c)
        {
            foreach(Control e in c) addControl(c);
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            Point loc = f.ActiveControl.Location;
            cl.Location = new Point(loc.X, loc.Y - 10);
        }

        protected void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.Left) move(XItems, -1);
                else if (e.KeyCode == Keys.Right) move(XItems, 1);
                else if (e.KeyCode == Keys.Up) move(YItems, -1);
                else if (e.KeyCode == Keys.Down) move(YItems, 1);
            }
        }

        private void checkIndex()
        {
            if (cursorindex > XItems.Count - 1) cursorindex = 0;
            else if (cursorindex < 0) cursorindex = XItems.Count - 1;
        }

        private void move(List<Control> c, int move)
        {
            cursorindex = c.IndexOf(f.ActiveControl) + move;
            checkIndex();
            f.ActiveControl = c[cursorindex];
        }

    }
}
