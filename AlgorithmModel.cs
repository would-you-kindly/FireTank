using System;

namespace FireSafety
{
    public class AlgorithmModel
    {
        public Guid Id { get; set; }
        public byte[] Bytes { get; set; }
        public double Result { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Success { get; set; }
        
        public UserModel User { get; set; }
        public MapModel Map { get; set; }
    }
}