namespace Minesweeper
{
    public class FieldCell
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int NeighboursIsBombCount { get; set; }
        public bool IsBomb { get; set; }
    }
}
