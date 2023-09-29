using UnityEngine;

namespace Core.Gameplay
{
    public class LevelHandler
    {
        private const string CurrentLevel = "CurrentLevel";
        private const string CurrentWave = "CurrentWave";
        private int _currentLevel;
        private int _currentWave;

        public int GetCurrentLevel()
        {
            var currentLevel = PlayerPrefs.HasKey(CurrentLevel)
                ? PlayerPrefs.GetInt(CurrentLevel)
                : 1;

            PlayerPrefs.SetInt(CurrentLevel, currentLevel);

            _currentLevel = currentLevel;
            
            return currentLevel;
        }

        public int GetCurrentWave()
        {
            var currentWave = PlayerPrefs.HasKey(CurrentWave)
                ? PlayerPrefs.GetInt(CurrentWave)
                : 1;

            PlayerPrefs.SetInt(CurrentWave, currentWave);
            
            _currentWave = currentWave;
            
            return currentWave;
        }

        public void WaveUp()
        {
            _currentWave++;
            
            PlayerPrefs.SetInt(CurrentWave, _currentWave);
        }

        public void LevelUp()
        {
            _currentLevel++;
            
            PlayerPrefs.SetInt(CurrentLevel, _currentLevel);
        }

        public void SetLevel(int level)
        {
            PlayerPrefs.SetInt(CurrentLevel, level);
        }
    }
}