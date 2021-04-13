using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class Content
    {
        [Key]
        public int ContentId { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentTime{ get; set; }

        //
        public int HeadingId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Content> Contents { get; set; }

    }
}
