using MovieShop.UI;

namespace MovieShop
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageFilmCast manageFilmCast = new ManageFilmCast();
            manageFilmCast.Run();

            async System.Threading.Tasks.Task testAsync() {
                await manageFilmCast.GetAllAsyncWithDapperSimpleQuery();
            }

            testAsync();

        }
    }
}
