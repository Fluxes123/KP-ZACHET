using KP_ZACHET;
using System.Drawing;
using System.Xml.Linq;

public class Tractor : Figure
{
    public bool move = false;
    float w,h;
    float lastX, lastY;
    public Figure[] parts = new Figure[4];
    public Color[] colors = new Color[4];

    public Tractor( float ax, float ay, float aw, float ah, Color ac) : base( ax, ay, aw, ah, ac)
    {
        Color c = ac;
        h = ah;
        w = aw;
        for (int i = 0; i < 4; i++)
            colors[i] = c;
        parts[0] = new krug (x + w / 4, y, w * 3 / 8, h / 3,c);
        parts[1] = new krug (x + w / 4, y + h / 3, w * 3 / 4, h / 3, c);
        parts[2] = new kvadrat( x, y + h / 3, h * 2 / 3, h * 2 / 3,  c);
        parts[3] = new kvadrat( x + w * 3 / 4, y + h * 2 / 3, h / 3, h / 3,  c);
        lastX = ax;
        lastY = ay;
    }
    public override void ChangeColor(Color ac)
    {
        color = ac;
        for (int i = 0; i < 4; i++)
        {
            colors[i] = color;
            parts[i].SetC = color;
            parts[i].SetB = new SolidBrush(color);
            parts[i].SetP = new Pen(Color.FromArgb(color.A, 0xFF - color.R, 0xFF - color.G, 0xFF - color.B), 5);
        }
    }
    public override void ChangeEnable()
    {
        if (enabled)
        {
            enabled = false;
            for (int i = 0; i < 4; i++)
            {
                parts[i].SetC = Color.FromArgb(100, colors[i]);
                parts[i].SetB = new SolidBrush(Color.FromArgb(100, colors[i]));
            }
        }
        else
        {
            enabled = true;
            for (int i = 0; i < 4; i++)
            {
                parts[i].SetC = colors[i];
                parts[i].SetB = new SolidBrush(colors[i]);
            }
        }
    }
    public override void ChangeWidth(float aw)
    {
        w = aw;
        parts[0] = new krug(x + aw / 4, y, aw * 3 / 8, h / 3, colors[0]);
        parts[1] = new krug( x + aw / 4, y + h / 3, aw * 3 / 4, h / 3, colors[1]);
        parts[2] = new kvadrat(x, y + h / 3, h * 2 / 3, h * 2 / 3, colors[2]);
        parts[3] = new kvadrat(x + aw * 3 / 4, y + h * 2 / 3, h / 3, h / 3, colors[3]);
    }
    public override void ChangeHeight(float ah)
    {
        h = ah;
        parts[0] = new krug( x + w / 4, y, w * 3 / 8, ah / 3, colors[0]);
        parts[1] = new krug(x + w / 4, y + ah / 3, w * 3 / 4, ah / 3, colors[1]);
        parts[2] = new kvadrat( x, y + ah / 3, ah * 2 / 3, ah * 2 / 3, colors[2]);
        parts[3] = new kvadrat( x + w * 3 / 4, y + ah * 2 / 3, ah / 3, ah / 3, colors[3]);
    }
    public override bool Inside(float ax, float ay)
    {
        foreach (Figure i in parts)
            if (i.Inside(ax, ay))
                return true;
        return false;
    }
    int i = 0;
    public void moveToRectangle(int dx)
    {
        float tx = x;
        float ty = y;
        if (i < 10)
        {
            Move(x + dx, y);
            i++;
        }
        else if (i < 20 && i > 9)
        {
            Move(x, y + dx);
            i++;
        }
        else if (i < 30 && i > 19)
        {
            Move(x - dx, y);
            i++;
        }
        else if (i < 40 && i > 29)
        {
            Move(x, y - dx);
            i++;
        }
        else if (i >= 39)
        {
            i = 0;
            x = tx; y = ty;

        }
       
    }
    public override void Move(float ax, float ay)
    {
        x = ax;
        y = ay;
        parts[0].SetX = ax + w / 4;
        parts[1].SetX = ax + w / 4;
        parts[2].SetX = ax;
        parts[3].SetX = ax + w * 3 / 4;
        parts[0].SetY = ay;
        parts[1].SetY = ay + h / 3;
        parts[2].SetY = ay + h / 3;
        parts[3].SetY = ay + h * 2 / 3;
    }
    public override void Draw1(Graphics g)
    {
        foreach (Figure i in parts)
            i.Draw1(g);
    }
    public override void Draw2(Graphics g)
    {
        foreach (Figure i in parts)
            i.Draw2(g);
    }
    public override void DrawEditor(Graphics g, float ax, float ay)
    {
        foreach (Figure i in parts)
            i.Redraw(g, ax, ay, this);
    }

}

