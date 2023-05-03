using SFML.Graphics;
using SFML.System;

namespace TCGame
{
    public abstract class Item : Sprite
    {
        private Sprite _Sprite;

        public Item()
        {
            _Sprite.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2;
        }

    }
}
