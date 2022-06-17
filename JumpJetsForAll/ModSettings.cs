using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpJetsForAll
{
    public class ModSettings
    {
        /// <summary>
        /// The number of jump jets to set to every mech that has zero jump jets.
        /// </summary>
        public int JumpJetCount { get; set; } = 4;

        /// <summary>
        /// If true, also modify mechs that already have jump jets.
        /// </summary>
        public bool IncludeMechsWithJumpJets { get; set; } = false;


    }
}
