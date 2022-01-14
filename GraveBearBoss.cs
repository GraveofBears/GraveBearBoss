using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using ItemManager;
using PieceManager;
using CreatureManager;
using UnityEngine;


namespace GraveBearBoss
{
    [BepInPlugin(HGUIDLower, ModName, version)]
    public partial class MOCKPMPlugin : BaseUnityPlugin
    {
        public const string version = "0.0.1";
        public const string ModName = "GraveBearBoss";
        internal const string Author = "Gravebear";
        internal const string HGUID = Author + "." + "GraveBearBoss";
        internal const string HGUIDLower = "gravebear.GraveBearBoss";
        private const string HarmonyGUID = "Harmony." + Author + "." + ModName;
        private static string ConfigFileName = HGUIDLower + ".cfg";
        private static string ConfigFileFullPath = Paths.ConfigPath + Path.DirectorySeparatorChar + ConfigFileName;
        public static string ConnectionError = "";

        private static Harmony harmony;
        public void Awake()
        {
            Item GraveBearTotem = new("gravebearboss", "GraveBearTotem");
            GraveBearTotem.Crafting.Add(CraftingTable.Workbench, 3);
            GraveBearTotem.RequiredItems.Add("ElderBark", 10);
            GraveBearTotem.RequiredItems.Add("TrophyGoblinKing", 1);
            GraveBearTotem.RequiredItems.Add("Wood", 4);
            GraveBearTotem.CraftAmount = 1;

            BuildPiece GraveBear_Alter = new("gravebearboss", "GraveBear_Alter");
            GraveBear_Alter.Name.English("GraveBear_Alter");
            GraveBear_Alter.Description.English("Alter");
            GraveBear_Alter.RequiredItems.Add("Iron", 20, false);
            GraveBear_Alter.RequiredItems.Add("SwordIronFire", 20, false);

            BuildPiece GraveBearRug = new("gravebearboss", "GraveBearRug");
            GraveBearRug.Name.English("GraveBearRug");
            GraveBearRug.Description.English("Rug");
            GraveBearRug.RequiredItems.Add("GraveBearPelt", 4, false);

            Creature GraveBear_Boss = new("gravebearboss", "GraveBear_Boss");
            GraveBear_Boss.Drops["GraveBearPelt"].Amount = new Range(4, 6);
            GraveBear_Boss.Drops["GraveBearPelt"].DropChance = 100f;
            GraveBear_Boss.Drops["TrophyGraveBear"].Amount = new Range(1, 1);
            GraveBear_Boss.Drops["TrophyGraveBear"].DropChance = 10f;

            harmony = new Harmony(HarmonyGUID);

            harmony.PatchAll();
        }
    }
}
