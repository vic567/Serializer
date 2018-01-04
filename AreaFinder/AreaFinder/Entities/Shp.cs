using AreaFinder.Enums;

namespace AreaFinder.Entities
{
    public abstract class Shp
    {
        public abstract ShapeType Type { get; }

        public abstract double Area();
        public abstract byte[] Serialize();
    }
}
