using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Utilities.Security.Common;

namespace DotNet.Utilities.Security.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Md5.Md5Encrypts("123456");
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
