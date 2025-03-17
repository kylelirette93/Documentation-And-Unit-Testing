
namespace Documentation_And_Unit_Testing
{
    /// <summary>
    /// Basic obstacle for testing collision detection.
    /// </summary>
    public class Box
    {
        public Point Position { get; set; }

        /// <summary>
        /// Constructor for creating a new box. Passing initial position.
        /// </summary>
        /// <param name="position"></param>
        public Box(Point position)
        {
            Position = position;
        }
    }
}
