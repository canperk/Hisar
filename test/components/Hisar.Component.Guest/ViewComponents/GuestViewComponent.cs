using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hisar.Component.Guest.ViewComponents
{
    public class GuestViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View();
        }
    }
}
