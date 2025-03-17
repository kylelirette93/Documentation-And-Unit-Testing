using Documentation_And_Unit_Testing;

namespace UnitTests
{
    /// <summary>
    /// Unit test class for the player character.
    /// </summary>
    public class PlayerTests
    {
        private Grid grid;
        private Player player;

        /// <summary>
        /// Test setup method, initializes the grid and player.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            grid = new Grid(10, 10);
            player = new Player(new Point(5, 5), grid);
        }

        /// <summary>
        /// Test method for incrementing the player's x-coordinate by 1.
        /// </summary>
        [Test]
        public void Player_MovesRight_Pass()
        {
            // Arrange
            var initialX = player.Position.X; 

            // Act
            player.TryMove(Direction.Right); 

            // Assert
            // If the player moves right, the x-coordinate should increase by 1, therefore test will pass.
            Assert.AreEqual(initialX + 1, player.Position.X);
        }

        /// <summary>
        /// Test method for incrementing the player's x-coordinate by 2.
        /// </summary>
        [Test]
        public void Player_MovesRight_Fail()
        {
            // Arrange
            var initialX = player.Position.X;

            // Act
            player.TryMove(Direction.Right);

            // Assert
            // If the player moves right, the x-coordinate should increase by 2, therefore test will fail.
            Assert.AreEqual(initialX + 2, player.Position.X);
        }

        /// <summary>
        /// Test method for decrementing the player's x-coordinate by 1.
        /// </summary>
        [Test]
        public void Player_MovesLeft_Pass()
        {
            // Arrange
            var initialX = player.Position.X;

            // Act
            player.TryMove(Direction.Left);

            // Assert
            // If the player moves left, the x-coordinate should decrease by 1, therefore test will pass.
            Assert.AreEqual(initialX - 1, player.Position.X);
        }
        /// <summary>
        /// Test method for decrementing the player's x-coordinate by 2.
        /// </summary>
        [Test]
        public void Player_MovesLeft_Fail()
        {
            // Arrange
            var initialX = player.Position.X;

            // Act
            player.TryMove(Direction.Left);

            // Assert
            // If the player moves left, the x-coordinate should decrease by 2, therefore test will fail.
            Assert.AreEqual(initialX - 2, player.Position.X);
        }

        /// <summary>
        /// Test method for decrementing the player's y-coordinate by 1.
        /// </summary>
        [Test]
        public void Player_MovesUp_Pass()
        {
            // Arrange
            var initialY = player.Position.Y;

            // Act
            player.TryMove(Direction.Up);

            // Assert
            // If the player moves up, the y-coordinate should decrease by 1, therefore test will pass.
            Assert.AreEqual(initialY - 1, player.Position.Y);
        }

        /// <summary>
        /// Test method for decrementing the player's y-coordinate by 2.
        /// </summary>
        [Test]
        public void Player_MovesUp_Fail()
        {
            // Arrange
            var initialY = player.Position.Y;

            // Act
            player.TryMove(Direction.Up);

            // Assert
            // If the player moves up, the y-coordinate should decrease by 2, therefore test will fail.
            Assert.AreEqual(initialY - 2, player.Position.Y);
        }

        /// <summary>
        /// Test method for incrementing the player's y-coordinate by 1.
        /// </summary>
        [Test]
        public void Player_MovesDown_Pass()
        {
            // Arrange
            var initialY = player.Position.Y;

            // Act
            player.TryMove(Direction.Down);

            // Assert
            // If the player moves down, the y-coordinate should increase by 1, therefore test will pass.
            Assert.AreEqual(initialY + 1, player.Position.Y);
        }

        /// <summary>
        /// Test method for incrementing the player's y-coordinate by 2.
        /// </summary>
        [Test]
        public void Player_MovesDown_Fail()
        {
            // Arrange
            var initialY = player.Position.Y;

            // Act
            player.TryMove(Direction.Down);

            // Assert
            // If the player moves down, the y-coordinate should increase by 2, therefore test will fail.
            Assert.AreEqual(initialY + 2, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player right into a wall.
        /// </summary>
        [Test]
        public void Player_MoveRight_WallCollision_PositionNotUpdated()
        {
            // Arrange
            grid.SetWalkable(new Point(6, 5), false);

            // Act
            player.TryMove(Direction.Right);

            // Assert
            // Player should not be able to move right into a wall, therefore test will pass.
            Assert.AreEqual(5, player.Position.X); 
            Assert.AreEqual(5, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player left into a wall.
        /// </summary>
        [Test]
        public void Player_MoveLeft_WallCollision_PositionNotUpdated()
        {
            // Arrange
            grid.SetWalkable(new Point(4, 5), false);

            // Act
            player.TryMove(Direction.Left);

            // Assert
            // Player should not be able to move left into a wall, therefore test will pass.
            Assert.AreEqual(5, player.Position.X);
            Assert.AreEqual(5, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player up into a wall.
        /// </summary>
        [Test]
        public void Player_MoveUp_WallCollision_PositionNotUpdated()
        {
            // Arrange
            grid.SetWalkable(new Point(5, 4), false);

            // Act
            player.TryMove(Direction.Up);

            // Assert
            // Player should not be able to move up into a wall, therefore test will pass.
            Assert.AreEqual(5, player.Position.X);
            Assert.AreEqual(5, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player down into a wall.
        /// </summary>
        [Test]
        public void Player_MoveDown_WallCollision_PositionNotUpdated()
        {
            // Arrange
            grid.SetWalkable(new Point(5, 6), false);

            // Act
            player.TryMove(Direction.Down);

            // Assert
            // Player should not be able to move up into a wall, therefore test will pass.
            Assert.AreEqual(5, player.Position.X);
            Assert.AreEqual(5, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player top-left outside the grid.
        /// </summary>
        [Test]
        public void Player_MovesOutsideGrid_TopLeft_PositionNotUpdated()
        {
            // Arrange
            player = new Player(new Point(0, 0), grid);
            
            // Act
            player.TryMove(Direction.Left);
            
            // Assert
            // Player should not be able to move out of the top left corner of the grid, therfore test will pass.
            Assert.AreEqual(0, player.Position.X);
            Assert.AreEqual(0, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player top-right outside the grid.
        /// </summary>
        [Test]
        public void Player_MovesOutsideGrid_TopRight_PositionNotUpdated()
        {
            // Arrange
            player = new Player(new Point(9, 0), grid);

            // Act
            player.TryMove(Direction.Right);

            // Assert
            // Player should not be able to move out of the top right corner of the grid, therfore test will pass.
            Assert.AreEqual(9, player.Position.X);
            Assert.AreEqual(0, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player bottom-left outside the grid.
        /// </summary>
        [Test]
        public void Player_MovesOutsideGrid_BottomLeft_PositionNotUpdated()
        {
            // Arrange
            player = new Player(new Point(0, 9), grid);

            // Act
            player.TryMove(Direction.Left);

            // Assert
            // Player should not be able to move out of the bottom left corner of the grid, therfore test will pass.
            Assert.AreEqual(0, player.Position.X);
            Assert.AreEqual(9, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player bottom-right outside the grid.
        /// </summary>
        [Test]
        public void Player_MovesOutsideGrid_BottomRight_PositionNotUpdated()
        {
            // Arrange
            player = new Player(new Point(9, 9), grid);

            // Act
            player.TryMove(Direction.Right);

            // Assert
            // Player should not be able to move out of the bottom right corner of the grid, therfore test will pass.
            Assert.AreEqual(9, player.Position.X);
            Assert.AreEqual(9, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player from the corner of the grid.
        /// </summary>
        [Test]
        public void Player_MoveFromCorner_PositionUpdatedCorrectly()
        {
            // Arrange
            player = new Player(new Point(0, 0), grid);

            // Act
            player.TryMove(Direction.Right);
            player.TryMove(Direction.Down);

            // Assert
            // Player should be able to move right and down from the corner, therefore test will pass.
            Assert.AreEqual(1, player.Position.X);
            Assert.AreEqual(1, player.Position.Y);

        }

        /// <summary>
        /// Test method for repeated movement attempts into a wall.
        /// </summary>
        [Test]
        public void Player_RepeatedMoveRight_WallCollision_PositionNotUpdated()
        {
            // Arrange
            grid.SetWalkable(new Point(6, 5), false); 
            int initialX = player.Position.X;
            int initialY = player.Position.Y;

            // Act
            // Attempt 5 consecutive movements.
            for (int i = 0; i < 5; i++) 
            {
                player.TryMove(Direction.Right);
            }

            // Assert
            // Player should not move after repeated attempts into a wall, therefore test will pass.
            Assert.AreEqual(initialX, player.Position.X);
            Assert.AreEqual(initialY, player.Position.Y);
        }

        /// <summary>
        /// Test method for moving the player into a box.
        /// </summary>
        [Test]
        public void Player_CollidesWithBox_PositionNotUpdated()
        {
            // Arrange
            Box box = new Box(new Point(6, 5));
            grid.PlaceBox(box);
            player = new Player(new Point(5, 5), grid);

            // Act
            player.TryMove(Direction.Right);

            // Assert
            // Player should not move into a box, therefore test will pass.
            Assert.AreEqual(5, player.Position.X);
            Assert.AreEqual(5, player.Position.Y);
        }
    }
}