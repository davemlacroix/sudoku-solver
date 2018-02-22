using SudokuSolver.Contracts;
using SudokuSolver.SudokuPuzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Actions
{
    public class ReduceCandidates : IAction
    {
        private List<int> _values;

        public bool Execute(ISegmentIterator iterator)
        {

            BuildValueList(iterator);

            return Reduce(iterator);
        }


        private void BuildValueList(ISegmentIterator iterator)
        {
            _values = new List<int>();

            iterator.First();
            while (iterator.HasNext())
            {
                var value = iterator.GetCurrent().Value;
                if (value != CellValue.Unknown.Value)
                {
                    _values.Add(value);
                }

                iterator.Next();
            }
        }

        private bool Reduce(ISegmentIterator iterator)
        {
            var finished = true;
            iterator.First();
            while (iterator.HasNext())
            {
                var cell = iterator.GetCurrent();

                foreach (int v in _values)
                {
                    if (cell.RemoveCandidate(v))
                    {
                        finished = false;
                    }
                }

                iterator.SetCurrent(cell);

               iterator.Next();
            }
            return finished;
        }
    }
}