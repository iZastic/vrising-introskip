using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using ProjectM.UI;

namespace IntroSkip
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class IntroSkipPlugin : BasePlugin
    {
        private static ManualLogSource Logger;
        private Harmony harmony;

        public override void Load()
        {
            Logger = Log;
            harmony = Harmony.CreateAndPatchAll(typeof(IntroSkipPlugin));

            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(StartGameLoadMenuView), nameof(StartGameLoadMenuView.Update))]
        private static void UpdatePrefix(StartGameLoadMenuView __instance)
        {
            if (__instance.VideoPlayer.isPlaying)
            {
                __instance.VideoPlayer.Stop();
            }
        }
    }
}