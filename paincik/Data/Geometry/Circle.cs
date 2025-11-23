using OopPaint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPaint.Data.Geometry
{
    internal class Circle : FigureToDrawBase, IDescribable, IRightClickable
    {
        public float Radius { get; set; }
        public override double GetArea() => Math.PI * Radius * Radius;
        public override double GetPerimeter() => 2.0 * Math.PI * Radius;


        public override void DrawOnCanvas(Graphics g)
        {
            using (var brush = new SolidBrush(FillingColor))
            {
                using (var pen = new Pen(BorderColor, 2))
                {
                    var center = GetCenter();
                    var rect = new RectangleF(center.X - Radius, center.Y - Radius, Radius * 2, Radius * 2);

                    g.FillEllipse(brush, rect);
                    g.DrawEllipse(pen, rect);

                    DrawInnerText(g, rect);
                }
            }
           
        }
        public override PointF GetCenter() => Location;
        public override bool ContainsPoint(PointF p)
        {
            var center = GetCenter();

            var dx = p.X - center.X;
            var dy = p.Y - center.Y;

            return dx * dx + dy * dy <= Radius * Radius;
        }
        public string GetDescription()
        {
            return $"Koło o promieniu {Radius:0.#}, środek w ({Location.X:0.#}, {Location.Y:0.#}). " + $"Pole = {GetArea():0.#} u², Obwód = {GetPerimeter():0.#} u.";
        }
        public void RightClickAction()
        {
            BorderColor = Color.FromArgb(Random.Shared.Next(256),Random.Shared.Next(256), Random.Shared.Next(256));
        }

    }
}
