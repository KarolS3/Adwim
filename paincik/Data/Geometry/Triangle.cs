using OopPaint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPaint.Data.Geometry
{
    internal class Triangle : FigureToDrawBase, IDescribable, IRightClickable

    {
        public float BaseWidth { get; set; }
        public float Height { get; set; }
        private PointF _p1 => Location;
        private PointF _p2 => new(Location.X + BaseWidth, Location.Y);
        private PointF _p3 => new(Location.X, Location.Y + Height);
        public override double GetPerimeter()
        {
            var side = Math.Sqrt(Math.Pow(BaseWidth, 2.0) + Math.Pow(Height, 2.0));
            return BaseWidth + 2.0 * side;
        }
        public override double GetArea() => 0.5 * BaseWidth * Height;

        public override void DrawOnCanvas(Graphics g)
        {
            using (var brush = new SolidBrush(FillingColor))
            {
                using (var pen = new Pen(BorderColor, 2))
                {
                    var points = new[] { _p1, _p2, _p3 };
                    g.FillPolygon(brush, points);
                    g.DrawPolygon(pen, points);

                    var bounds = RectangleF.FromLTRB(
                        Math.Min(Math.Min(_p1.X, _p2.X), _p3.X),
                        Math.Min(Math.Min(_p1.Y, _p2.Y), _p3.Y),
                        Math.Max(Math.Max(_p1.X, _p2.X), _p3.X),
                        Math.Max(Math.Max(_p1.Y, _p2.Y), _p3.Y));

                    DrawInnerText(g, bounds);
                }
            }
        }
        public override PointF GetCenter()
        {
            return new PointF((_p1.X + _p2.X + _p3.X) / 3f, (_p1.Y + _p2.Y + _p3.Y) / 3f);
        }
        private float TriangleArea(PointF a, PointF b, PointF c)
        {
            return Math.Abs((a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2.0f);
        }
        public override bool ContainsPoint(PointF p)
        {
            float area = TriangleArea(_p1, _p2, _p3);
            float a1 = TriangleArea(p, _p2, _p3);
            float a2 = TriangleArea(_p1, p, _p3);
            float a3 = TriangleArea(_p1, _p2, p);

            return Math.Abs(area - (a1 + a2 + a3)) <= 0.5f;
        }
        public string GetDescription()
        {
            return $"Trójkąt o podstawie {BaseWidth:0.#} i wysokości {Height:0.#}, " + $"środek ciężkości w ({GetCenter().X:0.#}, {GetCenter().Y:0.#}). " + $"Pole = {GetArea():0.#} u², Obwód = {GetPerimeter():0.#} u.";
        }
        public void RightClickAction()
        {
            BorderColor = Color.Yellow;

        }
    }
}
