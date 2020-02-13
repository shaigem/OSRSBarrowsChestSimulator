using System;
using System.Collections.Generic;
using System.Linq;
using static OSRSBarrowsChestSimulator.BarrowsBrother;

namespace OSRSBarrowsChestSimulator
{
    public class BarrowsBrotherService
    {

        private readonly StoreContext _store;

        public BarrowsBrotherService(StoreContext store)
        {
            _store = store;
        }

        public List<BarrowsBrother> GetBrothersKilled(PlayerSettings settings)
        {
            var killed = new List<BarrowsBrother>();


            if (settings.KilledAhrim)
            {
                killed.Add(FindBrotherByName(BarrowsBrotherName.AhrimTheBlighted));
            }

            if (settings.KilledGuthan)
            {
                killed.Add(FindBrotherByName(BarrowsBrotherName.GuthanTheInfested));

            }

            if (settings.KilledDharok)
            {
                killed.Add(FindBrotherByName(BarrowsBrotherName.DharokTheWretched));

            }

            if (settings.KilledKaril)
            {
                killed.Add(FindBrotherByName(BarrowsBrotherName.KarilTheTainted));

            }

            if (settings.KilledTorag)
            {
                killed.Add(FindBrotherByName(BarrowsBrotherName.ToragTheCorrupted));

            }

            if (settings.KilledVerac)
            {
                killed.Add(FindBrotherByName(BarrowsBrotherName.VeracTheDefiled));

            }

            return killed;
        }


        public BarrowsBrother FindBrotherByName(BarrowsBrotherName name)
        {
            return _store.BarrowsBrothers.SingleOrDefault(s => s.Name.Equals(name.Value, StringComparison.InvariantCultureIgnoreCase));
        }

        public List<BarrowsBrother> GetBrothers()
        {
            return _store.BarrowsBrothers;
        }





    }
}
