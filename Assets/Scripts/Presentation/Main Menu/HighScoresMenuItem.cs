using UnityEngine.EventSystems;

namespace Presentation.UI.MainMenu
{
    public class HighScoresMenuItem : MenuItemBase
    {
        protected override string MenuText => "High Scores";

        public override void OnPointerClick(PointerEventData eventData)
        {
            _manager.SwitchMenu(Menu.HighScore);
        }
    }
}