namespace Documentation_And_Unit_Testing
{
    /// <summary>
    /// Represents a 2D grid for movement and collision detection.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// The width of the grid.
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// The height of the grid.
        /// </summary>
        public int Height { get; private set; }
        private bool[,] grid;
        private List<Box> boxes = new List<Box>();

        /// <summary>
        /// Constructor for creating a new grid with the given dimensions.
        /// </summary>
        /// <param name="width">The width of the grid.</param>
        /// <param name="height">The height of the grid.</param>
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new bool[width, height];

            // Populate the grid with walkable tiles.
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = true;
                }
            }
        }

        /// <summary>
        /// Sets a tile to be walkable or non-walkable.
        /// </summary>
        /// <param name="position">The position of the tile.</param>
        /// <param name="walkable">True if tile is walkable, false otherwise.</param>
        public void SetWalkable(Point position, bool walkable)
        {
            grid[position.X, position.Y] = walkable;
        }

        /// <summary>
        /// Check if a tile is walkable.
        /// </summary>
        /// <param name="position">The position of the tile.</param>
        /// <returns>True if the tile is walkable, false otherwise.</returns>
        public bool IsWalkable(Point position)
        {
            if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height)
            {
                return false;
            }
            return grid[position.X, position.Y];
        }

        /// <summary>
        /// Method for placing a box on the grid.
        /// </summary>
        /// <param name="box">The box to be placed.</param>
        public void PlaceBox(Box box)
        {
            boxes.Add(box);
        }

        /// <summary>
        /// Method for checking if a box is at a specific position.
        /// </summary>
        /// <param name="position">Position to check for a box.</param>
        /// <returns>Returns true if box is at position, otherwise returns false.</returns>
        public bool IsBoxAt(Point position)
        {
            return boxes.Any(box => box.Position.Equals(position));
        }
    }

    /// <summary>
    /// Represents possible directions of movement.
    /// </summary>
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    /// <summary>
    /// Represents a point in 2D space.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        public int X;
        /// <summary>
        /// The Y coordinate.
        /// </summary>
        public int Y;

        /// <summary>
        /// Constructs a new point with the given coordinates.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
