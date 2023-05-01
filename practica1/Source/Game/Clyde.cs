using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCGame
{
    internal class Clyde : Item
    {
        //Private
        private Sprite sprite;
        private Texture texture;

        public Clyde()
        {
            texture = new Texture("Data/Textures/Clyde.png");
            sprite = new Sprite(texture);
        }
    }
}
