using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSModels
{
    public class DocumentType
    {

        public DocumentType()
        {
            this.Keywords = new HashSet<Keyword>();
        }

        public int DocumentTypeId { get; set; }

        [Display(Name = "Document Type")]
        [Required]
        public string DocumentTypeName { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}
