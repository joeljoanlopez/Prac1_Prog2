using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace TCGame
{
    internal class Bomb : Item
    {
        private Texture _Texture;
        private string _TexPath = "Data/Textures/Bomb.png";
        private Sprite _Sprite;

        public Bomb()
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
        }
    }
}
