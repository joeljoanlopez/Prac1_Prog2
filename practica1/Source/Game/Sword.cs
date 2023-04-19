using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCGame
{
    internal class Sword : Item
    {
        //Private
        private Sprite sprite;
        private Texture texture;

        public Sword()
        {
            texture = new Texture("Data/Textures/Sword.png");
            sprite = new Sprite(texture);
        }
    }
}
