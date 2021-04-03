using System.Collections;
using System.Collections.Generic;

namespace LINQPrac
{
    public class Musician: IEnumerator,IEnumerable
    {
        static List<Musician> people;
        int position = -1;
        public int MusicianId { get; set; }
        public string Name { get; set; }

        static Musician()
        {
            people = new List<Musician>
            {
                new Musician { MusicianId = 1, Name = "Sonny Rollings" },
                new Musician { MusicianId = 2, Name = "Miles Davis"},
                new Musician { MusicianId = 3, Name = "John Coltrane" },
                new Musician { MusicianId = 4, Name = "Charlie Parker" },
                new Musician { MusicianId = 5, Name = "Bela Fleck" }
            };
        }

        public bool MoveNext()
        {
            position++;
            return (position < people.Count);
        }

        public void Reset()
        {
            position=0;
        }

        public object Current
        {
            get { return people[position]; }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public override string ToString()
        {
            return $"{nameof(MusicianId)}: {MusicianId}, {nameof(Name)}: {Name}";
        }
    }
}