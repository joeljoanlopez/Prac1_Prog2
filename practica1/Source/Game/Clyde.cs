using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCGame;

namespace practica1.Source.Game
{
    internal class Clyde : Item
    {
        private string _TexPath = "Data/Textures/Clyde.png";

        public Clyde()
        {
            Texture = new Texture(_TexPath);
            Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2f;
        }
    }
}
