using DMSModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSModels.ViewModels
{
    public class AssignedKeyword
    {

        public int KeywordId { get; set; }
        public string KeywordName { get; set; }
        public bool Assigned { get; set; }
    }
}
