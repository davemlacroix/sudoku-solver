namespace SudokuSolver.SudokuPuzzle
{
    public class CellValue
    {
        public static readonly CellValue Unknown = new CellValue(0);
        public static readonly CellValue One = new CellValue(1);
        public static readonly CellValue Two = new CellValue(2);
        public static readonly CellValue Three = new CellValue(3);
        public static readonly CellValue Four = new CellValue(4);
        public static readonly CellValue Five = new CellValue(5);
        public static readonly CellValue Six = new CellValue(6);
        public static readonly CellValue Seven = new CellValue(7);
        public static readonly CellValue Eight = new CellValue(8);
        public static readonly CellValue Nine = new CellValue(9);

        private int _value;

        public CellValue()
        {
            _value = 0;
        }

        public CellValue(int value)
        {
            Value = value;
        }

        public int Value
        {
            get => _value;
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new System.ArgumentOutOfRangeException("CellValue was set to an invalid value of " + value + ".");
                }
                _value = value;
            }
        }
    }
}
