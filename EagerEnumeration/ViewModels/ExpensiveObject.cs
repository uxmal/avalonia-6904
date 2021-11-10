using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace EagerEnumeration.ViewModels
{
    /// <summary>
    /// This view model class was expensive to compute/obtain. We want these to be 
    /// created only as necessary.
    /// </summary>
    public class ExpensiveObject : INotifyPropertyChanged
    {
        private int _Number;
        public ExpensiveObject(int n)
        {
            this._Number = n;
            // Simulate these objects being expensive to compute.

            // We should do this in a different property.
            // Thread.Sleep(500);
        }

        private string _Name = "Loading ...";

        /// <summary>
        /// comment
        /// </summary>
        public string Name
        {
            get => _Name;
            private set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        public Task<string> AsyncBody => GetBodyAsync();

        private async Task<string> GetBodyAsync()
        {
            await Task.Delay(500);
            
            var rnd = new Random();
            int Rnd(int m) => rnd.Next() % m;
            var nLines = Rnd(6) + Rnd(6) + Rnd(6) + 1;
            var body = string.Join(Environment.NewLine,
                Enumerable.Range(0, nLines)
                    .Select(u => $"  Line {u}"));
            
            Name = $"Name{_Number}";
            
            return body;
        }

        // We will use Property changed event to update our Name-Property after the content is computed.
        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}