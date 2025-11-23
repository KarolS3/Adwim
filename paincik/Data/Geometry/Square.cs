using OopPaint.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPaint.Data.Geometry
{
    internal class Square :Rectangle, IDescribable, IRightClickable

    {
        public float EdgeLength
        {
            get => Width;
            set
            {
                Width = value;
                Height = value;
            }
        }
        public string GetDescription()
        {
            return $"Kwadrat o boku {EdgeLength:0.#}, " + $"środek w ({GetCenter().X:0.#}, {GetCenter().Y:0.#}). " + $"Pole = {GetArea():0.#} u², Obwód = {GetPerimeter():0.#} u.";
        }
        public void RightClickAction()
        {
            TextColor = Color.FromArgb(Random.Shared.Next(256), Random.Shared.Next(256), Random.Shared.Next(256));
        }

    }
}
