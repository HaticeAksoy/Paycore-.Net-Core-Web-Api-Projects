using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paycore_Week3
{
    public class ContainerMap: ClassMapping<Container>
    {
        public ContainerMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
            });

            Property(b => b.ContainerName, x =>
            {
                x.Type(NHibernateUtil.String);
                x.Length(50);
            });

            Property(b => b.Latitude, x =>
            {
                x.Type(NHibernateUtil.Double);

            });

            Property(b => b.Longitude, x =>
            {
                x.Type(NHibernateUtil.Double);
            });

            Property(b => b.VehicleId, x =>
            {
                x.Type(NHibernateUtil.Int64);
            });

            Table("container");

        }
    }
}
