using System.Collections.Generic;

namespace dropdown.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public List<Village> Villages { get; set; }
    }
}