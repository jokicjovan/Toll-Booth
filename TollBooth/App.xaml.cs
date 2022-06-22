using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TollBooth.Core.Persistence;

namespace TollBooth
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (DatabaseContext db = new DatabaseContext(0))
            {
                //DatabaseContextSeed.Seed(db);
            }
        }
    }
}
