﻿using SFML.Graphics;
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
        private Texture _Texture;
        private string _TexPath = "Data/Textures/Clyde.png";
        private Sprite _Sprite;

        public Clyde() : base("Clyde")
        {
            _Texture = new Texture(_TexPath);
            _Sprite = new Sprite(_Texture);
            _Sprite.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2f;
        }
    }
}
