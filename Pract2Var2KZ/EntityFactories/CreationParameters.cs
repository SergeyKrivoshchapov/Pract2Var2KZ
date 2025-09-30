using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract2Var2KZ.EntityFactories
{
    public class CreationParameters
    {
        private Dictionary<string, object> _parameters = new Dictionary<string, object>();
        public void AddParameter(string name, object value) => _parameters[name] = value;

        public T GetParameter<T>(string name) => (T)_parameters[name];
        public bool HasParameter(string name) => _parameters.ContainsKey(name);
    }
}
