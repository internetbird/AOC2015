using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public abstract class RPGGameBase<P1, P2> where P1 : RPGPlayerBase 
                                              where  P2: RPGPlayerBase
    {
        protected P1 _player1;
        protected P2 _player2;

        protected RPGPlayerBase _currAttacker;
        protected RPGPlayerBase _currDefender {
            get
            {
                if (_currAttacker == _player1)
                {
                    return _player2;
                } else
                {
                    return _player1;
                }
            }
        } 

        protected void SwitchPlayersRole()
        {
            if (_currAttacker == _player1)
            {
                _currAttacker = _player2;
            }
            else
            {
                _currAttacker = _player1;
            }
        }

    }
}
