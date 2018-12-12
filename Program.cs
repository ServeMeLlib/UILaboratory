using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperApp.UILaboratory
{
    using System.Diagnostics;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ServeMeLib;

   public  class Program
    {
        public string GetSomething(string arg)
        {
            return JsonConvert.SerializeObject(new
            {
                Date=DateTime.UtcNow,
                How="I will Do it"
            });
        }
        static void Main(string[] args)
        {
            string instruction = ServeMe.GetMethodExecutionInstruction(typeof(Program), nameof(GetSomething));
            string serverCsv = $"equalto /search,assembly {instruction},get\napp log";
            using (var serveMe = new ServeMe())
            {
                string url = serveMe.Start(serverCsv).First();
                Process.Start(url);
                Console.ReadKey();
            }
        }
    }
}
