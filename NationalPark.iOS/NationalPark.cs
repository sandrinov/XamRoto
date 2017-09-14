using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace NationalPark.iOS
{
    public class NationalPark
    {
        public NationalPark()
        {
            Id = Guid.NewGuid().ToString();
            Name = "New Park";
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}