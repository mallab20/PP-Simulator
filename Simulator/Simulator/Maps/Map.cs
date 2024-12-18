using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Simulator.Maps
{
    public abstract class Map
    {
        protected readonly Dictionary<Point, List<IMappable>> Fields;

        public int SizeX { get; }
        public int SizeY { get; }

        protected Func<Map,Point,Direction, Point>? FNext { get; set;  }
        protected Func<Map,Point,Direction, Point>? FNextDiagonal { get; set;  }

        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5 || sizeY < 5)
                throw new ArgumentOutOfRangeException("Wymiary mapy muszą być większe niż 5x5.");

            SizeX = sizeX;
            SizeY = sizeY;
            Fields = new Dictionary<Point, List<IMappable>>();
        }
        public virtual void Add(IMappable mappable, Point position)
        {
            var wrappedPosition = WrapPosition(position);

            if (!Fields.ContainsKey(wrappedPosition))
            {
                Fields[wrappedPosition] = new List<IMappable>();
            }

            Fields[wrappedPosition].Add(mappable);

            if (mappable is Creature creature)
            {
                creature.InitMapAndPosition(this, wrappedPosition);
            }
        }

        public virtual void Remove(IMappable mappable, Point position)
        {
            var wrappedPosition = WrapPosition(position);

            if (Fields.ContainsKey(wrappedPosition))
            {
                Fields[wrappedPosition].Remove(mappable);

                if (Fields[wrappedPosition].Count == 0)
                {
                    Fields.Remove(wrappedPosition);
                }
            }
        }
   
        public virtual List<IMappable>? At(int x, int y)
        {
            var wrappedPosition = WrapPosition(new Point(x, y));

            if (Fields.ContainsKey(wrappedPosition))
            {
                return Fields[wrappedPosition];
            }

            return null;
        }

        public virtual List<IMappable>? At(Point p)
        {
            return At(p.X, p.Y);
        }
        public abstract bool Exist(Point p);
        public Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d) ?? p;

        public Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this, p, d) ?? p;
        protected virtual Point WrapPosition(Point position)
        {
            return position;
        }
    }
}
