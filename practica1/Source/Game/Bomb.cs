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
        private Sprite sprite;
        private Texture texture;

        public Bomb() {
            texture = new Texture("Data/Textures/Bomb.png");
            sprite = new Sprite(texture);
        }
    }
}
