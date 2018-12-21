using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSModels.Models
{
    public class KeywordDataType
    {
        public int KeywordDataTypeId { get; set; }

        [Display(Name = "Keyword Data Type Name")]
        [Required]
        [MaxLength(60)]
        public string KeywordDataTypeName { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}
