using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildWorld
{
    class WaterField : Field
    {
        public int A, B, An, Bn;

        public override bool isPointIn(PointF point)
        {
        // checks if points is in field
            double x = point.X, y = point.Y;

            double x1 = border[0].X, y1 = border[0].Y;
            double x2 = border[1].X, y2 = border[1].Y;
            double x3 = border[2].X, y3 = border[2].Y;

            double a = ((y2 - y3) * (x - x3) + (x3 - x2) * (y - y3)) / ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
            double b = ((y3 - y1) * (x - x3) + (x1 - x3) * (y - y3)) / ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
            double c = 1 - a - b;

            if (a >= 0 && a <= 1 && b >= 0 && b <= 1 && c >= 0 && c <= 1) return true;
            else return false;
        }

        public WaterField(Logger log, string name, Point[] points, EarthField earthField) : base(log, name, points)
        {
            try {
                if ((border[0].X == 0 && border[1].Y == 0) || (border[1].X == 0 && border[0].Y == 0))
                    border = new Point[] { border[0], border[1], new Point(0, 0) };
                if ((border[0].X == 0 && border[1].Y == earthField.height) || (border[1].X == 0 && border[0].Y == earthField.height))
                    border = new Point[] { border[0], border[1], new Point(0, earthField.height) };
                if ((border[0].X == earthField.width && border[1].Y == 0) || (border[1].X == earthField.width && border[0].Y == 0))
                    border = new Point[] { border[0], border[1], new Point(earthField.width, 0) };
                if ((border[0].X == earthField.width && border[1].Y == earthField.height) || (border[1].X == earthField.width && border[0].Y == earthField.height))
                    border = new Point[] { border[0], border[1], new Point(earthField.width, earthField.height) };
                if (border.Length == 2)
                    throw new Exception();  
                A = border[1].Y - border[0].Y;
                B = border[0].X - border[1].X;
                An = border[1].X - border[0].X;
                Bn = border[1].Y - border[0].Y;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong coords!");
            }
        }
    }
}