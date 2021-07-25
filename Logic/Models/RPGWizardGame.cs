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
        private bool _debugMode;

        public RPGWizardGame(RPGWizardPlayer player1, RPGStaticPlayer player2, bool debugMode = false) 
        {
            _player1 = player1;
            _player2 = player2;
            _store = new RPGGameStore();
            _currAttacker = _player1;

            MinPlayerMana = _store.GetAvailableSpells().Min(spell => spell.ManaCost);
            _availableStoreSpells = _store.GetAvailableSpells();
            _debugMode = debugMode;
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

            if (_debugMode)
            {
                if (_currAttacker == _player1)
                {
                    Console.WriteLine("-- Player turn --");
                }
                else
                {
                    Console.WriteLine("-- Boss  turn --");
                }

                Console.WriteLine($"- Player has {_player1.HitPoints} hit points, {_player1.GetPlayerArmor()} armor, {_player1.Mana} mana");
                Console.WriteLine($"- Boss has {_player2.HitPoints} hit points");

            }


            if (_currAttacker is RPGWizardPlayer)
            {
                _player1.StartTurn();

            } else //Boss turn
            {
                _player1.StartTurn(_player2);
            }

            int attackerDamage = _currAttacker.GetPlayerDamage();
            int defenderArmor = _currDefender.GetPlayerArmor();

            if (attackerDamage > 0)
            {
                int currAttackDamage = Math.Max((attackerDamage - defenderArmor), 1);
                _currDefender.DealDamage(currAttackDamage);

                if (_debugMode)
                {
                    if (_currAttacker == _player1)
                    {
                        Console.WriteLine($"Player deals {currAttackDamage} to the boss");
                    }
                    else
                    {
                        Console.WriteLine($"Boss deals {currAttackDamage} to the player");
                    }
                }
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
