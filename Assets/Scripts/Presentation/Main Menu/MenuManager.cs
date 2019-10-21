using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Presentation.UI.Constants;
using System.Linq;

namespace Presentation.UI.MainMenu
{
    public enum Menu
    {
        MainMenu,
        HighScore
    }

    public class MenuManager : MonoBehaviour
    {
        private IList<GameObject> _menus;

        void Start()
        {
            _menus = GameObject.FindGameObjectsWithTag(Tags.Menu);
            foreach (var menu in _menus)
            {
                menu.SetActive(false);
            }
            _menus.First(menu => menu.name == MenuNames.MainMenu).SetActive(true);
        }

        public void SwitchMenu(Menu selectedMenu)
        {
            foreach (var menu in _menus)
            {
                menu.SetActive(false);
            }

            switch (selectedMenu)
            {
                case Menu.MainMenu:
                    _menus.First(menu => menu.name == MenuNames.MainMenu).SetActive(true);
                    return;
                case Menu.HighScore:
                    _menus.First(menu => menu.name == MenuNames.HighScore).SetActive(true);
                    return;
            }
        }
    }
}