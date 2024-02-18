using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EntityFrameworkBasic
{
    public class HomeController : Controller
    {
        #region Protected Properties
        /// <summary>
        /// Scoped application context
        /// </summary>
        protected ApplicationDbContext mContext;

        #endregion

        #region Constructor
        /// <summary>
        /// default ctor
        /// </summary>
        /// <param name="context">the inject context</param>
        public HomeController( ApplicationDbContext context)
        {
            mContext = context;
        }
        #endregion



        public IActionResult Index()
        {
            //Note - what the using does 
            //var a = new ApplicationDbContext();
            //...
            //a.Dispose();

           // var context = IoC.ApplicationDbContext;
            
                //Making sure we have a database
                mContext.Database.EnsureCreated();

                if (!mContext.Settings.Any())
                {
                    mContext.Settings.Add(new SettingsDataModel
                    {
                        Name = "BackgroundColor",
                        Value = "Red"
                    });

                    var SettingsLocally = mContext.Settings.Local.Count();
                    var SettingsDatabase = mContext.Settings.Count();

                    var firstSettingslocal = mContext.Settings.Local.FirstOrDefault();
                    var firstSettingsDatabase = mContext.Settings.FirstOrDefault();

                    mContext.SaveChanges();

                    SettingsLocally = mContext.Settings.Local.Count();
                    SettingsDatabase = mContext.Settings.Count();

                    firstSettingslocal = mContext.Settings.Local.FirstOrDefault();
                    firstSettingsDatabase = mContext.Settings.FirstOrDefault();
                }
                  
            return View();
        }

      


    }
}
