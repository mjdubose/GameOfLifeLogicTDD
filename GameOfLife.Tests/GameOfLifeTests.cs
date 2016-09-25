
using System;
using Game_of_Life;
using NUnit.Framework;


namespace GameOfLife.Tests
{


    //Any live cell with fewer than two live neighbours dies.
    //Any live cell with two or three lvie neighbors lives.
    //Any live cell with more than three live neighbours dies.
    //Any dead cell with exactly three live neighbours becomes a live cell.
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void LiveCell_FewerThan2LiveNeighborsDies([Values(0,1)] int liveNeighbors)
        {
            var currentState = CellState.Alive;


            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void LiveCell_With2or3LiveNeighborsLives([Values(2, 3)] int liveNeighbors)
        {
            var currentState = CellState.Alive;

            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]

        public void LiveCell_With_More_Than_3_Live_Cells_Dies([Range(4, 8)] int liveNeighbors)
        {
            var currentState = CellState.Alive;

            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void Dead_Cell_With_Exactly_3_Neighbors_Lives()
        {
            var liveNeighbors = 3;
            var currentState = CellState.Dead;

            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void Dead_Cell_With_Fewer_Than_3_Neighbors([Range(0,2)]int liveNeighbors)
        {
           var currentState = CellState.Dead;

            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Dead, newState);
        }
        [Test]
        public void Dead_Cell_With_More_Than_3_Neighbors([Range(4, 8)]int liveNeighbors)
        {
            var currentState = CellState.Dead;

            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CurrentState_When2_ThrowArgumentException()
        {
            var currentState = (CellState) 2;
            var liveNeighbors = 0;
            CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);
        }
        [Test]
        public void LiveNeighbors_More_Than_Eight_Throws_Argument_Exception()
        {
            var currentState = CellState.Alive;
            var liveNeighbors = 9;
            var paramName = "liveNeighbors";
            try
            {
                CellState newState = GameOfLifeRules.GetNewState(currentState, liveNeighbors);
                Assert.Fail("No Exception Thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                if (ex.ParamName != paramName)
                    Assert.Fail( $"Wrong parameter. Expected: '{paramName}', Actual: '{ex.ParamName}'");
                Assert.Pass();
                
            }  
        }
        [Test]
        public void LiveNeighbors_Less_Than_Zero_Throws_Argument_Exception()
        {
            var currentState = CellState.Alive;
            var liveNeighbors = -1;
            var paramName = "liveNeighbors";
          
         var ex =   Assert.Throws(typeof(ArgumentOutOfRangeException),() =>  GameOfLifeRules.GetNewState(currentState, liveNeighbors));

            if (((ArgumentOutOfRangeException)ex).ParamName != paramName)
            {
                Assert.Fail();
            }
        }

    }
}
