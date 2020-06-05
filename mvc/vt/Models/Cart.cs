using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vt.Models
{
    public class Cart
    {
        [DisplayName("产品")]
        public DBModel.product product { set; get; }
        [DisplayName("数量")]
        public int amount { set; get; }
    }
}