using System.Collections;
using System.Collections.Generic;

namespace LINQPrac
{
    public class Order : IEnumerator,IEnumerable
    {
        static List<Order> orders;
        int position = -1;
        public int OrderId { get; set; }
        public int MusicianId { get; set; }
        public int InstrumentId { get; set; }

        static Order()
        {
            orders = new List<Order>
            {
                new Order { OrderId = 1, MusicianId = 1, InstrumentId = 2 },
                new Order { OrderId = 2, MusicianId = 2, InstrumentId = 3 },
                new Order { OrderId = 3, MusicianId = 3, InstrumentId = 1 },
                new Order { OrderId = 4, MusicianId = 3, InstrumentId = 2 },
                new Order { OrderId = 5, MusicianId = 4, InstrumentId = 2 },
                new Order { OrderId = 6, MusicianId = 2, InstrumentId = 4 }
            };
        }

        public bool MoveNext()
        {
            position++;
            return (position < orders.Count);
        }

        public void Reset()
        {
            position=0;
        }

        public object Current
        {
            get { return orders[position]; }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}