using System;
using System.Linq;
using System.Threading;

namespace EagerEnumeration.ViewModels
{
    /// <summary>
    /// This view model class was expensive to compute/obtain. We want these to be 
    /// created only as necessary.
    /// </summary>
    public class ExpensiveObject
    {
        public ExpensiveObject()
        {
            // Simulate these objects being expensive to compute.
            Thread.Sleep(500);
        }

        public string Name { get; set; } = "";
        public string Body { get; set; } = "";

        public static ExpensiveObject Create(int n)
        {
            var rnd = new Random();
            int Rnd(int m) => rnd.Next() % m;
            var nLines = Rnd(6) + Rnd(6) + Rnd(6) + 1;
            var name = $"Name{n}";
            var body = string.Join(Environment.NewLine,
                Enumerable.Range(0, nLines)
                    .Select(u => $"  Line {u}"));
            return new ExpensiveObject
            {
                Name = name,
                Body = body,
            };
        }

    }
}