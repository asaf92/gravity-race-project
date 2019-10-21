using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.MainMenu
{
    public abstract class MenuItemBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        protected abstract string MenuText { get; }

        private Text _text;

        void Start()
        {
            _text = GetComponent<Text>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _text.fontStyle = FontStyle.Bold;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _text.fontStyle = FontStyle.Normal;
        }

        public abstract void OnPointerClick(PointerEventData eventData);
    }
}