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
        private readonly List<RPGSpell> _availableStoreSpells;

        public RPGWizardGame(RPGWizardPlayer player1, RPGStaticPlayer player2) 
        {
            _player1 = player1;
            _player2 = player2;
            _store = new RPGGameStore();
            _currAttacker = _player1;

            MinPlayerMana = _store.GetAvailableSpells().Min(spell => spell.ManaCost);
            _availableStoreSpells = _store.GetAvailableSpells();
        }


        /// <summary>
        /// Plays the game
        /// </summary>
        /// <returns>The winner of the game</returns>
        public RPGPlayerBase PlayGame()
        {
            while((_player1 == _currDefender || _player1.Mana >= MinPlayerMana) 
                && _player1.HitPoints > 0 
                && _player2.HitPoints > 0)
            {
                PlaySingleGameTurn();
            }

            return (_player2.HitPoints > 0) ? (RPGPlayerBase)_player2 : _player1;
        }

        private void PlaySingleGameTurn()
        {

            if (_currAttacker is RPGWizardPlayer)
            {
                ((RPGWizardPlayer)_currAttacker).PlayMyTurn();
            } 

            int attackerDamage = _currAttacker.GetPlayerDamage();
            int defenderArmor = _currDefender.GetPlayerArmor();

            if (attackerDamage > 0)
            {
                int currAttackDamage = Math.Max((attackerDamage - defenderArmor), 1);
                _currDefender.DealDamage(currAttackDamage);
            }

            if (_currAttacker is RPGWizardPlayer)
            {
                _player1.CompleteTurn();

            }  else
            {
                _player1.CompleteTurn(_currAttacker);
            }

            SwitchPlayersRole();
        }
    }
}
