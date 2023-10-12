using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Shop:  ISearchable
    {
        public Shop()
        {
            m_tovary = new List<Tovar>();
            m_orders = new List<Order>();
            m_users = new List<User>();
        }
        public void ReadTovary(string filename)
        {
            Stream s = System.IO.File.OpenRead(filename);
            StreamReader reader = new StreamReader(s);
            while (!reader.EndOfStream)
            {
                string buf = reader.ReadLine();
                string[] par = buf.Split(';');
                Tovar t = new Tovar();
                t.Id = Convert.ToInt32(par[0]);
                t.Name = par[1];
                t.Price = (float)Convert.ToDouble(par[2]);
                t.Description = par[3];
                t.Category = par[4];
                m_tovary.Add(t);
            }
        }
        public void ReadUsers(string filename)
        {
            Stream s = System.IO.File.OpenRead(filename);
            StreamReader reader = new StreamReader(s);
            while (!reader.EndOfStream)
            {
                string buf = reader.ReadLine();
                string[] par = buf.Split(';');
                User u = new User();
                u.Id = Convert.ToInt32(par[0]);
                u.Login = par[1];
                u.Password = par[2];
                string orders = par[3];
                string[] ord = orders.Split(',');
                int[] current_orders = new int[ord.Length];
                for (int i=0;i< ord.Length; i++)
                {
                    current_orders[i] = Convert.ToInt32(ord[i]);
                }
                u.Orders = current_orders;
                m_users.Add(u);
            }
        }

        public void ReadOrders(string filename)
        {
            Stream s = System.IO.File.OpenRead(filename);
            StreamReader reader = new StreamReader(s);
            while (!reader.EndOfStream)
            {
                string buf = reader.ReadLine();
                string[] par = buf.Split(';');
                Order o = new Order();
                o.Id = Convert.ToInt32(par[0]);
                string tovary = par[1];
                string[] tovs = tovary.Split(',');
                int[] current_tovary = new int[tovs.Length];
                for (int i = 0; i < tovs.Length; i++)
                {
                    current_tovary[i] = Convert.ToInt32(tovs[i]);
                }
                o.TovarIds = current_tovary;

                string counts = par[2];
                string[] count = tovary.Split(',');
                int[] current_count = new int[count.Length];
                for (int i = 0; i < count.Length; i++)
                {
                    current_count[i] = Convert.ToInt32(count[i]);
                }
                o.Counts = current_count;

                o.TotalPrice = (float)Convert.ToDouble(par[3]);
                o.Status = (OrderStatus)Convert.ToInt32(par[4]);

                m_orders.Add(o);
            }
        }

        public void ShowUsers()
        {
            foreach(var u in m_users)
            {
                Console.WriteLine("UserID: " + u.Id + " Login: " + u.Login);
            }
        }

        public void ShowTovary(string category)
        {
            foreach (var t in m_tovary)
            {
                if (t.Category == category)
                    Console.WriteLine("TovarID: " + t.Id + " Name: " + t.Name + " Price: " + t.Price + " Category: " + t.Category);
            }
        }

        public void ShowTovary(float from_price, float to_price)
        {
            foreach (var t in m_tovary)
            {
                if (t.Price >= from_price && t.Price <= to_price)
                    Console.WriteLine("TovarID: " + t.Id + " Name: " + t.Name + " Price: " + t.Price + " Category: " + t.Category);
            }
        }

        public void ShowUsersOrders(int user_id)
        {
            foreach (var u in m_users)
            {
                if (u.Id == user_id)
                {
                    foreach (var order_id in u.Orders)
                    {
                        Console.WriteLine("OrderID: " + order_id + " Status: " + m_orders[order_id].Status);
                    }
                }
            }
        }

        public void ShowTovaryFromOrder(int order_id)
        {
            foreach (var o in m_orders)
            {
                if (o.Id == order_id)
                {
                    foreach (var t in o.TovarIds)
                    {
                        Console.WriteLine("TovarID: " + t);
                    }
                }
            }
        }

        public void ShowTovar(int tovar_id)
        {
            foreach (var t in m_tovary)
            {
                if (t.Id == tovar_id)
                    Console.WriteLine("TovarID: " + t.Id + " Name: " + t.Name + " Price: " + t.Price + " Category: " + t.Category + " Description: \"" + t.Description +"\"");
            } 
        }

        private List<Tovar> m_tovary;
        private List<User> m_users;
        private List<Order> m_orders;

    }
}
