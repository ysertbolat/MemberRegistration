using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member{Email ="y.sertbolat@gmail.com", FirstName ="Yusuf", LastName="Sertbolat", DateOfBirth = new DateTime(2001,2,28), TcNo = "49306212434" });
            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}
