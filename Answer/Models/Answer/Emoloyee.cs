using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer.Model.Answer
{
    public class Emoloyee
    {
        [Key]
        [Column(Order = 0)]
        [DisplayName("員工編號")]
        public int ID { get; set; }

        [DisplayName("姓名")]
        public String Name { get; set; }

        [DisplayName("性別")]
        public String Gender { get; set; }

        [DisplayName("生日")]
        public DateTime Birthday { get; set; }

    }
}
