using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica1.Source.Game
{
    internal class Sword : Weapon
    {
        private Texture _Texture;
        private string _TexPath = "Data/Textures/Sword.png";
        private Sprite _Sprite;

        public Sword()
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
        }
    }
}
