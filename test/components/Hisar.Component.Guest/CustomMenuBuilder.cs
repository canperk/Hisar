using Microsoft.AspNetCore.Mvc;
using NetCoreStack.Hisar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hisar.Component.Guest
{
    public class CustomMenuBuilder : DefaultMenuItemsBuilder<Startup>
    {
        public override IEnumerable<IMenuItem> Build(IUrlHelper urlHelper)
        {
            var items = new List<IMenuItem>
            {
                new DefaultMenuItem
                {
                    Icon = FontAwesomeIcon.List,
                    Order = 1,
                    Path = ResolvePath(urlHelper, "~/"),
                    ShowInMenu = true,
                    Text = "Ziyaretçi Listesi"
                },
                new DefaultMenuItem
                {
                    Icon = FontAwesomeIcon.Plus,
                    Order = 2,
                    Path = ResolvePath(urlHelper, "~/Home/New"),
                    ShowInMenu = true,
                    Text = "Yeni Ziyaretçi"
                }
            };

            return items;
        }
    }
}
