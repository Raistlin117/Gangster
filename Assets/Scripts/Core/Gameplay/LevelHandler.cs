using UnityEngine;

namespace Core.Gameplay
{
    public class LevelHandler
    {
        private const string CurrentLevel = "CurrentLevel";
        private int _currentLevel;

        public int GetCurrentLevel()
        {
            var currentLevel = PlayerPrefs.HasKey(CurrentLevel)
                ? PlayerPrefs.GetInt(CurrentLevel)
                : 1;

            _currentLevel = currentLevel;
            
            return currentLevel;
        }

        public void LevelUp()
        {
            _currentLevel++;
            
            PlayerPrefs.SetInt(CurrentLevel, _currentLevel);
        }
    }
}