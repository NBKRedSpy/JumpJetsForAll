using BattleTech;
using BattleTech.UI;
using Harmony;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BattleTech.Data.DataManager;

namespace JumpJetsForAll.Patches
{
    /// <summary>
    /// The after action XP adjustment.
    /// This is a full replacement for the BEX CE's XP Cap to fix a float bug.
    /// </summary>
    [HarmonyPatch]
    public static class JumpJetAdd
    {

        public static PropertyInfo MaxJumpjetPropertyInfo { get; set; }

        public static IEnumerable<MethodBase> TargetMethods()
        {
            try
            {
                //MethodInfo storeDataMethodInfo = AccessTools.Method("BattleTech.Data.DataManager.ChassisDefLoadRequest:StoreData");

                Type chassisDefLoadRequestClass = typeof(BattleTech.Data.DataManager).GetNestedTypes(AccessTools.all)
                    .FirstOrDefault(x => x.Name == "ChassisDefLoadRequest");

                if(chassisDefLoadRequestClass == null) throw new NullReferenceException("chassisDefLoadRequestClass is null");

                MethodInfo storeDataMethodInfo = chassisDefLoadRequestClass.GetMethod("StoreData", AccessTools.all);

                if (storeDataMethodInfo == null) throw new NullReferenceException("storeDataMethodInfo is null");

                return new MethodBase[] { storeDataMethodInfo };
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw;
            }
        }

        public static void Prefix(ChassisDef ___resource)
        {
            try
            {
                if(MaxJumpjetPropertyInfo == null)
                {
                    MaxJumpjetPropertyInfo = typeof(ChassisDef).GetProperty("MaxJumpjets");
                    if (MaxJumpjetPropertyInfo == null) throw new NullReferenceException("MaxJumpjets not found");
                }

                if (___resource.MaxJumpjets == 0)
                {
                    MaxJumpjetPropertyInfo.SetValue(___resource, Core.ModSettings.JumpJetCount);
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                throw ex;
            }        
        }
    }
}
