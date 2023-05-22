using HarmonyLib;
using NeosModLoader;
using FrooxEngine;
using FrooxEngine.UIX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using BaseX;

namespace ReallyBan
{
    public class ReallyBan : NeosMod
    {
        public override string Name => "ReallyBan";
        public override string Author => "TheJebForge";
        public override string Version => "1.0.0";

        public override void OnEngineInit() {
            Harmony harmony = new Harmony($"net.{Author}.{Name}");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(FriendsDialog), "OnBanFromAll")]
        class FriendsDialog_OnBanFromAll
        {
            public static bool Prefix(FriendsDialog __instance, ref IButton button, ButtonEventData eventData)
            {
                return button.Confirm("", confirmColor: color.Red);
            }
        }
        
        [HarmonyPatch(typeof(FriendsDialog), "OnBanFromCurrent")]
        class FriendsDialog_OnBanFromCurrent
        {
            public static bool Prefix(FriendsDialog __instance, ref IButton button, ButtonEventData eventData)
            {
                return button.Confirm("", confirmColor: color.Red);
            }
        }
    }
}