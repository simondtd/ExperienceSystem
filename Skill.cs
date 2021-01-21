using System;

namespace ExperienceSystem
{
    public class Skill
    {
        private readonly int _baseExperience;
        private readonly int _maxLevel;
        private readonly float _exponential;
        private int _experience;

        public int Experience
        {
            get => _experience;
            set => _experience = value;
        }

        public Skill(int baseExperience, float exponential, int maxLevel = int.MaxValue)
        {
            _baseExperience = baseExperience;
            _exponential = exponential;
            _experience = 0;
            _maxLevel = maxLevel;
        }

        public int BaseExperience => _baseExperience;
        public int MaxLevel => _maxLevel;
        public float Exponential => _exponential;
        public int Level => ExperienceToLevel(_experience);

        public int MaxExperienceForLevel(int level)
        {
            if (level <= 0)
                return 0;

            var experience = _baseExperience * Math.Pow(_exponential, Math.Clamp(level, 0, _maxLevel) - 1);
            return (int)experience;
        }

        public int LevelToExperience(int level)
        {
            var experience = 0;
            for(int i = 0; i <= level; i++) {
                experience += MaxExperienceForLevel(i);
            }
            return experience;
        }

        public int ExperienceToLevel(int experience)
        {
            var level = 0;

            while (experience >= 0)
            {
                experience -= MaxExperienceForLevel(level);
                if (experience >= 0)
                    level++;
            }

            return level - 1;
        }
    }
}