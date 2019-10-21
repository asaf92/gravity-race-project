using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Presentation.UI.MainMenu
{
    public class NewGameMenuItem : MenuItemBase
    {
        protected override string MenuText => "New Game";

        public override void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene("RacePOC");
        }
    }
}