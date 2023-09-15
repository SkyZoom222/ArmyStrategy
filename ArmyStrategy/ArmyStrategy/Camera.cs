using Microsoft.Xna.Framework;

namespace StrategyGame.ArmyStrategy
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Rectangle target)
        {
            var position = Matrix.CreateTranslation(
                -target.Location.X - (target.Size.X / 2),
                -target.Location.Y - (target.Size.Y / 2),
                0);

            var offset = Matrix.CreateTranslation(
                Game1.ScreenW / 2,
                Game1.ScreenH / 2,
                0);

            Transform = position * offset;
        }
    }
}
