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
        private string _TexPath = "Data/Textures/Sword.png";

        public Sword()
        {
            Texture = new Texture(_TexPath);
            Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2f;
        }
    }
}
