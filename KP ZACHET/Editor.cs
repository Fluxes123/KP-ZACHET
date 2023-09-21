using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KP_ZACHET
{
    public partial class Editor : Form
    {
        bool rep = true;
        public bool move = false;
        public Form1 form;
        Figure figure;
        Graphics g;
        public Editor(Form1 f)
        {
            InitializeComponent();
            form = f;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (rep)
            {
                if (figure is Tractor && numericUpDown1.Value > numericUpDown2.Value * 2)
                    numericUpDown1.Value = numericUpDown2.Value * 2;
                if (figure is Tractor && numericUpDown1.Value < numericUpDown2.Value * 9 / 10)
                    numericUpDown1.Value = numericUpDown2.Value * 9 / 10;
                figure.ChangeWidth((float)numericUpDown1.Value);
                Refresh();
                form.Refresh();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (rep)
            {
                if (figure is Tractor && numericUpDown1.Value > numericUpDown2.Value * 2)
                    numericUpDown2.Value = numericUpDown1.Value / 2;
                if (figure is Tractor && numericUpDown1.Value < numericUpDown2.Value * 9 / 10)
                    numericUpDown2.Value = numericUpDown1.Value * 10 / 9;
                figure.ChangeHeight((float)numericUpDown2.Value);
                Refresh();
                form.Refresh();
            }
        }

        public void newElement(Figure e)
        {
            rep = false;
            figure = e;
            numericUpDown1.Value = (decimal)figure.W;
            numericUpDown2.Value = (decimal)figure.H;
            rep = true;
        }

        private void Editor_MouseClick(object sender, MouseEventArgs e)
        {
            if (figure is Tractor)
            {
                Tractor trac = (Tractor)figure;
                for (int j = 3; j >= 0; j--)
                    if (trac.parts[j].Inside(e.X - Width / 2 + trac.W / 2 + trac.X, e.Y - Height / 2 + figure.H + trac.Y))
                    {
                        ColorDialog cd = new ColorDialog();
                        if (cd.ShowDialog() == DialogResult.OK)
                        {
                            trac.colors[j] = cd.Color;
                            trac.parts[j].SetC = cd.Color;
                            trac.parts[j].SetB = new SolidBrush(cd.Color);
                            trac.parts[j].SetP = new Pen(Color.FromArgb(cd.Color.A, 0xFF - cd.Color.R, 0xFF - cd.Color.G, 0xFF - cd.Color.B), 5);
                        }

                        Refresh();
                        form.Refresh();
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                figure.ChangeColor(cd.Color);
            Refresh();
            form.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (figure is Tractor)
            {
                Tractor t2 = (Tractor)figure;
                t2.move = !t2.move;
            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            Refresh();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                figure.ChangeColor(cd.Color);
            Refresh();
            form.Refresh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (figure is Tractor)
            {
                Tractor t2 = (Tractor)figure;
                t2.move = !t2.move;
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if (rep)
            {
                if (figure is Tractor && numericUpDown1.Value > numericUpDown2.Value * 2)
                    numericUpDown1.Value = numericUpDown2.Value * 2;
                if (figure is Tractor && numericUpDown1.Value < numericUpDown2.Value * 9 / 10)
                    numericUpDown1.Value = numericUpDown2.Value * 9 / 10;
                figure.ChangeWidth((float)numericUpDown1.Value);
                Refresh();
                form.Refresh();
            }
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            if (rep)
            {
                if (figure is Tractor && numericUpDown1.Value > numericUpDown2.Value * 2)
                    numericUpDown2.Value = numericUpDown1.Value / 2;
                if (figure is Tractor && numericUpDown1.Value < numericUpDown2.Value * 9 / 10)
                    numericUpDown2.Value = numericUpDown1.Value * 10 / 9;
                figure.ChangeHeight((float)numericUpDown2.Value);
                Refresh();
                form.Refresh();
            }
        }

        private void Editor_Paint_1(object sender, PaintEventArgs e)
        {

            figure.Draw3(e.Graphics);
        }

        private void Editor_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            form.editorOpened = false;
        }
    }
}
