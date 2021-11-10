using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EagerEnumeration.ViewModels
{
    public class MainWindowViewModel
    {
        //public IList<ExpensiveObject> ExpensiveObjects { get; set; } = MakeWrappedList(20);
        public IList<ExpensiveObject> ExpensiveObjects { get; set; } = MakeVirtualList(20);
        //public IList<ExpensiveObject> ExpensiveObjects3 { get; set; } = MakeList(20);


        private static VirtualList<ExpensiveObject> MakeVirtualList(int nItems)
        {
            return new VirtualList<ExpensiveObject>(nItems, CreateExpensiveObject);
        }

        private static WrappedList<ExpensiveObject> MakeWrappedList(int nItems)
        {
            return new WrappedList<ExpensiveObject>(Enumerable.Range(0, nItems)
                .Select(n => new ExpensiveObject(n)));
        }


        private static List<ExpensiveObject> MakeList(int nItems)
        {
            return new List<ExpensiveObject>(Enumerable.Range(0, nItems)
                .Select(n => new ExpensiveObject(n)));
        }

        private static ExpensiveObject CreateExpensiveObject(int n)
        {
            return new ExpensiveObject(n);
        }
    }
}
