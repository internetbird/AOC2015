using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGWizardGame
    {

        private RPGWizardPlayer _player1;
        private RPGStaticPlayer _player2;
        private RPGGameStore _store;
        private RPGPlayerBase _currentPlayer;

        private readonly int MinPlayerMana;


        public RPGWizardGame(RPGWizardPlayer player1, RPGStaticPlayer player2) 
        {
            _player1 = player1;
            _player2 = player2;
            _store = new RPGGameStore();
            _currentPlayer = _player1;

            MinPlayerMana = _store.GetAvailableSpells().Min(spell => spell.ManaCost);
        }


        /// <summary>
        /// Plays the game
        /// </summary>
        /// <returns>The winner of the game</returns>
        public RPGPlayerBase PlayGame()
        {
            while(_player1.Mana >= MinPlayerMana && _player1.HitPoints > 0 && _player2.HitPoints > 0)
            {
                PlaySingleGameTurn();
            }

            return (_player2.HitPoints > 0) ? (RPGPlayerBase)_player2 : _player1;
        }

        private void PlaySingleGameTurn()
        {
            int attackerDamage = _currentPlayer.GetPlayerDamage();

        }
    }
}
