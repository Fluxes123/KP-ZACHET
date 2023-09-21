using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KP_ZACHET
{
    public class kvadrat : Figure
    {
        public kvadrat(float ax, float ay, float aw, float ah, Color color):base(ax, ay, aw, ah, color)
        {
            x = ax;
            y = ay;
            w = aw;
            h = ah;
            entered = true;
        }
        public override bool Inside(float x, float y)
        {
            return (x > this.x && x < this.x + w && y > this.y && y < this.y + h);            
        }
        public override void Draw1(Graphics g)
        {
            g.FillEllipse(b, x, y, w, h);
            g.DrawEllipse(p, x, y, w, h);
        }
        public override void Draw2(Graphics g)
        {
            g.FillEllipse(b, x, y, w, h);
            
        }
        public override void DrawEditor(Graphics g, float ax, float ay)
        {
            g.FillEllipse(b, ax, ay, w, h);
        }
        public override void Redraw(Graphics g, float ax, float ay, Figure e)
        {
            g.FillEllipse(b, x - e.X + ax, y - e.Y + ay, w, h);
           
        }
    }
}
