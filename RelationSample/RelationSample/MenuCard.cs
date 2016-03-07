using System.Collections.Generic;

namespace Wrox.ProCSharp.Entities
{
    public class MenuCard
    {
        public MenuCard()
        {
            Menus = new HashSet<Menu>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
