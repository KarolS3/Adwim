using OopPaint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPaint.Data.Geometry
{
    internal class Rectangle : FigureToDrawBase, IDescribable, IRightClickable
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public override double GetPerimeter() => 2.0 * (Width + Height);
        public override double GetArea() => Width * Height;
        private RectangleF Bounds => new RectangleF(Location.X, Location.Y, Width, Height);

        public override void DrawOnCanvas(Graphics g)
        {
            using (var brush = new SolidBrush(FillingColor))
            {
                using (var pen = new Pen(BorderColor, 2))
                {
                    var rect = new RectangleF(Location.X, Location.Y, Width, Height);

                    g.FillRectangle(brush, rect);
                    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

                    DrawInnerText(g, rect);
                }
            }
        }
        public override PointF GetCenter() => new PointF(Location.X + Width / 2f, Location.Y + Height / 2f);
        public override bool ContainsPoint(PointF p) => Bounds.Contains(p);
        public string GetDescription()
        {
            return $"Prostokąt o szerokości {Width:0.#} i wysokości {Height:0.#}, " + $"środek w ({GetCenter().X:0.#}, {GetCenter().Y:0.#}). " + $"Pole = {GetArea():0.#} u², Obwód = {GetPerimeter():0.#} u.";
        }
        public void RightClickAction()
        {
            FillingColor = Color.FromArgb(Random.Shared.Next(256), Random.Shared.Next(256), Random.Shared.Next(256));
        }

    }
}
