using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using fractals;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ClientSize = new Size(500, 500);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var polynom = new Polynom(2, new Complex(-0.1, 0.1));
            foreach (var complex in FractalGen.getFractalComplexes(polynom))
            {
                var point = GetScreenCoords(complex, 2);
                var brush = new SolidBrush(Color.Black);
                graphics.FillEllipse(brush, point.X, point.Y, 3, 3);
            }
        }

        private Point GetScreenCoords(Complex complex, double border)
        {
            var x = (complex.Real + border) / (2 * border) * ClientSize.Width;
            var y = (complex.Imaginary + border) / (2 * border) * ClientSize.Height;
            return new Point((int)x, (int)y);
        }
    }
}
