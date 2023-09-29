using Core.UI.SignalScripts;
using Utils;

namespace Core.UI
{
    public class UIMenuScreen : UIComponent
    {
        public void PlayButtonPressed()
        {
            Signals.Get<PlayButtonPressedSignal>().Dispatch();
        }
    }
}