using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    class Song
    {
        string name;
        string author;
        Song prev;

        public string songName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string songAuthor
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        public void setPrev(Song song)
        {
            prev = song;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }
        public override bool Equals(object d)
        {
            if (d.GetType() == GetType())
                return true;
            else
                return false;
        }
    }
}
