using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockScissorsPaper
{
    internal class Roules
    {
        private String[] _moves;
        public Roules(String[] moves)
        { 
            this._moves = moves;
        }

        public String WhoWins(String move1, String move2)
        {
            int _indexMove1 = Array.IndexOf(_moves, move1);
            int _indexMove2 = Array.IndexOf(_moves, move2);
            int _numberOfMoves = _moves.Length;
            int[] _move1Loose = new int[(_numberOfMoves - 1) / 2];
            int _n = _indexMove1 - 1;
            for (int i = 0; i < _move1Loose.Length; i++)
            {                
                if (_n < 0) 
                {
                    _n = _moves.Length - 1;
                }
                _move1Loose[i] = _n--;
            }
            if (_move1Loose.Contains(_indexMove2))
            {
                return move2;
            }
            else if (_indexMove1 == _indexMove2)
            {
                return "draw";
            }
            else 
            {
                return move1;
            }
            
            
        }
    }
}
