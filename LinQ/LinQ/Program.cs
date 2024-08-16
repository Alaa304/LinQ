// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LinQ;
//************************************************************************************************
//var ahmedlist = GetData.GetCustomers().getCustomer(c => c.age > 30 && c.isActive); 
//foreach (var person in ahmedlist) 
//{
//   // Using Lambda Expressions in C#.                                            
//   Console.WriteLine($"name : {person.name}\tage : {person.age}\ttelephone : {person.telephone}*\tspendAverage : {person.spendAverage}"); 
//}
//***********************************************************************************************

//********************************************************************************
//List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 88, 99 }; * 
//var res=lista.Where(x => x > 7);                    *                                                                                                 *
//var res=from x in lista where x>7 select x;                                     *
//foreach(int i in res)
//{                                                                               *
//    Console.WriteLine(i);                                                       *
//}********************************************************************************
//var c1 = new  { name = "Alaa", age = 19, telephone = 01526547687 };
//var c2 = new  { name = "Alaa", age = 19, telephone = 01526547687 };
//Console.WriteLine(c1.GetType());
//Console.WriteLine(c2.GetType());
//Console.WriteLine(c1.Equals(c2));
//*********************************************************************************
//var cust = GetData.GetCustomers().Where(x => x.age >= 30).Select(
//  a => new CustomerDto
//  {
//      custmerName = a.name,
//      CustomerTelephon = a.telephone,

//  }
//    );

//var customer2 = from Cust in GetData.GetCustomers()
//                select new
//                {
//                   Cust.name,
//                   Cust.telephone,
//                    _age = Cust.age
//                } into c
//                where c._age >= 30
//                select c;
//============================================
// var orderlist=GetData.GetCustomers().OrderByDescending( x=>x.age).  //method syntax
//                              ThenByDescending(x=>x.name);


//var customer2 = from C in GetData.GetCustomers()  //query syntax
//                orderby C.age descending, C.name descending
//                select C;


//foreach ( var custmer in orderlist)
//{
//    Console.WriteLine(custmer.name+"\t\t"+custmer.telephone+"\t\t"+custmer.age);
//}
//Console.WriteLine("---------------------*-----------------");
//foreach (var custmer in customer2)
//{
//    Console.WriteLine(custmer.name + "\t\t" + custmer.telephone + "\t\t" + custmer.age);
//}=======================================
//var element=GetData.GetCustomers().ElementAt(0);
//var element=GetData.GetCustomers().Single(x=>x.id==101);//
//Console.WriteLine(element.id+"\t\t"+element.name);

//}***************************************************** Grope by **************************
//var cats = GetData.GetCategories();
//var custs = GetData.GetCustomers();
//var result = custs.GroupBy(c => c.categoryId);
//var result2 = custs.ToLookup(c => c.categoryId);

//foreach (var item in result)
//{
//    Console.WriteLine($"the number iscategory\t:\t"+item.Key);
//    foreach (var i in item)
//    {
//        Console.WriteLine("--------->"+i.name);
//    }
//}

//***************************************************
var cats = GetData.GetCategories();
var custs = GetData.GetCustomers();

var result = cats.GroupJoin(custs, cat => cat.Id, cust => cust.categoryId,
             (cats, custs) => new
             {
                 falName = custs,
                 CatNam = cats.Name,
             });
foreach (var item in result)
{
    Console.WriteLine("\t\t\t" + item.CatNam);
    if (item.falName != null)
    {
        foreach (var c in item.falName)
        {
            Console.WriteLine("---------->" + c.name);
        }
    }
}
Console.WriteLine("-----------------------------------------");

var result2 = from cat in cats
              join cust in custs
             on cat.Id equals cust.categoryId
              select new
              {
                  CatNam = cat.Name,
                  falName = cust.name,

              };
foreach (var item in result2)
{
    Console.WriteLine(item.falName + "\t:\t" + item.CatNam);
}