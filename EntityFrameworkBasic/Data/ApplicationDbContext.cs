

using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkBasic
{
    /// <summary>
    /// Database representaional model for our application
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        #region Public Properties    
        /// <summary>
        /// the setting for the application - dbSet is sort of a table in the database
        /// </summary>
        public DbSet<SettingsDataModel> Settings { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// default ctor expecting database option pass in
        /// </summary>
        /// <param name="options">the database context option</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        #endregion
        
        #region Protected Method Override

        ///// <summary>
        ///// This allow us to initialize and configure our database server
        ///// </summary>
        ///// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("Server = Toshiba-nout\\SUNNYLESSON; Database = EntityFramework; Trusted_Connection = true; MultipleActiveResultSets = true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API
            modelBuilder.Entity<SettingsDataModel>().HasIndex(a => a.Name).IsUnique();
        } 
        #endregion
    }
}
