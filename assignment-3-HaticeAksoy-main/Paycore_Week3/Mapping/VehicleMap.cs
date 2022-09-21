using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore_Week3;

namespace Paycore_Week
{
    public class VehicleMap : ClassMapping<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.Id, x =>
             {
                 x.Type(NHibernateUtil.Int64);
                 x.Column("id");
                 x.UnsavedValue(0);
             });

            Property(b => b.VehicleName, x =>
            {
                x.Type(NHibernateUtil.String);
            });

            Property(b => b.VehiclePlate, x =>
            {
                x.Type(NHibernateUtil.String);
            });

            Table("vehicle");
        }
    }
}
