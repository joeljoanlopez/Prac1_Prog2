using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica1.Source.Game
{
    internal class Axe : Weapon
    {
        private Texture _Texture;
        private string _TexPath = "Data/Textures/Axe.png";
        private Sprite _Sprite;

        public Axe() : base("Axe")
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
            _Sprite.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2f;
        }
    }
}
