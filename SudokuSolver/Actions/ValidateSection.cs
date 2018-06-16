
using SudokuSolver.Contracts;
using SudokuSolver.SudokuPuzzle;
using System;
using System.Collections.Generic;

namespace SudokuSolver.Actions
{
    public class ValidateSection : IAction
    {
        private bool _validated;
        private List<int> _values;

        public ValidateSection()
        {
            _validated = false;
        }

        public bool Execute(ISegmentIterator iterator)
        {
            _values = new List<int>();

            iterator.First();
            while (!iterator.IsDone())
            {
                var cell = iterator.GetCurrent();

                if (cell.Value != CellValue.Unknown.Value)
                {
                    if (_values.Exists(x => x == cell.Value))
                    {
                        _validated = false;
                        return false;
                    }
                    _values.Add(cell.Value);
                }

                iterator.Next();
            }
            _validated = true;
            return true;
        }

        public List<int> GetValues()
        {
            if(_validated)
            {
                return new List<int>(_values);
            }
            return new List<int>();
        }
    }
}
