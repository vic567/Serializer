using AreaFinder.Enums;
using System;

namespace AreaFinder.Entities
{
    public class Rectangle : Shp , Interfaces.ISerializable
    {
        private const byte type = (byte)ShapeType.Rectangle;
        private double width;
        private double height;

        public Rectangle() { }

        public Rectangle(double W, double H)
        {
            width = W;
            height = H;
        }

        public override ShapeType Type => ShapeType.Rectangle;

        public double Width
        {
            get => width; set => value = width;
        }

        public double Height
        {
            get => height; set => value = height;
        }

        public override double Area()
        {
            var answer = width * height;
            return answer;
        }

        public override byte[] Serialize()
        {
            var heightBytes = BitConverter.GetBytes(height);
            var hbl = heightBytes.Length;

            var widthBytes = BitConverter.GetBytes(width);
            var wbl = widthBytes.Length;

            var objBytes = new byte[1 + hbl + wbl];

            objBytes[0] = type;
            heightBytes.CopyTo(objBytes, 1);
            widthBytes.CopyTo(objBytes, 1 + hbl);

            return objBytes;
        }
    }
}
