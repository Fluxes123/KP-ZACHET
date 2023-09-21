using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KP_ZACHET
{
    public class krug : Figure
    {

        public krug(float x, float y, float width, float height, Color color) : base(x, y, width, height, color)
        {           
            w = width;
            h = height;            
            this.color = color;
            entered = true;
        }       
        public override void Draw1(Graphics g)
        {
            g.FillRectangle(b, x, y, w, h);
            g.DrawRectangle(p, x, y, w, h);
        }
        public override void DrawEditor(Graphics g, float ax, float ay)
        {
            g.FillRectangle(b, ax, ay, w, h);
        }
        public override void Redraw(Graphics g, float ax, float ay, Figure e)
        {
            g.FillRectangle(b, x - e.X + ax, y - e.Y + ay, w, h);
            
        }
        public override void Draw2(Graphics g)
        {
            g.FillRectangle(b, x, y, w, h);
            
        }
        public override bool Inside(float x, float y)
        {           
            return (x > this.x && x < this.x + w && y > this.y && y < this.y + h);
        }
        
    }
}
