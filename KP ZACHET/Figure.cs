using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KP_ZACHET
{
    public class Figure
    {
        public bool entered;
        public bool enabled;
        public float x;
        public float y;
        public float w;
        public float h;
        public Color color;
        public Pen p;
        public Brush b;
        public float SetX { set => x = value; }
        public float X => x;
        public float SetY { set => y = value; }
        public float Y => y;
        public float W => w;
        public float H => h;
        public Color C => color;
        public Color SetC { set => color = value; }
        public Brush B => b;
        public Brush SetB { set => b = value; }
        public Pen P => p;
        public Pen SetP { set => p = value; }
        public Figure( float ax, float ay, float aw, float ah, Color ac)
        {
            color = ac;
            b = new SolidBrush(color);
            p = new Pen(Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B), 5);
            x = ax;
            y = ay;
            w = aw;
            h = ah;
            entered = true;
            enabled = true;
        }

        public virtual void ChangeWidth(float aw)
        {
            w = aw;
        }
        public virtual void ChangeHeight(float ah)
        {
            h = ah;
        }
        public virtual void Move(float ax, float ay)
        {
            x = ax;
            y = ay;
        }
        public virtual void ChangeColor(Color ac)
        {
            

            color = ac;
            b = new SolidBrush(color);
            p = new Pen(Color.FromArgb(color.A,255-color.R,255-color.G,255-color.B),5);

        }
        public virtual void ChangeEnable()
        {
            if (enabled)
            {
                enabled = false;
                b = new SolidBrush(Color.FromArgb(100, color));
            }
            else
            {
                enabled = true;
                b = new SolidBrush(color);
            }
        }
        
        public virtual void Draw(Graphics g)
        {
            if (entered)
                Draw1(g);  
            else 
                DrawEditor(g,x,y);
        }
       
        public virtual bool Inside(float ax,float ay) 
        { 
            return false; 
        }
        public virtual void Draw1(Graphics g) 
        {
        }
        public virtual void Draw2(Graphics g) 
        { 
        }
        public virtual void Draw3(Graphics g)
        {           
            DrawEditor(g, 250, 10);
        }
        public virtual void DrawEditor(Graphics g, float ax, float ay) 
        { 
        }
        public virtual void Redraw(Graphics g, float ax, float ay, Figure e) 
        { 
        }
    }
}
