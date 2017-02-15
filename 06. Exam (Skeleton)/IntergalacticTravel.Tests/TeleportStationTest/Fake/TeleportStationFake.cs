
using System.Collections.Generic;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.TeleportStationTest.Fake
{
    internal class TeleportStationFake : TeleportStation,ITeleportStation
    {
        public TeleportStationFake(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
            : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get
            {
                return this.owner;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return this.galacticMap;
            }
        }

        public ILocation Location
        {
            get
            {
                return this.location;
            }
        }

        public IResources Resources
        {
            get
            {
                return this.resources;
            }
        }
    }
}