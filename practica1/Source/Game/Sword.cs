using SFML.Graphics;
using SFML.System;
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

        public Sword() : base()
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
            _Sprite.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2f;
        }
    }
}
