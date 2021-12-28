using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Core.Domain
{
    public class SkiJumper
    {
        public int Id { get; set; }
        public Trainer Trainer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public override bool Equals(object other)
        {
            var otherSkiJumper = other as SkiJumper;

            if (otherSkiJumper != null)
            {
                return Id == otherSkiJumper.Id
                    && (FirstName != null && FirstName.Equals(otherSkiJumper.FirstName) || FirstName == null)
                    && (LastName != null && LastName.Equals(otherSkiJumper.LastName) || LastName == null)
                    && (Country != null && Country.Equals(otherSkiJumper.Country) || Country == null)
                    && BirthDate == otherSkiJumper.BirthDate
                    && Height == otherSkiJumper.Height
                    && Weight == otherSkiJumper.Weight;
            }
            return this == null;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, Trainer, Country, BirthDate, Height, Weight);
        }
    }
}
