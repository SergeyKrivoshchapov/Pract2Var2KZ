using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pract2Var2KZ.Modules.Time
{
    public static class UpdateManager
    {
        private static System.Timers.Timer _timer;
        private static List<IUpdating> _updating = new List<IUpdating>();
        private static readonly object _lock = new object();

        static UpdateManager()
        {
            _timer = new System.Timers.Timer(5000);
            _timer.Elapsed += OnTimed;
            _timer.AutoReset = true;
            _timer.Start();
        }
        
        private static void OnTimed(object sender, ElapsedEventArgs e)
        {
            lock (_lock)
            {
                foreach (var item in _updating.ToList())
                {
                    item.Update();
                }
            }
        }

        public static void Register(IUpdating updating)
        {
            lock (_lock)
            {
                if (!_updating.Contains(updating))
                {
                    _updating.Add(updating);
                }
            }
        }

        public static void Unregister(IUpdating updating) 
        {
            lock (_lock)
            {
                _updating.Remove(updating);
            }
        }
    }
}
