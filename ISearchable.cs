using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal interface ISearchable
    {
        void ShowUsers();
        void ShowTovary(string category);
        void ShowTovary(float from_price, float to_price);
        void ShowUsersOrders(int user_id);
        void ShowTovaryFromOrder(int order_id);
        void ShowTovar(int tovar_id);
    }
}
