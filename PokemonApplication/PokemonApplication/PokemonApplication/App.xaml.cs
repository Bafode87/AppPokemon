using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;
using PokemonApplication.Repository;

namespace PokemonApplication
{
    public partial class App : Application
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3" );
        
        public static PokemonRepository PokemonRepository { get; private set; }

        public App()
        {
            InitializeComponent();

            PokemonRepository = new PokemonRepository(dbPath);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}