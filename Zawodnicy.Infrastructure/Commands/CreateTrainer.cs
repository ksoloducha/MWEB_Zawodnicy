using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Infrastructure.Commands
{
    public class CreateTrainer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
