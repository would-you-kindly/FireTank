using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FireSafety
{
    public class MapModel
    {
        public MapModel()
        {
            this.Algortihms = new HashSet<AlgorithmModel>();
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Column(TypeName = "xml")]
        public string XmlContent { get; set; }

        [NotMapped]
        public XElement XmlValueWrapper
        {
            get
            {
                return XElement.Parse(XmlContent);
            }
            set
            {
                XmlContent = value.ToString();
            }
        }

        public virtual ICollection<AlgorithmModel> Algortihms { get; set; }
    }
}