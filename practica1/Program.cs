using TCEngine;

namespace TCGame
{
    public class App
    {
        public static void Main()
        {
            TecnoCampusEngine engine = new TecnoCampusEngine();
            engine.Run(new InventoryGame());
        }
    }
}
