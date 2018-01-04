using AreaFinder.Entities;
using AreaFinder.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace AreaFinder
{
    public static class Serialization
    {
        public static void Serialize(List<Shp> shapes)
        {
            using (FileStream fs = new FileStream("shapesFile.dat", FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (var s in shapes)
                    {
                        var objBytes = s.Serialize();
                        bw.Write(objBytes);
                    }
                }
            }
        }

        public static void LoadData(List<Shp> shapes)
        {
            string file = "shapesFile.dat";

            if (File.Exists(file))
            {
                var bytes = File.ReadAllBytes(file);

                if (bytes.Length != 0)
                {
                    int i = 0;
                    while (i < bytes.Length)
                    {
                        shapes.Add(Deserialize(bytes, ref i));
                    }
                }
            }
        }

        public static Shp Deserialize(byte[] input, ref int sIndex)
        {
            Shp result = null;

            var type = (ShapeType)input[sIndex];
            sIndex += 1;

            switch (type)
            {
                case ShapeType.Circle:

                    var r = BitConverter.ToDouble(input, sIndex);

                    result = new Circle(r);
                    sIndex += sizeof(double);

                    break;

                case ShapeType.Rectangle:

                    var w = BitConverter.ToDouble(input, sIndex);
                    sIndex += sizeof(double);
                    var h = BitConverter.ToDouble(input, sIndex);

                    result = new Rectangle(w, h);
                    sIndex += sizeof(double);

                    break;
            }

            return result;
        }
    }
}
