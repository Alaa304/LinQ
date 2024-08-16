using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LinQ
{
    public static class Fillter
    {
        //    public static List<Customer> getbyName(this List<Customer> list ,<T> name)
        //    {
        //        List<Customer> ahmeds = new List<Customer>();
        //        foreach (var c in list)
        //        {
        //            if (c.name.Contains(name))
        //            {
        //                ahmeds.Add(c);
        //            }
        //        }
        //        return ahmeds;}
        //}


        public static List<Customer> getCustomer(this List<Customer> list,Func<Customer,bool> fun)
        {
            List<Customer> _list = new List<Customer>();
            foreach (var c in list)
            {
                if (fun(c))
                {
                    _list.Add(c);
                }
            }
            return _list;
        }
    }
}

