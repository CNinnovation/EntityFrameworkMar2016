using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrox.ProCSharp.Entities;

namespace RelationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate();
        }

        private static void Generate()
        {
            using (var context = new MenuContext())
            {
                MenuCard card = context.MenuCards.Create();
                card.Text = "Mittagsmenüs";
                Menu m1 = new Menu() { Day = DateTime.Today, Text = "Wiener Schnitzel mit Kartoffelsalat", Price = 8.9m, MenuCard = card };
                card.Menus.Add(m1);
                context.Menus.Add(m1);
                context.MenuCards.Add(card);
                int changed = context.SaveChanges();
            }
        }
    }
}
