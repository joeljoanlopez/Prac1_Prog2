using SFML.Graphics;
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

        Axe()
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
        }
    }
}
