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

        public RPGWizardPlayer(int initialHitPoints, int initalMana)
        {
            HitPoints = initialHitPoints;
            _mana = initalMana;
            _totalManaSpent = 0;

            _activeEffects = new List<RPGEffect>();
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

        public void PlayMyTurn(List<RPGSpell> availableSpells)
        {
            UpdateActiveEffects();

            RPGSpell choosenSpellToCast = ChooseSpellToCast(availableSpells);

            if (choosenSpellToCast.IsEffect) 
            {
                _activeEffects.Add(new RPGEffect
                {
                    Name = choosenSpellToCast.Name,
                    Armor = choosenSpellToCast.Armor,
                    Timer = choosenSpellToCast.LastsForTurns,
                    Damange = choosenSpellToCast.Damange,
                    Mana = choosenSpellToCast.ManaRecharge,
                    IsFirstTurn = true
                });

                _instantArmor = 0;
                _instantDamage = 0;
            }
            else //not an effect
            {
                _instantArmor = choosenSpellToCast.Armor;
                _instantDamage = choosenSpellToCast.Damange;
            }

            _mana -= choosenSpellToCast.ManaCost;
            _totalManaSpent += choosenSpellToCast.ManaCost;
        }

        private RPGSpell ChooseSpellToCast(List<RPGSpell> availableSpells)
        {
            //Always prefer effects 
            List<RPGSpell> validEffectsToChooseFrom = availableSpells
            .Where(spell => spell.IsEffect && !_activeEffects.Exists(effect => effect.Name == spell.Name)
                            && _mana > spell.ManaCost)
            .ToList();

            //Recharge logic
        /*    RPGSpell rechargeEffect = validEffectsToChooseFrom.FirstOrDefault(effect => effect.Name == "Recharge");
            if (rechargeEffect != null)
            {
                if (Mana < 350)
                {
                    return rechargeEffect;

                } else
                {
                    validEffectsToChooseFrom.Remove(rechargeEffect);
                }
            }*/

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

        public void PlayOpponentTurn(RPGPlayerBase _currAttacker)
        {
            UpdateActiveEffects();

            //Deal effect damage
            int effectsDamage = GetTotalEffectsDamage();
            _currAttacker.DealDamage(effectsDamage);
        }

        public int Mana => _mana;
        public int TotalManaSpent => _totalManaSpent;

        private void UpdateActiveEffects()
        {
            var rechargeManageEffect = _activeEffects.FirstOrDefault(effect => effect.Mana > 0);
            if (rechargeManageEffect != null)
            {
                _mana += rechargeManageEffect.Mana;
            }
            _activeEffects.ForEach(effect => effect.Timer--);
            _activeEffects.ForEach(effect => effect.IsFirstTurn = false);

            //Remove elapsed effects 
            _activeEffects = _activeEffects.Where(effect => effect.Timer > 0).ToList();
        }

        private int GetTotalEffectsDamage()
        {
            return _activeEffects.Where(effect => !effect.IsFirstTurn)
                                .Sum(effect => effect.Damange);
        }

        private int GetTotalEffectsArmor()
        {
            return _activeEffects.Where(effect => !effect.IsFirstTurn)
                                .Sum(effect => effect.Armor);
        }
    }
}
