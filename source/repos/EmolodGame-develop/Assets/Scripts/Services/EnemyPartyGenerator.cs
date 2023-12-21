using Assets.Scripts.Entity.Characters;
using Assets.Scripts.Entity.Misc;
using Assets.Scripts.Services.Builders;
using System;
using System.Collections.Generic;
using static Assets.Scripts.Entity.Misc.Preset;

namespace Assets.Scripts.Services
{

    class EnemyPartyGenerator
    {
        public enum PresetType
        {
            BalanceParty,
            DamageParty,
            StandartParty
        }


        List<Preset> presets = null;
        public EnemyPartyGenerator()
        {
            presets = new List<Preset>();

            presets.Add(new Preset()
                .AddRole(Preset.EnemyRole.Tank)
                .AddRole(Preset.EnemyRole.DamageDealer)
                .AddRole(Preset.EnemyRole.DamageDealer)
                .AddRole(Preset.EnemyRole.Healer));

            presets.Add(new Preset()
                .AddRole(Preset.EnemyRole.DamageDealer)
                .AddRole(Preset.EnemyRole.DamageDealer)
                .AddRole(Preset.EnemyRole.DamageDealer)
                .AddRole(Preset.EnemyRole.DamageDealer));

            presets.Add(new Preset()
                .AddRole(Preset.EnemyRole.Tank)
                .AddRole(Preset.EnemyRole.DamageDealer)
                .AddRole(Preset.EnemyRole.DamageDealerMorale)
                .AddRole(Preset.EnemyRole.Healer));
        }

        private void choiceEnemy(EnemyBuilder enemyBuilder, EnemyRole enemyRole)
        {
            if (enemyRole == EnemyRole.Tank)
            {
                enemyBuilder.createTank();
            } 
            else if (enemyRole == EnemyRole.DamageDealer)
            {
                enemyBuilder.createDamageDealer();
            }
            else if (enemyRole == EnemyRole.Healer)
            {
                enemyBuilder.createHealer();
            }
            else if (enemyRole == EnemyRole.DamageDealerMorale)
            {
                enemyBuilder.createDamageDealerMorale();
            }
        }

        public List<Character> generateEnemyParty(int level, PresetType presetType = PresetType.BalanceParty)
        {
            EnemyBuilder enemyBuilder = new EnemyBuilder(level);

            foreach (Preset.EnemyRole enemyRole in presets[(int)presetType].getList())
            {
                choiceEnemy(enemyBuilder, enemyRole);
            }

            return enemyBuilder.getResult();
        }
    }
}
