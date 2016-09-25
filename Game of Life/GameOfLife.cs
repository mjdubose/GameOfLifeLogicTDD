using System;

namespace Game_of_Life
{
    public enum CellState
    {
        Alive,
        Dead,
    }

    public class GameOfLifeRules
    {
        public static CellState GetNewState(CellState currentState, int liveNeighbors)
        {
            if (liveNeighbors >= 9 || liveNeighbors < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(liveNeighbors),liveNeighbors,null);
            }

            switch (currentState)
            {
                case CellState.Alive:
                    if (liveNeighbors <2 || liveNeighbors > 3)
                        return CellState.Dead;
                    break;
                case CellState.Dead:
                    if (liveNeighbors == 3)
                        return CellState.Alive;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null);
            }

            return currentState;
        }
    }
}
