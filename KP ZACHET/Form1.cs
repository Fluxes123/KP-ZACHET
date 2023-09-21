using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using Newtonsoft.Json;

namespace KP_ZACHET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Brush b;
        Pen p;

        public bool editorOpened = false;
        Graphics g;
        public List<krug> rects = new List<krug>();
        public List<kvadrat> elps = new List<kvadrat>();
        public List<Figure> figs = new List<Figure>();
        float dx, dy;
        Random rnd = new Random();
        List<CheckBox> chek1 = new List<CheckBox>();
        List<CheckBox> chek2 = new List<CheckBox>();
        List<CheckBox> chek3 = new List<CheckBox>();
        List<Tractor> list2 = new List<Tractor>();
        Editor editor;

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            timer1.Start();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Figure i in figs)
                i.Draw(e.Graphics);
        }
        public void Addmove(Figure t)
        {
            if (t is Tractor)
            {
                Tractor t1 = (Tractor)t;
                if (t1.move)
                {
                    list2.Add((Tractor)t);
                }
                else { list2.Remove((Tractor)t); }
            }
        }
        private void ch1_Cheked(object sender, EventArgs e)
        {
            CheckBox chek = (CheckBox)sender;
            int n = 0;
            foreach (Figure i in figs)
            {
                if (i is krug)
                {
                    if (n < (chek.Location.X - numericUpDown1.Location.X - numericUpDown1.Width) / 20)
                        n++;
                    else
                    {
                        i.ChangeEnable();
                        i.entered = false;
                        break;
                    }
                }
            }
            Refresh();
        }
        private void ch2_Cheked(object sender, EventArgs e)
        {
            CheckBox chek = (CheckBox)sender;
            int n = 0;
            foreach (Figure i in figs)
            {
                if (i is kvadrat)
                {
                    if (n < (chek.Location.X - numericUpDown2.Location.X - numericUpDown2.Width) / 20)
                        n++;
                    else
                    {
                        i.ChangeEnable();
                        i.entered = false;
                        break;
                    }
                }
            }
            Refresh();
        }
        private void ch3_Cheked(object sender, EventArgs e)
        {
            CheckBox chek = (CheckBox)sender;
            int n = 0;
            foreach (Figure i in figs)
            {
                if (i is Tractor)
                {
                    if (n < (chek.Location.X - numericUpDown3.Location.X - numericUpDown3.Width) / 20)
                        n++;
                    else
                    {
                        i.ChangeEnable();
                        i.entered = false;
                        break;
                    }
                }
            }
            Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {


            int n = 0;
            for (int i = 0; i < figs.Count(); i++)
                if (figs[i] is krug)
                {
                    if (n < numericUpDown1.Value)
                        n++;
                    else
                    {
                        figs.RemoveAt(i);
                        Controls.Remove(chek1[chek1.Count() - 1]);
                        chek1.RemoveAt(chek1.Count() - 1);
                    }
                }
            if (n < numericUpDown1.Value)
                for (int i = 0; i < numericUpDown1.Value - n; i++)
                {
                    foreach (Figure j in figs)
                        j.entered = false;
                    int g = rnd.Next(20, 250);
                    Figure a = new krug(rnd.Next(Width - 100), rnd.Next(Height - 100), g, g, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                    figs.Add(a);
                    CheckBox ch1 = new CheckBox();
                    ch1.Width = 20;
                    ch1.Location = new Point(numericUpDown1.Location.X + numericUpDown1.Width + (chek1.Count()) * 20, numericUpDown1.Location.Y);
                    ch1.Checked = true;
                    ch1.CheckedChanged += new EventHandler(ch1_Cheked);
                    Controls.Add(ch1);
                    chek1.Add(ch1);
                }
            Refresh();

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {


            int n = 0;
            for (int i = 0; i < figs.Count(); i++)
                if (figs[i] is kvadrat)
                {
                    if (n < numericUpDown2.Value)
                        n++;
                    else
                    {
                        figs.RemoveAt(i);
                        Controls.Remove(chek2[chek2.Count() - 1]);
                        chek2.RemoveAt(chek2.Count() - 1);
                    }
                }
            if (n < numericUpDown2.Value)
                for (int i = 0; i < numericUpDown2.Value - n; i++)
                {
                    foreach (Figure j in figs)
                        j.entered = false;
                    int g = rnd.Next(20, 250);
                    Figure a = new kvadrat(rnd.Next(Width - 100), rnd.Next(Height - 100), g, g, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                    figs.Add(a);
                    CheckBox ch2 = new CheckBox();
                    ch2.Width = 20;
                    ch2.Location = new Point(numericUpDown2.Location.X + numericUpDown2.Width + (chek2.Count()) * 20, numericUpDown2.Location.Y);
                    ch2.Checked = true;
                    ch2.CheckedChanged += new EventHandler(ch2_Cheked);
                    Controls.Add(ch2);
                    chek2.Add(ch2);
                }
            Refresh();

        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Figure i in figs)
                    if (i.entered == true)
                    {
                        i.Move(e.X - dx, e.Y - dy);
                        break;
                    }
            }
            Refresh();
        }
        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {

            int n = 0;
            for (int i = 0; i < figs.Count(); i++)
                if (figs[i] is Tractor)
                {
                    if (n < numericUpDown3.Value)
                        n++;
                    else
                    {
                        figs.RemoveAt(i);
                        Controls.Remove(chek3[chek3.Count() - 1]);
                        chek3.RemoveAt(chek3.Count() - 1);
                    }
                }
            if (n < numericUpDown3.Value)
                for (int i = 0; i < numericUpDown3.Value - n; i++)
                {
                    foreach (Figure j in figs)
                        j.entered = false;
                    Figure a = new Tractor(rnd.Next(Width - 100), rnd.Next(Height - 100), rnd.Next(200, 250), rnd.Next(100, 250), Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
                    figs.Add(a);
                    CheckBox ch3 = new CheckBox();
                    ch3.Width = 20;
                    ch3.Location = new Point(numericUpDown3.Location.X + numericUpDown3.Width + (chek3.Count()) * 20, numericUpDown3.Location.Y);
                    ch3.Checked = true;
                    ch3.CheckedChanged += new EventHandler(ch3_Cheked);
                    Controls.Add(ch3);
                    chek3.Add(ch3);
                }
            Refresh();

        }

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool f = false;
                for (int i = figs.Count() - 1; i >= 0; i--)
                    if (figs[i].Inside(e.X, e.Y) && !f && figs[i].enabled == true)
                    {
                        figs[i].entered = true;
                        dx = e.X - figs[i].X;
                        dy = e.Y - figs[i].Y;
                        f = true;
                    }
                    else
                        figs[i].entered = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (editorOpened)
                {
                    for (int i = figs.Count() - 1; i >= 0; i--)
                    {
                        if (figs[i].Inside(e.X, e.Y) && figs[i].enabled == true)
                        {
                            editor.newElement(figs[i]);
                            editor.Refresh();
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = figs.Count() - 1; i >= 0; i--)
                        if (figs[i].Inside(e.X, e.Y) && figs[i].enabled == true)
                        {
                            editor = new Editor(this);
                            editor.newElement(figs[i]);
                            editor.Show();
                            editorOpened = true;
                            break;
                        }

                }
            }
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var fg in figs) { Addmove(fg);}


            foreach (Tractor t2 in list2)
            {
                Refresh();
                t2.moveToRectangle(20);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}








