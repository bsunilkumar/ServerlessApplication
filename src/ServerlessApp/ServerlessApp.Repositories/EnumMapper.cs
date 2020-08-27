using System.Data;
namespace ServerlessApp.Repositories
{
    public class EnumMapper<T> : NHibernate.Type.EnumStringType<T>
    {
        public override NHibernate.SqlTypes.SqlType SqlType
        {
            get
            {
                return new NHibernate.SqlTypes.SqlType(DbType.Object);
            }
        }
    }
}