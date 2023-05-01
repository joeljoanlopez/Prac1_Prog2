using SFML.Graphics;
using TCEngine;

namespace TCGame
{
    public class InventoryGame : Game
    {
        private Grid m_Grid;

        public void Init(RenderWindow _window)
        {
            // Grid initialization
            m_Grid = new Grid();
            m_Grid.Init();

            // Key Binding
            _window.KeyPressed += m_Grid.HandleKeyPressed;
        }

        public void DeInit()
        {
            m_Grid.DeInit();
        }

        public void Update(float dt)
        {
            m_Grid.Update(dt);
        }

        public void Draw(RenderWindow _window)
        {
            _window.Draw(m_Grid);
        }
    }
}

