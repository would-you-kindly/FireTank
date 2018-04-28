using System;
using System.Collections.Generic;

namespace FireSafety
{
    public class UserModel
    {
        public UserModel()
        {
            this.Algorithms = new HashSet<AlgorithmModel>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<AlgorithmModel> Algorithms { get; set; }
    }
}