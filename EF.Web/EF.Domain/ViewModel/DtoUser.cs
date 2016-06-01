using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain
{
    public class DtoUser
    {
        //public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime MyDate { get; set; }
        //public bool IsTrue { get; set; }
        public decimal Money { get; set; }

        public int WrongID { get; set; }
        public string OpenId { get; set; }
        public int QuesId { get; set; }
        public string WrongType { get; set; }
        public string Remarks { get; set; }
        public System.DateTime WrongDate { get; set; }
    }
}
