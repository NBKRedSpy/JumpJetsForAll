using Harmony;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JumpJetsForAll
{
    public static class HarmonyInit
    {
        public static void Init(string directory, string settingsJSON)
        {
            Core.ModSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<ModSettings>(settingsJSON);

            var harmony = HarmonyInstance.Create("io.github.nbk_redspy.JumpJetsForAll");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
