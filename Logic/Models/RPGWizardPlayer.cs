using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGWizardPlayer : RPGPlayerBase
    {

        private List<RPGEffect> _activeEffects;


        private int _instantDamage;
        private int _instantArmor;
        private int _mana;
        private int _totalManaSpent;
        private RPGSpell _lastChoosenSpellToCast;
        private readonly List<RPGSpell> _availableSpells;

        public RPGWizardPlayer(int initialHitPoints, int initalMana, List<RPGSpell> availableSpells)
        {
            HitPoints = initialHitPoints;
            _mana = initalMana;
            _totalManaSpent = 0;

            _activeEffects = new List<RPGEffect>();
            _availableSpells = availableSpells;
        }

        public override int GetPlayerDamage()
        {
            int effectsDamage = GetTotalEffectsDamage();
            return _instantDamage + effectsDamage;
        }

        public override int GetPlayerArmor()
        {
            int effectsArmor = GetTotalEffectsArmor();
            return _instantArmor + effectsArmor;
        }

        public void PlayMyTurn()
        {
          
            _lastChoosenSpellToCast = ChooseSpellToCast();

            if (!_lastChoosenSpellToCast.IsEffect)
            {
                _instantDamage = _lastChoosenSpellToCast.Damange;
                _instantArmor = _lastChoosenSpellToCast.Armor;
            }

          
            HitPoints += _lastChoosenSpellToCast.Heal;
            _mana -= _lastChoosenSpellToCast.ManaCost;
            _totalManaSpent += _lastChoosenSpellToCast.ManaCost;
           
        }

        public void CompleteTurn(RPGPlayerBase currAttacker = null) {

            UseActiveEffects(currAttacker);

            _activeEffects.ForEach(effect => effect.Timer--);
            //Remove elapsed effects 
            _activeEffects = _activeEffects.Where(effect => effect.Timer > 0).ToList();
          
            if (_lastChoosenSpellToCast != null &&  _lastChoosenSpellToCast.IsEffect)
            {
                _activeEffects.Add(new RPGEffect
                {
                    Name = _lastChoosenSpellToCast.Name,
                    Armor = _lastChoosenSpellToCast.Armor,
                    Timer = _lastChoosenSpellToCast.LastsForTurns,
                    Damange = _lastChoosenSpellToCast.Damange,
                    Mana = _lastChoosenSpellToCast.ManaRecharge,
                });

            }

            _lastChoosenSpellToCast = null;
            _instantArmor = 0;
            _instantDamage = 0;
        }

        private RPGSpell ChooseSpellToCast()
        {
            RPGSpell choosenSpellToCast;

          /*  if (_mana < 500)
            {
                choosenSpellToCast = ChooseSpellToCastPreferEffects(availableSpells);
            }
            else
            {
                choosenSpellToCast = ChooseSpellToCastLowestMana(availableSpells);
            }*/

            //RPGSpell choosenSpellToCast = ChooseSpellToCastPreferEffects(availableSpells);
            choosenSpellToCast = ChooseSpellToCastRandomly();
            //RPGSpell choosenSpellToCast = ChooseSpellToCastLowestMana(availableSpells);

            return choosenSpellToCast;
        }

        private RPGSpell ChooseSpellToCastLowestMana(List<RPGSpell> availableSpells)
        {
            List<RPGSpell> validSpellsToChooseFrom = availableSpells
                                    .Where(spell => !_activeEffects.Exists(effect => effect.Name == spell.Name) && _mana > spell.ManaCost)
                                    .OrderBy(spell => spell.ManaCost)
                                    .ToList();
         
            RPGSpell choosenSpellToCast = validSpellsToChooseFrom.First();

            return choosenSpellToCast;
        }


        private RPGSpell ChooseSpellToCastRandomly()
        {
            List<RPGSpell> validSpellsToChooseFrom = _availableSpells
                                    .Where(spell => !_activeEffects.Exists(effect => effect.Name == spell.Name) && _mana > spell.ManaCost)
                                    .ToList();

            var randomSpellIndex = new Random(DateTime.Now.Millisecond).Next(0, validSpellsToChooseFrom.Count);
            RPGSpell choosenSpellToCast = validSpellsToChooseFrom[randomSpellIndex];

            return choosenSpellToCast;
        }

        private RPGSpell ChooseSpellToCastPreferEffects(List<RPGSpell> availableSpells)
        {
            //Always prefer effects 
            List<RPGSpell> validEffectsToChooseFrom = availableSpells
            .Where(spell => spell.IsEffect && !_activeEffects.Exists(effect => effect.Name == spell.Name)
                            && _mana > spell.ManaCost)
            .ToList();

            //Recharge logic
            RPGSpell rechargeEffect = validEffectsToChooseFrom.FirstOrDefault(effect => effect.Name == "Recharge");
            if (rechargeEffect != null)
            {
              /*  if (Mana < 400)
                {*/
                    return rechargeEffect;

              /*  }
                else
                {
                    validEffectsToChooseFrom.Remove(rechargeEffect);
                }*/
            }

            if (validEffectsToChooseFrom.Count > 0)
            {
                var randomEffectIndex = new Random(DateTime.UtcNow.Millisecond)
                                         .Next(0, validEffectsToChooseFrom.Count);
                RPGSpell choosenEffectToCast = validEffectsToChooseFrom[randomEffectIndex];
                return choosenEffectToCast;

            } else //No valid effects to choose from
            {
                List<RPGSpell> validSpellsToChooseFrom = availableSpells.Where(spell => !spell.IsEffect & _mana > spell.ManaCost)
                                                    .ToList();

                //Choose a random spell index
                var randomSpellIndex = new Random(DateTime.UtcNow.Millisecond)
                                                .Next(0, validSpellsToChooseFrom.Count);
                RPGSpell choosenSpellToCast = validSpellsToChooseFrom[randomSpellIndex];

                return choosenSpellToCast;
            }
        }

        public int Mana => _mana;
        public int TotalManaSpent => _totalManaSpent;

        private void UseActiveEffects(RPGPlayerBase currAttacker = null)
        {
            //Update mana if it was not choosen in the current turn
            RPGEffect rechargeEffect = GetRechargeEffect();
            if (rechargeEffect != null)
            {
                _mana += rechargeEffect.Mana;
            }

            if (currAttacker != null)
            {
                //Deal effect damage
                int effectsDamage = GetTotalEffectsDamage();
                currAttacker.DealDamage(effectsDamage);
            }

        }

        private RPGEffect GetRechargeEffect()
        {
            return _activeEffects.FirstOrDefault(effect => effect.Name == "Recharge");
        }

        private int GetTotalEffectsDamage()
        {
            return _activeEffects.Where(effect => _lastChoosenSpellToCast == null 
                                                ||  effect.Name != _lastChoosenSpellToCast.Name)
                                .Sum(effect => effect.Damange);
        }

        private int GetTotalEffectsArmor()
        {
            return _activeEffects.Where(effect =>  _lastChoosenSpellToCast == null || effect.Name != _lastChoosenSpellToCast.Name)
                                .Sum(effect => effect.Armor);
        }
    }
}
