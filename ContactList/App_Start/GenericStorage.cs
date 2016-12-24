using ContactList.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Metrics.Models;

namespace ContactList
{
    public class GenericStorage<T>
    {
        private string _filePath;

        public GenericStorage()
        {
            var webAppsHome = Environment.GetEnvironmentVariable("HOME")?.ToString();
            if (String.IsNullOrEmpty(webAppsHome))
            {
                _filePath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath) + "\\";
            }
            else
            {
                _filePath = webAppsHome + "\\site\\wwwroot\\";
            }
        }

        internal Task Save(Metric[] metric, string fILENAME)
        {
            throw new NotImplementedException();
        }

        public async Task Save(IEnumerable<T> target, string filename)
        {
            var json = JsonConvert.SerializeObject(target);
            File.WriteAllText(_filePath + filename, json);
        }

        public async Task<IEnumerable<T>> Get(string filename)
        {
            var contactsText = String.Empty;
            if (File.Exists(_filePath + filename))
            {
                contactsText = File.ReadAllText(_filePath + filename);
            }

            var data = JsonConvert.DeserializeObject<T[]>(contactsText);
            return data;
        }
    }
}
