using SFML.Graphics;

namespace TCEngine
{
    public interface Game
    {
        void Init(RenderWindow _window);
        void DeInit();
        void Update(float _dt);
        void Draw(RenderWindow _window);
    }
}
