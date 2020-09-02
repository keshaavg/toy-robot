using System;

namespace ToyRobot
{
    /// <summary>
    /// Define Toy Robot position and direction on board. Also provides 
    /// methods to execute commannds MOVE, LEFT, RIGHT PLACE and REPORT.
    /// </summary>
    public class ToyRobot
    {
        // TODO: Make it configurable via config file and inject the values through DI.
        const int min = 0; // Min allowed value for X and Y  positions on board of 5*5
        const int max = 4; // Max allowed value for X and Y  positions on board of 5*5

        // The directions are stored in this particular order so left and right can be easily calculated.
        // This could have been replaced with doubly circular linekd list but for simplicity used arrays. 
        private readonly static  Direction[] directions = { 
            Direction.North, Direction.East, Direction.South, Direction.West };

        /// <summary>
        /// Gets or sets current value of toy robot position X on board
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Gets or sets the currect value of toy robot position Y on board
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Gets or sets current direction index of toy robot on board 
        /// </summary>
        public int DirectionIndex { get; private set; }

        /// <summary>
        /// Gets current direction of toy robot on board 
        /// </summary>
        public Direction Direction 
        {
            get { return directions[DirectionIndex]; }
        }


        public ToyRobot(int x, int y, Direction direction)
        {
            this.Place(x, y, direction);
        }
        /// <summary>
        /// Move toy robot one step at a time from current direction.
        /// Does nothing if action would result in breaching min and max allowed values
        /// on table so stoping Toy robot falling off from the table
        /// </summary>
        public void Move()
        {
            if (DirectionIndex == 0 && Y != max) Y += 1;
            if (DirectionIndex == 1 && X != max) X += 1;
            if (DirectionIndex == 2 && Y != min) Y -= 1;
            if (DirectionIndex == 3 && X!= min ) X -= 1;
        }

        /// <summary>
        /// Moves toy robot to left. The method supports circular array in reverse direction
        /// so to allowed to be called as many times without any side effects. 
        /// For ex - when left is invoked and toy robot facing North current direction will move to West. 
        /// Imporvements- If needed ROBOT can be stopped facing wrong side of toyRobot at the boundary on table. 
        /// </summary>
        public void Left()
        {
            var newIndex = DirectionIndex - 1;
            if (newIndex < 0) newIndex = newIndex + 4;
            DirectionIndex = newIndex;
        }

        /// <summary>
        /// Moves toy robot to left. The method supports circular array so to allowed to be called as many
        /// times without any side effects.
        /// For ex - when Right is invoked and toy robot facing West current direction will move to North. 
        /// Imporvements- If needed ROBOT can be stopped facing wrong side of toyRobot at the boundary on table. 
        /// </summary>
        public void Right()
        {
            DirectionIndex = (DirectionIndex + 1) % 4;
        }

        /// <summary>
        /// Prints on standard console current toy robot position along with its direction
        /// </summary>
        public string Report()
        {
            return $"Output: {X}, {Y}, {Direction}";
        }

        /// <summary>
        /// Initalises the toy robot on board position and direction. Can be set to any position 
        /// and direction on board within its defined boundary
        /// </summary>
        /// <param name="x">Postion X</param>
        /// <param name="y">Position Y</param>
        /// <param name="direction">Direction</param>
        public void Place(int x, int y, Direction direction)
        {
            #region Guards

            if (x < min || x > max)
            {
                throw new ArgumentOutOfRangeException("X", $"Please provide value of X between {min} and {max}, 'Format PLACE 0, 0, North'");
            }

            if (y < min || y > max)
            {
                throw new ArgumentOutOfRangeException("Y", $"Please provide value of Y between {min} and {max} 'Format PLACE 0, 0, North'");
            }

            if (direction == Direction.Unknown)
            {
                throw new ArgumentOutOfRangeException("Direction", $"Please provide valid value for Facing, Allowed values are North, South, West and East");
            }
            #endregion

            X = x;
            Y = y;
            DirectionIndex = (int) direction - 1;
        }
    }
}
