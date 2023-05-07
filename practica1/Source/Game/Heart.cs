using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCGame
{
    internal class Heart : Item
    {
        private string _TexPath = "Data/Textures/Heart.png";

       public Heart()
        {
            Texture = new Texture(_TexPath);
            Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2f;
        }
    }
}
