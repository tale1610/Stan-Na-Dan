using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;

namespace StanNaDan;
static class DataLayer
{
    private static ISessionFactory? factory;
    private static object lockObj;

    static DataLayer()
    {
        factory = null;
        lockObj = new();
    }

    public static ISession? GetSession()
    {
        if (factory == null)
        {
            lock (lockObj)
            {
                if (factory == null)
                {
                    factory = CreateSessionFactory();
                }
            }
        }
        return factory?.OpenSession();
    }

    private static ISessionFactory? CreateSessionFactory()
    {
        try
        {
            var cfg = OracleManagedDataClientConfiguration.Oracle10.ShowSql().ConnectionString(c => c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB; User Id=S18958;Password=bazelab"));
            //ovo smo mogli da uradimo i u JSON file kao na web sto je mozda i bolje i mozda da zamenimo kasnije

            return Fluently.Configure().Database(cfg).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Poslovnica>()).BuildSessionFactory();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.FormatExceptionMessage());
            return null;
        }
    }
}
