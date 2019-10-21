using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.UI.MainMenu
{
    public class QuitMenuItem : MenuItemBase
    {
        protected override string MenuText => "Quit";

        public override void OnPointerClick(PointerEventData eventData)
        {
            Application.Quit();
        }
    }
}