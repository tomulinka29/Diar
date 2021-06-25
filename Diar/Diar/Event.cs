using System;
using System.Collections.Generic;
using System.Text;

namespace Diar
{
    class Event
    {
        public DateTime start;
        public DateTime end;

        public bool wholeDay = false;

        public string name;
        public string description;

        public Event(DateTime start, DateTime end, bool wholeDay, string name, string description)
        {
            this.start = start;
            this.end = end;
            this.wholeDay = wholeDay;
            this.name = name;
            this.description = description;
        }

        public override string ToString()
        {
            return "Název: " + name + Environment.NewLine + 
                   "Popis: " + description + Environment.NewLine + 
                   "Začátek: " + start.ToString() + Environment.NewLine + 
                   "Konec: " + end.ToString();
        }
    }
}
