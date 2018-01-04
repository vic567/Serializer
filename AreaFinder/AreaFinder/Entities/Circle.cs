using AreaFinder.Enums;
using System;

namespace AreaFinder.Entities
{
    public class Circle : Shp, Interfaces.ISerializable
    {
        private const byte type = (byte)ShapeType.Circle;
        private double radius;

        public Circle() { }

        public Circle(double R)
        {
            radius = R;
        }

        public override ShapeType Type => ShapeType.Circle;

        public double Radius
        {
            get => radius; set => value = radius;
        }

        public override double Area()
        {
            var answer = Math.PI * radius * radius;
            return answer;
        }

        public override byte[] Serialize()
        {
            var radiusBytes = BitConverter.GetBytes(radius);
            var rl = radiusBytes.Length;

            var objBytes = new byte[rl + 1];

            objBytes[0] = type;
            radiusBytes.CopyTo(objBytes, 1);

            return objBytes;
        }
    }
}
