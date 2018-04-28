using System;
using System.Collections.Generic;

namespace FireSafety
{
    public class MapModel
    {
        public MapModel()
        {
            this.Algortihms = new HashSet<AlgorithmModel>();
        }

        public Guid Id { get; set; }
        public byte[] Bytes { get; set; }

        public ICollection<AlgorithmModel> Algortihms { get; set; }
    }
}