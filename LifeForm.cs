using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TPEGW
{
    public class LifeForm
    {
        private string id;
        private float baseHealth;
        private float baseStrength;
        private float baseAgility;
        private float baseEndurance;
        private float baseIntellect;
        private float baseSpeed;
        private Collection<OffensiveItem> equipedOffensiveItems;
        private Collection<DefensiveItem> equipedDefensiveItems;
        private Collection<Item> equipedItems;

        public long nextActionTime;
        public float currentHealth = 100;




        public Collection<OffensiveItem> EquipedOffensiveItems { get => equipedOffensiveItems; set => equipedOffensiveItems = value; }
        public Collection<DefensiveItem> EquipedDefensiveItems { get => equipedDefensiveItems; set => equipedDefensiveItems = value; }
        public Collection<Item> EquipedItems { get => equipedItems; set => equipedItems = value; }
        public float BaseHealth { get => baseHealth; set => baseHealth = value; }
        public float BaseStrength { get => baseStrength; set => baseStrength = value; }
        public float BaseAgility { get => baseAgility; set => baseAgility = value; }
        public float BaseEndurance { get => baseEndurance; set => baseEndurance = value; }
        public float BaseIntellect { get => baseIntellect; set => baseIntellect = value; }
        public float BaseSpeed { get => baseSpeed; set => baseSpeed = value; }


        public float Health { get => baseHealth; }
        public float Strength { get => baseStrength; }
        public float Agility { get =>GetModifiedAgility(); }
        public float Intellect { get => GetModifiedIntellect(); }
        public float Speed { get => GetModifiedSpeed(); }
        public float Endurance { get => GetModifiedEndurance(); }

        public LifeForm()
        {
            baseEndurance = 50;
            baseStrength = 50;
            baseHealth = 100;
            id = Guid.NewGuid().ToString();
            baseAgility = 50;
            baseIntellect = 50;
            baseSpeed = 50;
            equipedOffensiveItems = new Collection<OffensiveItem>();
            equipedDefensiveItems = new Collection<DefensiveItem>();
            equipedItems = new Collection<Item>();

            nextActionTime = Convert.ToInt64(Speed);

        }

        private float GetModifiedEndurance()
        {
            float modifiedValue = baseEndurance;
            float percentageModifier = 0;

            foreach (var offensiveItem in equipedOffensiveItems)
            {
                foreach (var currentModifier in offensiveItem.Modifiers)
                {
                    percentageModifier += currentModifier.Endurance;
                }

            }

            foreach (var defensiveItem in equipedDefensiveItems)
            {
                foreach (var currentModifier in defensiveItem.Modifiers)
                {
                    percentageModifier += currentModifier.Endurance;
                }

            }

            foreach (var regularItem in equipedItems)
            {
                foreach (var currentModifier in regularItem.Modifiers)
                {
                    percentageModifier += currentModifier.Endurance;
                }

            }

            modifiedValue += modifiedValue * (percentageModifier / 100);


            return modifiedValue;
        }

        private float GetModifiedSpeed()
        {
            float modifiedValue = baseSpeed;
            float percentageModifier = 0;

            foreach (var offensiveItem in equipedOffensiveItems)
            {
                foreach (var currentModifier in offensiveItem.Modifiers)
                {
                    percentageModifier += currentModifier.Speed;
                }

            }

            foreach (var defensiveItem in equipedDefensiveItems)
            {
                foreach (var currentModifier in defensiveItem.Modifiers)
                {
                    percentageModifier += currentModifier.Speed;
                }

            }

            foreach (var regularItem in equipedItems)
            {
                foreach (var currentModifier in regularItem.Modifiers)
                {
                    percentageModifier += currentModifier.Speed;
                }

            }

            modifiedValue += modifiedValue * (percentageModifier / 100);


            return modifiedValue;
        }

        private float GetModifiedAgility()
        {
            float modifiedValue = baseAgility;
            float percentageModifier = 0;

            foreach (var offensiveItem in equipedOffensiveItems)
            {
                foreach (var currentModifier in offensiveItem.Modifiers)
                {
                    percentageModifier += currentModifier.Agility;
                }

            }

            foreach (var defensiveItem in equipedDefensiveItems)
            {
                foreach (var currentModifier in defensiveItem.Modifiers)
                {
                    percentageModifier += currentModifier.Agility;
                }

            }

            foreach (var regularItem in equipedItems)
            {
                foreach (var currentModifier in regularItem.Modifiers)
                {
                    percentageModifier += currentModifier.Agility;
                }

            }

            modifiedValue += modifiedValue * (percentageModifier / 100);


            return modifiedValue;
        }

        private float GetModifiedIntellect()
        {
            float modifiedValue = baseIntellect;
            float percentageModifier = 0;

            foreach (var offensiveItem in equipedOffensiveItems)
            {
                foreach (var currentModifier in offensiveItem.Modifiers)
                {
                    percentageModifier += currentModifier.Intellect;
                }

            }

            foreach (var defensiveItem in equipedDefensiveItems)
            {
                foreach (var currentModifier in defensiveItem.Modifiers)
                {
                    percentageModifier += currentModifier.Intellect;
                }

            }

            foreach (var regularItem in equipedItems)
            {
                foreach (var currentModifier in regularItem.Modifiers)
                {
                    percentageModifier += currentModifier.Intellect;
                }

            }

            modifiedValue += modifiedValue * (percentageModifier / 100);


            return modifiedValue;
        }

        

    }
}
