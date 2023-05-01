using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCGame
{
    internal class Coin : Item
    {
        //Private
        private Sprite sprite;
        private Texture texture;

        public Coin()
        {
            texture = new Texture("Data/Textures/Coin.png");
            sprite = new Sprite(texture);
        }
    }
}
