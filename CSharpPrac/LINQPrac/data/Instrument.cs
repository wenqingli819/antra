using System.Collections;
using System.Collections.Generic;

namespace LINQPrac
{
     public class Instrument: IEnumerator,IEnumerable
    {
        static List<Instrument> instruments;
        int position = -1;
        public int InstrumentId { get; set; }
        public string Name { get; set; }

        static Instrument()
        {
            instruments = new List<Instrument>
            {
                new Instrument { InstrumentId = 1, Name = "Soprano Saxophone" },
                new Instrument { InstrumentId = 2, Name = "Tenor Saxophone" },
                new Instrument { InstrumentId = 3, Name = "Trumpet" },
                new Instrument { InstrumentId = 4, Name = "Keyboards" }
            };
        }

        public bool MoveNext()
        {
            position++;
            return (position < instruments.Count);
        }

        public void Reset()
        {
            position=0;
        }

        public object Current
        {
            get { return instruments[position]; }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }

}