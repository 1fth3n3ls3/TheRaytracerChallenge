using System;
using System.Globalization;

namespace Raytracer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projectile Simulator:");
            var projectile = new Projectile() {
                Position = Tuple.Point(0,1,0),
                Velocity = Tuple.Vector(1, 1, 0)};
            var enviro = new Enviro() {
                Gravity =Tuple.Vector(0,-0.1, 0),
                Wind = Tuple.Vector(0.01, 0, 0)};

            var provider = CultureInfo.InvariantCulture;
            var newProj = Tick(enviro, projectile);



            do
            {
                Console.WriteLine($"[{newProj.Position.X.ToString(provider)}, " +
                    $"{newProj.Position.Y.ToString(provider)}, " +
                    $"{newProj.Position.Z.ToString(provider)}]");
                newProj = Tick(enviro, newProj);
            } while (newProj.Position.Y > 0);

        }
        public static Projectile Tick (Enviro enviro, Projectile project)
        {
            var position = project.Position.Add(project.Velocity);
            var velocity = project.Velocity.Add(enviro.Gravity).Add(enviro.Wind);
            return new Projectile() { Velocity = velocity, Position = position };
        }
    }
}
