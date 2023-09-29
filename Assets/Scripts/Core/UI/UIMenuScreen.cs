using Core.Gameplay;
using Core.UI.SignalScripts;
using Utils;
using VContainer;

namespace Core.UI
{
    public class UIMenuScreen : UIComponent
    {
        private LevelHandler _levelHandler;

        [Inject]
        public void Constructor(LevelHandler levelHandler)
        {
            _levelHandler = levelHandler;
        }
        
        public void PlayButtonPressed(int level)
        {
            _levelHandler.SetLevel(level);
            Signals.Get<PlayButtonPressedSignal>().Dispatch();
        }
    }
}