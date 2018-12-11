using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSModels
{
    public class Keyword
    {
        public Keyword()
        {
            this.DocumentTypes = new HashSet<DocumentType>();
        }

        public int KeywordId { get; set; }

        [Display(Name = "Keyword")]
        [Required]
        [MaxLength(60)]
        public string KeywordName { get; set; }

        public virtual ICollection<DocumentType> DocumentTypes { get; set; }
    }
}
