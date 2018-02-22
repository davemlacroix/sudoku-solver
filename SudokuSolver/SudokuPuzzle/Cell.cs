using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver.SudokuPuzzle
{
    public class Cell
    {
        private CellValue _cellValue;
        private List<CellValue> _candidates;

        public Cell()
        {
            _cellValue = CellValue.Unknown;
            _candidates = new List<CellValue>
            {
                CellValue.One,
                CellValue.Two,
                CellValue.Three,
                CellValue.Four,
                CellValue.Five,
                CellValue.Six,
                CellValue.Seven,
                CellValue.Eight,
                CellValue.Nine
            };
        }

        public Cell(int value)
        {
            _cellValue = new CellValue(value);
            if (value != CellValue.Unknown.Value)
            {
                _candidates = new List<CellValue>();
            }
            else
            {
                _candidates = new List<CellValue>
                {
                    CellValue.One,
                    CellValue.Two,
                    CellValue.Three,
                    CellValue.Four,
                    CellValue.Five,
                    CellValue.Six,
                    CellValue.Seven,
                    CellValue.Eight,
                    CellValue.Nine
                };
            }
        }

        public Cell(List<CellValue> candidates)
        {
            _cellValue = CellValue.Unknown;
            _candidates = candidates;

            SetValueIfOneCandidate();
        }

        public Cell(Cell cell)
        {
            _cellValue = new CellValue(cell.Value);
            _candidates = cell.Candidates;
        }

        public int Value
        {
            get => _cellValue.Value;
            set => _cellValue.Value = value;
        }

        public List<CellValue> Candidates
        {
            get => new List<CellValue>(_candidates);
        }

        public bool RemoveCandidate(int candidate)
        {
            var itemToRemove = _candidates.SingleOrDefault(x => x.Value == candidate);
            if (itemToRemove == null) { return false; }
            _candidates.Remove(itemToRemove);
            SetValueIfOneCandidate();
            return true;
        }

        private void SetValueIfOneCandidate()
        {
            if (_candidates.Count == 1)
            {
                _cellValue = _candidates.First();
                _candidates.RemoveAt(0);
            }
        }
    }
}
