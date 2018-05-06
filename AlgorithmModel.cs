using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FireSafety
{
    public class AlgorithmModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
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

        public double? Result { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public UserModel User { get; set; }

        [Required]
        public MapModel Map { get; set; }
    }
}