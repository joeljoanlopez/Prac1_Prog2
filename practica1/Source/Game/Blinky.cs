using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCGame
{
    internal class Blinky : Item
    {
        //Private
        private Sprite sprite;
        private Texture texture;

        public Blinky()
        {
            texture = new Texture("Data/Textures/Blinky.png");
            sprite = new Sprite(texture);
        }
    }
}
