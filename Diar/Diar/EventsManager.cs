using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Diar
{
    class EventsManager
    {
        private List<Event> events;
        private string path;


        public EventsManager(string path)
        {
            this.path = path;

            events = new List<Event>();
            var loaded = LoadEvents(path);

            if (loaded != null)
                events.AddRange(loaded);
        }


        public void RemoveEvent(Event remEvent)
        {
            events.Remove(remEvent);
            SaveEvents(path);
        }
        public void RemoveEvent(string name) 
        {
            events.RemoveAll(i => i.name == name);
            SaveEvents(path);
        }
        public void RemoveEvent(DateTime date)
        {
            events.RemoveAll(i => i.start == date);
            SaveEvents(path);
        }
        public void RemoveEvents(DateTime from, DateTime to) 
        {
            events.RemoveAll(i => (DateTime.Compare(i.start, from) >= 0 && DateTime.Compare(i.end, to) <= 0));
            SaveEvents(path);
        }

        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent);
            SaveEvents(path);
        }



        private List<Event> LoadEvents(string path)
        {
            try
            {
                List<Event> deserialized = JsonConvert.DeserializeObject<List<Event>>(File.ReadAllText(path));
                return deserialized;
            }
            catch
            {
                Console.WriteLine("Chyba při načítání události");
                return null;
            }
        }

        private void SaveEvents(string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(events, Formatting.Indented);
                File.WriteAllText(path, json);

            }
            catch
            {
                Console.WriteLine("Chyba při ukládání události");
            }
        }

        public List<Event> GetEvents() => events;
    }
}
