using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Core.Domain
{
    public class SkiJump
    {
        public int Id { get; set; }
        public City City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int k { get; set; }
        public string JudgePoint { get; set; }
    }
}
