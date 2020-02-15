using System;
using System.ComponentModel.DataAnnotations;

namespace OSRSBarrowsChestSimulator
{
    public class PlayerSettings
    {

        public bool KilledDharok { get; set; } = true;

        public bool KilledVerac { get; set; } = true;

        public bool KilledAhrim { get; set; } = true;

        public bool KilledGuthan { get; set; } = true;

        public bool KilledKaril { get; set; } = true;

        public bool KilledTorag { get; set; } = true;

        public bool CompletedMorytaniaHardDiary { get; set; } = true;

        [Required, Range(0, 1000, ErrorMessage = "Total level should be between 0 to 1000.")]
        public int SumTotalLevelOfCryptMonstersKilled { get; set; } = 1000;
    }
}
