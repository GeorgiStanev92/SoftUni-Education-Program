using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Height = height;
            this.Width = width;
            this.Length = length;
           
        }

        public double Length
        {
            get 
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width 
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public string Volume()
        {
            double result = this.Length * this.Width * this.Height;
            return $"Volume - {result:F2}";
        }

        public string LateralSurfaceArea()
        {
            double result = (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            return $"Lateral Surface Area - {result:F2}";
        }

        public string SurfaceArea()
        {
            double result = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            return $"Surface Area - {result:F2}";
        }
    }
}
