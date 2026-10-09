using HarmonyLib;
using System;
using UnityModManagerNet;

namespace UniversalCosmetics
{
    internal static class Main
    {
        public static bool Enabled;
        public static UnityModManager.ModEntry.ModLogger logger;
        static bool loaded = false;
        public static void DebugLog(string msg)
        {
            if (logger != null) logger.Log(msg);
        }
        public static void DebugError(Exception ex)
        {
            if (logger != null) logger.Log(ex.ToString() + "\n" + ex.StackTrace);
        }

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.OnToggle = OnToggle;
            var harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll();
            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Enabled = value;
            if (loaded)
            {
                if (!enabled) RestoreOptions();
                else Unlock();
            }
            return true;
        }
    }
}