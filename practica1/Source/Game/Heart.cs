using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCGame
{
    internal class Heart : Item
    {
        private Texture _Texture;
        private string _TexPath = "Data/Textures/Heart.png";
        private Sprite _Sprite;

        Heart()
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
        }
    }
}
