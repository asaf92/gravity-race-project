using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.UI.MainMenu
{
    public class ReturnToMainMenuItem : MenuItemBase
    {
        protected override string MenuText => "Return";

        public override void OnPointerClick(PointerEventData eventData)
        {
            _manager.SwitchMenu(Menu.MainMenu);
        }
    }
}