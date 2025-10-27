using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toyscartoons
{
    public class Doll
    {
        public int Id { get; set; }
        public int Articul { get; set; }
        public string Name { get; set; }
        public string Collection { get; set; }
        public DateTime PublichDate { get; set; }
        public string Description { get; set; }
        public Cartoon Cartoon { get; set; }

    }
}
