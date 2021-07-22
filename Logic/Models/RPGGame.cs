using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGGame : RPGGameBase<RPGPlayer, RPGPlayer>
    {

        public RPGGame(RPGPlayer player1, RPGPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;

            _currAttacker = _player1;
        }

        
        /// <summary>
        /// Plays the game in turns and returns the winner
        /// </summary>
        /// <returns></returns>
        public RPGPlayer PlayGame()
        {

            int roundNum = 1;

            while(_player1.HitPoints > 0 && _player2.HitPoints > 0)
            {
                PlaySingleGameTurn();
                roundNum++;
            }

            return _player1.HitPoints > 0 ? _player1 : _player2;
        }

        private void PlaySingleGameTurn()
        {
            int attackerDamage = _currAttacker.GetPlayerDamage();
            int defenderArmor = _currDefender.GetPlayerArmor();

            int currAttackDamage = Math.Max((attackerDamage - defenderArmor), 1);

            _currDefender.DealDamage(currAttackDamage);

            SwitchPlayersRole();
        }

      
    }
}
