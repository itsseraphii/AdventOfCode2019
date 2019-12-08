using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay6
{
    class CB
    {
        /// <summary>
        /// CB this CB is orbiting
        /// </summary>
        public CB Parent;
        
        /// <summary>
        /// Total of CB orbiting this CB (direct + indirect)
        /// </summary>
        public int Orbits;

        /// <summary>
        /// Name of CB
        /// </summary>
        public string Name;

        /// <summary>
        /// List of objects orbiting this CB
        /// </summary>
        public List<CB> DirectOrbit = new List<CB>();

        /// <summary>
        /// Builds the CB with only a name
        /// </summary>
        /// <param name="name"></param>
        public CB(string name)
        {
            Name = name;
        }

        public CB AddChild(CB child)
        {
            DirectOrbit.Add(child);
            child.Parent = this;
            Inc(1);
            return child;
        }

        /// <summary>
        /// Searches for specified CB in all child orbitsé
        /// </summary>
        /// <param name="searchCB">Name of CB that is searched for.</param>
        public CB FindCB(string searchCB)
        {
            if (this.Name == searchCB)
                return this;
            else
            {
                foreach(CB orbit in DirectOrbit)
                {
                    CB found = orbit.FindCB(searchCB);
                    if (found != null)
                    {
                        return found;
                    }
                }
                return null;
            }
        }

        public List<CB> Parents()
        {
            List<CB> allParents = new List<CB> {this};

            if(Parent != null)
            {
                foreach (CB parent in Parent.Parents())
                {
                    allParents.Add(parent);
                }
            }
            return allParents;
        }

        /// <summary>
        /// Increases the CB's orbits and its parent's orbits.
        /// </summary>
        /// <param name="n"></param>
        private void Inc(int n)
        {
            Orbits += n;
            if(Parent != null)
            {
                Parent.Inc(n + 1);
            }
        }

    }
}
