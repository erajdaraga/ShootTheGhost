using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoot_the_Ghost
{
    public static class Utility
    {
        private static Random rnd = new Random();
        public static int Added { get; set; } = 70;
        public static int GetRandomGhostDuration()
        {
            return rnd.Next(50)+Added;
        }

        public static void LevelUp()
        {
            if(Added>20) Added -= 20;
        }

        public static int getRandomGhostType()
        {
            return rnd.Next(1, 3);
        }

        public static int GetRandomGhostAppearing()
        {
            return rnd.Next(20) + Added;
        }

        public static void Reset()
        {
            Added = 70;
        }
    }
}
