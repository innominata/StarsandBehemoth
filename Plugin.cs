using System;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace StarsandBehemoth
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class StarsandBehemoth : BaseUnityPlugin
    {

        public new static ManualLogSource Logger;

        private void Awake()
        {
            Logger = new ManualLogSource("Behemoth");
            BepInEx.Logging.Logger.Sources.Add(Logger);
            Logger.LogInfo("Starsand Behemoth Mod Loading");
            Harmony.CreateAndPatchAll(typeof(StarsandBehemoth));
            
        }
        // [HarmonyPostfix, HarmonyPatch(typeof(ScoloManager), "Start")]
        // public static void Start(ref ScoloManager __instance)
        // {
        //     __instance.SpawnScolo(2);
        //     
        // }
        [HarmonyPostfix]
        [HarmonyPatch(typeof(EnemyAI), "Start")]
        public static void EnemyAI(ref EnemyAI __instance)
        {
            // Logger.LogInfo("%");
            var scoloTransform = __instance.scoloChild.transform;
            // Logger.LogInfo(__instance.gameObject.activeSelf);
            // Logger.LogInfo(__instance.gameObject.name);
            // Logger.LogInfo("-");
            //
            // Logger.LogInfo(scoloTransform.localScale);
            // Logger.LogInfo("-");
            if (new Random().Next(0, 20) > 17)
            {
                scoloTransform.localScale = new Vector3(3, 3, 3);
                __instance.aiSettings.AI.Health.Set(200f);
            }
        }



    }
}