using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGWizardGame : RPGGameBase<RPGWizardPlayer, RPGPlayer>
    {

        private RPGGameStore _store;
        private readonly int MinPlayerMana;

        public RPGWizardGame(RPGWizardPlayer player1, RPGStaticPlayer player2) 
        {
            _player1 = player1;
            _player2 = player2;
            _store = new RPGGameStore();
            _currAttacker = _player1;

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

            if (_currAttacker is RPGWizardPlayer)
            {
                List<RPGSpell> availableSpells = _store.GetAvailableSpells();
                ((RPGWizardPlayer)_currAttacker).PlayMyTurn(availableSpells);
            } else
            {
                ((RPGWizardPlayer)_currDefender).PlayOpponentTurn(_currAttacker);
            }

            int attackerDamage = _currAttacker.GetPlayerDamage();
            int defenderArmor = _currDefender.GetPlayerArmor();

            if (attackerDamage > 0)
            {
                int currAttackDamage = Math.Max((attackerDamage - defenderArmor), 1);
                _currDefender.DealDamage(currAttackDamage);
            }

            SwitchPlayersRole();
        }
    }
}
