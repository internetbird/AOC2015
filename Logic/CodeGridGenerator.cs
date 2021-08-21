using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic
{
    public class CodeGridGenerator
    {
        public const ulong InitialCode = 20151125;

        private int _currRow;
        private int _currColumn;
        private int _currDiagonal;
        private ulong _lastCode;

        public CodeGridGenerator()
        {
            _currRow = 2;
            _currColumn = 1;
            _currDiagonal = 2;
            _lastCode = InitialCode;
        }


        public ulong GetCodeAtPosition(int row, int column)
        {
            while(_currRow != row || _currColumn != column)
            {
                _lastCode = CalculateNextCode();
                MoveToNextPosition();
            }

            return CalculateNextCode();

        }

        private void MoveToNextPosition()
        {
            if (_currRow > 1)
            {
                _currRow--;
                _currColumn++;
            } else
            {
                _currRow = _currDiagonal + 1;
                _currColumn = 1;
                _currDiagonal++;
            }
        }

        private ulong CalculateNextCode()
        {
            return (_lastCode * 252533) % 33554393;
        }
    }
}
