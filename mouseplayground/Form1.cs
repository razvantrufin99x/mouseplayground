using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mouseplayground
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Graphics g;
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            moveCursor();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X % 20 <=2) && (e.Y %  20 <= 2))
            {
                Text = "e in grila";
                g.DrawEllipse(new Pen(Color.Red, 2), e.X , e.Y , 5, 5);
            }
            else
            {
                Text = " nu este in grila ERROR";
                
            }

        }

        private void moveCursor()
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point( Cursor.Position.X -20, Cursor.Position.Y -20);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }
        public void drawGrila()
        {
            for (int i = 0; i < Width; i += 20)
            {
                for (int j = 0; j < Height; j += 20)
                {
                    g.DrawLine(new Pen(Color.Gray), 0, j, i, j);
                    g.DrawLine(new Pen(Color.Gray), i, 0, i, j);
                }
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            drawGrila();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
        }
    }
}
