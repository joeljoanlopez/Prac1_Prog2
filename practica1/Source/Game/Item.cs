using SFML.Graphics;
using SFML.System;

namespace TCGame
{
    public abstract class Item : Sprite
    {
        private Sprite _Sprite;
        private Texture _Texture;
        private string _Name;

        public Item()
        {
            
        }
    }
}
