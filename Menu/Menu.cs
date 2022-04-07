using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace RockScissorsPaper
{
    internal class Menu
    {
        private String[] _moves;
        private String[][] _table;
        private String _hmacComp;
        public Menu(String[] str, String hmacComp)
        {
            _moves = str;
            _hmacComp = hmacComp;
        }
        public void PrintMainMenu() 
        {
            Console.WriteLine("HMAC: " + _hmacComp);
            Console.WriteLine("Available moves:");
            for (int i = 0; i < _moves.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + _moves[i]);
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move:");
        }
        public void PrintHelpMenu()
        {
            GenTable();
            var tb = new ConsoleTable(_table[0]);
            for (int i = 1; i < _table.Length; i++) 
            {
                tb.AddRow(_table[i]);
            }            
            tb.Write();           
        }

        private void GenTable() 
        {
            _table = new String[_moves.Length + 1][];
            for (int i = 0; i <= _moves.Length; i++) 
            {
                _table[i] = new String[_moves.Length + 1]; 
                for (int j = 0; j <= _moves.Length; j++) 
                {
                    if (i == j && j != 0)
                    {
                        _table[i][j] = "Draw";
                    }
                    else if (i == 0 && j > 0 && j <= _moves.Length)
                    {
                        _table[i][j] = _moves[j - 1];
                        continue;
                    }
                    else if (j == 0 && i > 0 && i <= _moves.Length)
                    {
                        _table[i][j] = _moves[i - 1];
                        continue;
                    }
                    else if (Math.Abs(i - j) <= (_moves.Length - 1) / 2 && j != 0 )
                    {
                        if (i > j)
                        {
                            _table[i][j] = "Lose";
                        }
                        else 
                        {
                            _table[i][j] = "Win";
                        }
                        
                    }
                    else if (i != 0 && j != 0 )
                    {
                        if (i > j)
                        {
                            _table[i][j] = "Win";
                        }
                        else
                        {
                            _table[i][j] = "Lose";
                        }
                    }
                }
            }
        }
    }
}
