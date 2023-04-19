using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCGame
{
    internal class Heart : Item
    {
        //Private
        private Sprite sprite;
        private Texture texture;

        public Heart()
        {
            texture = new Texture("Data/Textures/Heart.png");
            sprite = new Sprite(texture);
        }
    }
}
