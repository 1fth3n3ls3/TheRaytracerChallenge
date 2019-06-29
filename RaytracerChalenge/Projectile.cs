using System;
using System.Collections.Generic;
using System.Text;

namespace Raytracer
{
    class Projectile
    {
        public Tuple Position { get; set; }
        public Tuple Velocity { get; set; }
    }

    class Enviro
    {
        public Tuple Gravity { get; set; }
        public Tuple Wind { get; set; }
    }
}
