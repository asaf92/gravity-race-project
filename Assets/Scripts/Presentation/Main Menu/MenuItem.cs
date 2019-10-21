using Presentation.UI.Constants;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.MainMenu
{
    public abstract class MenuItemBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        protected abstract string MenuText { get; }

        protected MenuManager _manager;

        private Text _text;

        void Start()
        {
            _text = GetComponent<Text>();
            _manager = GameObject.FindGameObjectWithTag(Tags.MenuManager).GetComponent<MenuManager>();
            var text = _manager == null ? "null" : "Not null";
            Debug.Log($"manager is {text}");
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