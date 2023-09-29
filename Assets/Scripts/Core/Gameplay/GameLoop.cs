using System;
using Core.UI.SignalScripts;
using UnityEngine;
using Utils;
using VContainer.Unity;

namespace Core.Gameplay
{
    public class GameLoop : IDisposable, IStartable
    {
        public void Start()
        {
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void OnPlayButtonPressed()
        {
        }

        private void Subscribe()
        {
            Signals.Get<PlayButtonPressedSignal>().AddListener(OnPlayButtonPressed);
        }

        private void Unsubscribe()
        {
            Signals.Get<PlayButtonPressedSignal>().RemoveListener(OnPlayButtonPressed);
        }
    }
}