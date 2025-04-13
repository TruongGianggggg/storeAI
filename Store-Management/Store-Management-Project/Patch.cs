using HarmonyLib;
using Telerik.WinControls;

namespace Store_Management_Project
{
    internal class Patch
    {
        [HarmonyPatch(typeof(RadControl), nameof(RadControl.IsTrial), MethodType.Getter)]
        internal class PatchIsTrial
        {
            static bool Prefix(ref bool __result)
            {
                __result = false;
                return false; // Skip original method
            }
        }
    }
}
