using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;
using PokemonApplication.Repository;

namespace PokemonApplication
{
    public partial class App : Application
    {
        // Création de la base de données
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database" );
        
        public static Repository.Repository Repository { get; private set; }
   

        public App()
        {
            InitializeComponent();

            Repository = new Repository.Repository(dbPath);
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