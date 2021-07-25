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
        private bool _debug = false;

        public RPGWizardPlayer(int initialHitPoints, int initalMana, List<RPGSpell> availableSpells, bool debug = false)
        {
            HitPoints = initialHitPoints;
            _mana = initalMana;
            _totalManaSpent = 0;

            _activeEffects = new List<RPGEffect>();
            _availableSpells = availableSpells;
            _debug = debug;
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

        public void StartTurn(RPGPlayerBase boss = null)
        {
            UseActiveEffects(boss);

            if (boss == null) //My turn, choose a spell to case
            {
                _lastChoosenSpellToCast = ChooseSpellToCast();

                if (_debug)
                {
                    Console.WriteLine($"Player casts {_lastChoosenSpellToCast.Name}.");
                }

                if (!_lastChoosenSpellToCast.IsEffect)
                {
                    _instantDamage = _lastChoosenSpellToCast.Damange;
                    _instantArmor = _lastChoosenSpellToCast.Armor;
                }


                HitPoints += _lastChoosenSpellToCast.Heal;
                _mana -= _lastChoosenSpellToCast.ManaCost;
                _totalManaSpent += _lastChoosenSpellToCast.ManaCost;
            }
        }

        public void CompleteTurn(RPGPlayerBase boss = null) {

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

            if (_debug)
            {
                if (_activeEffects.Count > 0)
                {
                    Console.WriteLine("At the end of this turn the player has the following active effects:");

                    foreach (RPGEffect effect in _activeEffects)
                    {
                        Console.WriteLine($"** {effect.Name} ** with timer: {effect.Timer}");
                    }
                } else
                {
                    Console.WriteLine("At the end of this turn the player has no active effects");
                }
            }

            _lastChoosenSpellToCast = null;
            _instantArmor = 0;
            _instantDamage = 0;
        }

        private RPGSpell ChooseSpellToCast()
        {
            RPGSpell choosenSpellToCast;

            RPGSpell rechargeSpell = _availableSpells.First(spell => spell.Name == "Recharge");

            if (_mana <= 400 && _mana >= rechargeSpell.ManaCost && GetRechargeEffect() == null)
            {
                return rechargeSpell;
            }

            if (_mana > 400)
            {
                choosenSpellToCast = ChooseSpellToCastPreferEffects();
            }
            else
            {
                if (_mana < 200)
                {
                    choosenSpellToCast = ChooseSpellToCastLowestMana();
                } else
                {
                    choosenSpellToCast = ChooseSpellToCastRandomly();
                }
            }

            //choosenSpellToCast = ChooseSpellToCastPreferEffects();
            //choosenSpellToCast = ChooseSpellToCastRandomly();
            //RPGSpell choosenSpellToCast = ChooseSpellToCastLowestMana(availableSpells);

            return choosenSpellToCast;
        }

        private RPGSpell ChooseSpellToCastLowestMana()
        {
            List<RPGSpell> validSpellsToChooseFrom = _availableSpells
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

            var randomSpellIndex =  DateTime.UtcNow.Millisecond % validSpellsToChooseFrom.Count;
            RPGSpell choosenSpellToCast = validSpellsToChooseFrom[randomSpellIndex];

            return choosenSpellToCast;
        }

        private RPGSpell ChooseSpellToCastPreferEffects()
        {
            //Always prefer effects 
            List<RPGSpell> validEffectsToChooseFrom = _availableSpells
            .Where(spell => spell.IsEffect && !_activeEffects.Exists(effect => effect.Name == spell.Name) && spell.Name != "Recharge"
                            && _mana > spell.ManaCost)
            .ToList();


            if (validEffectsToChooseFrom.Count > 0)
            {
                var randomEffectIndex = DateTime.UtcNow.Millisecond % validEffectsToChooseFrom.Count;
                RPGSpell choosenEffectToCast = validEffectsToChooseFrom[randomEffectIndex];
                return choosenEffectToCast;

            } else //No valid effects to choose from
            {
                List<RPGSpell> validSpellsToChooseFrom = _availableSpells.Where(spell => !spell.IsEffect & _mana > spell.ManaCost)
                                                    .ToList();

                //Choose a random spell index
                var randomSpellIndex =  DateTime.UtcNow.Millisecond % validSpellsToChooseFrom.Count;
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
                if (_debug)
                {
                    Console.WriteLine($"Recharge provides {rechargeEffect.Mana} mana");
                }
            }

            if (currAttacker != null)
            {
                //Deal effect damage
                int effectsDamage = GetTotalEffectsDamage();

                if (effectsDamage > 0 && _debug)
                {
                    Console.WriteLine($"Dealing boss {effectsDamage} damage from effects");
                }

                currAttacker.DealDamage(effectsDamage);
            }

        }

        private RPGEffect GetRechargeEffect()
        {
            return _activeEffects.FirstOrDefault(effect => effect.Name == "Recharge");
        }

        private int GetTotalEffectsDamage()
        {
            return _activeEffects.Sum(effect => effect.Damange);
        }

        private int GetTotalEffectsArmor()
        {
            return _activeEffects.Sum(effect => effect.Armor);
        }
    }
}
