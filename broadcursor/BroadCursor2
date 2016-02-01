using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace broadcursor
{
    class BroadCursor
    {
        List<Control> XItems;
        List<Control> YItems;
        int cursorindex = 0;

        Control activecontrol;
        Label cl;

        public BroadCursor(Canvas canvas)
        {
            cl = new Label();
            cl.Content = "activate";
            canvas.Children.Add(cl);

            XItems = new List<Control>();
            YItems = new List<Control>();
        }

        public void addControl(Control c)
        {
            c.KeyUp += new KeyEventHandler(Control_KeyUp);
            c.GotFocus += new RoutedEventHandler(Control_Focused);
            
            addXYControl(c);
            setActiveControl(c);
        }

        public void setActiveControl(Control c)
        {
            activecontrol = c;
            c.Focus();
        }

        public void addXYControl(Control c)
        {
            XItems.Add(c);
            YItems.Add(c);

            // 一つずつ追加するのでこれでソートできるはず。
            // ソートについては甘々の可能性あり

            foreach (Control e in XItems)
            {
                int index = XItems.IndexOf(e) - 1;
                if(index < 0) index = 0;
                if (Canvas.GetLeft(e) > Canvas.GetLeft(c))
                {
                    XItems.Insert(index, c);
                    break;
                }
            }

            foreach (Control e in YItems)
            {
                int index = YItems.IndexOf(e) - 1;
                if (index < 0) index = 0;
                if (Canvas.GetBottom(e) > Canvas.GetBottom(c))
                {
                    YItems.Insert(index, c);
                    break;
                }
            }
        }

        public void addControl(List<Control> c)
        {
            foreach (Control e in c) addControl(c);
        }

        private void Control_Focused(object sender, EventArgs e)
        {       
            activecontrol = (Control)sender;
            Canvas.SetLeft(cl, Canvas.GetLeft(activecontrol));
            Canvas.SetTop(cl, Canvas.GetTop(activecontrol) - 20);
        }

        protected void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.SystemKey == Key.Left) move(XItems, -1);
            else if (e.SystemKey == Key.Right) move(XItems, 1);
            else if (e.SystemKey == Key.Up) move(YItems, -1);
            else if (e.SystemKey == Key.Down) move(YItems, 1);
        }

        private void checkIndex(List<Control> c)
        {
            if (cursorindex > c.Count - 1) cursorindex = 0;
            else if (cursorindex < 0) cursorindex = c.Count - 1;
        }

        private void move(List<Control> c, int move)
        {
            cursorindex = c.IndexOf(activecontrol) + move;
            checkIndex(c);
            activecontrol = c[cursorindex];
            activecontrol.Focus();
        }

    }
}
