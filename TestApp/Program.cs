using System;
using System.Net.Http.Headers;
using Yggdrasil_CSharp;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Yggdrasil_CSharp.Yggdrasil yggdrasil = new Yggdrasil();
            var Authenticated = yggdrasil.Login("Blarg", "Blarg");
            if (Authenticated != null)
            {
                
            }
        }
    }
}