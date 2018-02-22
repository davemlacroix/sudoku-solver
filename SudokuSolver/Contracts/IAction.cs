using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Contracts
{
    public interface IAction
    {
        bool Execute(ISegmentIterator iterator);
    }
}
