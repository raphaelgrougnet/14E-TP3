using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.Domain
{
    public interface IRecompense
    {
        public string Titre { get; init; }
        public EnumType Type { get; init; }
        public string Description { get; init; }
        public ObjectId idAbonne { get; init; }
        public ObjectId idFilm { get; init; }

    }
}
