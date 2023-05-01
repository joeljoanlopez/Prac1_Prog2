using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML;

namespace TCGame
{
    internal class Axe : Item
    {
        //Private
        private Sprite sprite;
        private Texture texture;

        public Axe() { 
            texture = new Texture ("Data/Textures/Axe.png");
            sprite = new Sprite (texture);
        }
    }
}
