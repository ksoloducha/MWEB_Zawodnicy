using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Core.Domain
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkiJump SkiJump { get; set; }
        public DateTime Date { get; set; }
    }
}
