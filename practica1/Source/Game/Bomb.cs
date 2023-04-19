using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;

namespace TCGame
{
    internal class Bomb : Item
    {
        //Private
        private Texture myTexture = new Texture ("Data/Textures/Bomb.png");

        public Bomb() {
            
        }
    }
}
