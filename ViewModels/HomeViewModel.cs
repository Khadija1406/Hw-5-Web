using Hw_5_Web.Models;

namespace Hw_5_Web.ViewModels
{
    public class HomeViewModel
    {
        public List<BookCardViewModel> Books { get; set; } = new List<BookCardViewModel>();
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
