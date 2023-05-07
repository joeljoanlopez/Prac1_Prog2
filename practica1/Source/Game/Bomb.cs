using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace TCGame
{
    internal class Bomb : Item
    {
        private string _TexPath = "Data/Textures/Bomb.png";

        public Bomb()
        {
            Texture = new Texture("Data/Textures/Bomb.png");
            Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2f;
        }
    }
}
