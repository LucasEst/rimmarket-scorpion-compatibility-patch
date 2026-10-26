using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ScorpionStallBlock
{
    public sealed class ScorpionStallBlockMod : Mod
    {
        public ScorpionStallBlockMod(ModContentPack content) : base(content)
        {
            LongEventHandler.ExecuteWhenFinished(Install);
        }

        private static void Install()
        {
            var harmony = new Harmony("local.rimmarket.scorpionstallblock");
            try
            {
                // Resolve every required target before changing anything.
                var targets = new[]
                {
                    Require("RimMarket.Market.ColonyStalls", "CanSell", typeof(ThingDef)),
                    Require("RimMarket.Buildings.Building_MarketStall", "Accepts", typeof(Thing)),
                    Require("RimMarket.Buildings.Building_MarketStall", "RoomFor", typeof(ThingDef)),
                    Require("RimMarket.Buildings.StallStock", "GetCountCanAccept", typeof(Thing), typeof(bool))
                };
                string[] prefixes = { "CanSell", "Accepts", "RoomFor", "CountCanAccept" };
                for (int i = 0; i < targets.Length; i++)
                    harmony.Patch(targets[i], prefix: new HarmonyMethod(typeof(Guards), prefixes[i]));
                Log.Message("[Scorpion Stall Block] Active: Scorpions cannot be stocked in RimMarket colony stalls.");
            }
            catch (Exception error)
            {
                harmony.UnpatchAll(harmony.Id);
                Log.Error("[Scorpion Stall Block] Could not apply patch; check RimMarket version. " + error);
            }
        }

        private static MethodInfo Require(string type, string method, params Type[] parameters)
        {
            Type owner = AccessTools.TypeByName(type);
            MethodInfo target = owner == null ? null : AccessTools.DeclaredMethod(owner, method, parameters);
            return target ?? throw new MissingMethodException(type, method);
        }
    }

    public static class Guards
    {
        public static bool IsScorpion(ThingDef def) =>
            def != null && (def.defName == "VFEC_Weapon_Scorpion" || def.defName == "VFEC_Turret_Scorpion");

        public static bool IsScorpion(Thing thing) =>
            thing != null && (IsScorpion(thing.def) ||
                (thing is MinifiedThing minified && IsScorpion(minified.InnerThing?.def)));

        public static bool CanSell(ThingDef __0, ref bool __result)
        {
            if (!IsScorpion(__0)) return true;
            __result = false;
            return false;
        }

        public static bool Accepts(Thing __0, ref bool __result)
        {
            if (!IsScorpion(__0)) return true;
            __result = false;
            return false;
        }

        public static bool RoomFor(ThingDef __0, ref int __result)
        {
            if (!IsScorpion(__0)) return true;
            __result = 0;
            return false;
        }

        public static bool CountCanAccept(Thing __0, ref int __result)
        {
            if (!IsScorpion(__0)) return true;
            __result = 0;
            return false;
        }
    }
}
