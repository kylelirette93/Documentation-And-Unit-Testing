using System.Drawing;


namespace Documentation_And_Unit_Testing
{
    /// <summary>
    /// Represents a player character in the game world.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The current position of the player.
        /// </summary>
        public Point Position { get; private set; }
        private Grid grid;

        /// <summary>
        /// Constructor for creating a new player character.
        /// </summary>
        /// <param name="initialPosition">The initial position of the player.</param>
        /// <param name="grid">The grid the player is in.</param>
        public Player(Point initialPosition, Grid grid)
        {
            Position = initialPosition;
            this.grid = grid;
        }

        /// <summary>
        /// Attempts to move the player in a specific direction.
        /// </summary>
        /// <param name="direction">The direction to move.</param>
        /// <returns>Returns true if movement is successful, false if blocked.</returns>
        public bool TryMove(Direction direction)
        {
            Point newPosition = Position;

            switch (direction)
            {
                case Direction.Up:
                    newPosition.Y--;
                    break;
                case Direction.Down:
                    newPosition.Y++;
                    break;
                case Direction.Left:
                    newPosition.X--;
                    break;
                case Direction.Right:
                    newPosition.X++;
                    break;
            }

            // Additionally check if there is a box at the new position.
            if (grid.IsWalkable(newPosition) && !grid.IsBoxAt(newPosition))
            {
                Position = newPosition;
                return true;
            }
            return false;
        }
    }
}