using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCGame;

namespace practica1.Source.Game
{
    internal class Blinky : Item
    {
        private Texture _Texture;
        private string _TexPath = "Data/Textures/Blinky.png";
        private Sprite _Sprite;

        public Blinky()
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
        }
    }
}
