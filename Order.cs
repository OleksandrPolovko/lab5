using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    enum OrderStatus
    {
        OS_New,
        OS_Inprogress,
        OS_Close,
    }
    internal class Order
    {
        public int Id { get; set; }
        public int[] TovarIds { get; set; }
        public int[] Counts { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}
