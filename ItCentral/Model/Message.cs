using System.ComponentModel.DataAnnotations;

namespace ItCentral.Model
{
    public class Message
    {
        [Key]
        [MaxLength(8)]
        public string Key { get; set; }
        public string MessageValue { get; set; }
    }
}
