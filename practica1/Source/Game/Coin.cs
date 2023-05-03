using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCGame;

namespace practica1.Source.Game
{
    internal class Coin : Item
    {
        private Texture _Texture;
        private string _TexPath = "Data/Textures/Coin.png";
        private Sprite _Sprite;

        Coin()
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
        }
    }
}
