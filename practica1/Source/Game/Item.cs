using SFML.Graphics;
using SFML.System;

namespace TCGame
{
    public abstract class Item : Sprite
    {
        Texture myTexture;
        public Item() {
            this.Origin = new Vector2f(myTexture.Size.X/2, myTexture.Size.Y/2);
        }
    }
}
