using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Linoleum.Model
{
    public class LinoleumRoll
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Byn Price { get; set; }

        public float Width { get; set; }

        public float TotalLength { get; set; }

        public float LengthLeft { get; set; }

        public float ProtectionLayerWidth { get; set; }

        public string Image { get; set; }
    }
}
