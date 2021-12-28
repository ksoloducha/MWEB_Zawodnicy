using System;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Infrastructure
{
	public class SkiJumperDTO
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public override bool Equals(object other)
        {
            var otherSkiJumperDTO = other as SkiJumperDTO;

            if(otherSkiJumperDTO != null)
            {
                return Id == otherSkiJumperDTO.Id
                    && (FirstName != null && FirstName.Equals(otherSkiJumperDTO.FirstName) || FirstName == null)
                    && (LastName != null && LastName.Equals(otherSkiJumperDTO.LastName) || LastName == null)
                    && (Country != null && Country.Equals(otherSkiJumperDTO.Country) || Country == null)
                    && BirthDate == otherSkiJumperDTO.BirthDate
                    && Height == otherSkiJumperDTO.Height
                    && Weight == otherSkiJumperDTO.Weight;
            }
            return this == null;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName, Country, BirthDate, Height, Weight);
        }
    }
}
