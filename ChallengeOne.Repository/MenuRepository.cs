using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repository
{
    public class MenuRepository
    {
        List<Menu> _menuDirectory = new List<Menu>();

        public bool AddMenuItem(Menu menuItem)
        {
            int listSizeBeforeAdd = _menuDirectory.Count;
            _menuDirectory.Add(menuItem);
            bool menuItemWasAdded = (listSizeBeforeAdd < _menuDirectory.Count) ? true : false;
            return menuItemWasAdded;
        }

        public List<Menu> GetAllMenuItems()
        {
            return _menuDirectory;
        }

        public bool UpdateMenuItem(int existingMenuItemNumber, Menu updatedMenuItem)
        {
            Menu existingMenuItem = GetMenuItemByNumber(existingMenuItemNumber);
            if (existingMenuItem != null)
            {
                existingMenuItem.Number = updatedMenuItem.Number;
                existingMenuItem.Name = updatedMenuItem.Name;
                existingMenuItem.Description = updatedMenuItem.Description;
                existingMenuItem.Ingredients = updatedMenuItem.Ingredients;
                existingMenuItem.Price = updatedMenuItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveMenuItem(Menu menuItem)
        {
            bool menuItemWasDeleted = _menuDirectory.Remove(menuItem);
            return menuItemWasDeleted;
        }

        public Menu GetMenuItemByNumber(int menuItemNumber)
        {
            foreach (Menu menuItem in _menuDirectory)
            {
                if (menuItem.Number == menuItemNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}
