using System;
using System.Collections.Generic;
using System.Text;
using WebLab2.DAL.Data;
using WebLab2.DAL.Entities;

namespace WebLab2.Tests
{
    public class TestData
    {
        public static List<Transport> GetTransportsList()
        {
            return new List<Transport>
            {
             new Transport{ TransportId=1, TransportGroupId=1},
             new Transport{ TransportId=2, TransportGroupId=1},
             new Transport{ TransportId=3, TransportGroupId=2},
             new Transport{ TransportId=4, TransportGroupId=2},
             new Transport{ TransportId=5, TransportGroupId=3},
             new Transport{ TransportId=6, TransportGroupId=3},
            };
        }

        public static void FillContext(ApplicationDbContext context)
        {
            context.TransportGroups.Add(new TransportGroup
            { GroupName = "fake group" });
            context.AddRange(new List<Transport>
            {
             new Transport{ TransportId=1, TransportGroupId=1},
             new Transport{ TransportId=2, TransportGroupId=1},
             new Transport{ TransportId=3, TransportGroupId=2},
             new Transport{ TransportId=4, TransportGroupId=2},
             new Transport{ TransportId=5, TransportGroupId=3},
             new Transport{ TransportId=6, TransportGroupId=3},
            });
            context.SaveChanges();
        }

        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 3, 4 };
        }
    }
}
