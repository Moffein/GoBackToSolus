using BepInEx;
using RoR2;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Security;
using System.Linq;
using UnityEngine.AddressableAssets;
using BepInEx.Configuration;
using UnityEngine;
[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace R2API.Utils
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class ManualNetworkRegistrationAttribute : Attribute
    {
    }
}

namespace GoBackToSolus
{
    [BepInPlugin("com.Moffein.GoBackToSolus", "Go Back to Solus", "1.1.0")]
    public class GoBackToSolusPlugin : BaseUnityPlugin
    {
        public static List<CharacterSpawnCard> solusCards = new List<CharacterSpawnCard>
        {
            Addressables.LoadAssetAsync<CharacterSpawnCard>("RoR2/DLC3/WorkerUnit/cscWorkerUnit.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<CharacterSpawnCard>("RoR2/DLC3/Tanker/cscTanker.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<CharacterSpawnCard>("RoR2/DLC3/MinePod/cscMinePod.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<CharacterSpawnCard>("RoR2/DLC3/DefectiveUnit/cscDefectiveUnit.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<CharacterSpawnCard>("RoR2/DLC3/ExtractorUnit/cscExtractorUnit.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<CharacterSpawnCard>("RoR2/DLC3/IronHauler/cscIronHauler.asset").WaitForCompletion()
        };

        public static List<DirectorCardCategorySelection> allOtherDccs = new List<DirectorCardCategorySelection>
        {
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/Base/dampcave/dccsDampCaveMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/Base/foggyswamp/dccsFoggySwampMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/Base/frozenwall/dccsFrozenWallMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/Base/golemplains/dccsGolemplainsMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/Base/goolake/dccsGooLakeMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/Base/rootjungle/dccsRootJungleMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC1/itancientloft/dccsITAncientLoftMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC1/itdampcave/dccsITDampCaveMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC1/itgolemplains/dccsITGolemplainsMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC1/itgoolake/dccsITGooLakeMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC1/sulfurpools/dccsSulfurPoolsMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC2/lakes/dccsLakesMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC2/village/dccsVillageMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC4/sanctum/dccsSanctumMonstersDLC3.asset").WaitForCompletion(),
        };

        public static List<DirectorCardCategorySelection> scuMapDccs = new List<DirectorCardCategorySelection>
        {
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/Base/skymeadow/dccsSkyMeadowMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC1/itskymeadow/dccsITSkyMeadowMonstersDLC3.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DirectorCardCategorySelection>("RoR2/DLC2/helminthroost/dccsHelminthRoostMonstersDLC3.asset").WaitForCompletion(),
        };

        public static List<DccsPool> dccsPools = new List<DccsPool>
        {
            Addressables.LoadAssetAsync<DccsPool>("RoR2/Base/dampcave/dpDampCaveMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/Base/foggyswamp/dpFoggySwampMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/Base/frozenwall/dpFrozenWallMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/Base/golemplains/dpGolemplainsMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/Base/goolake/dpGooLakeMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/Base/rootjungle/dpRootJungleMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC1/itancientloft/dpITAncientLoftMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC1/itdampcave/dpITDampCaveMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC1/itgolemplains/dpITGolemplainsMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC1/itgoolake/dpITGooLakeMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC1/sulfurpools/dpSulfurPoolsMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC2/lakes/dpLakesMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC2/lakesnight/dpLakesnightMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC2/village/dpVillageMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC2/villagenight/dpVillageNightMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC4/sanctum/dpSanctumMonsters.asset").WaitForCompletion(),

            Addressables.LoadAssetAsync<DccsPool>("RoR2/Base/skymeadow/dpSkyMeadowMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC1/itskymeadow/dpITSkyMeadowMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC2/helminthroost/dpHelminthRoostMonsters.asset").WaitForCompletion()
        };

        public static List<DccsPool> scuDccsPools = new List<DccsPool>
        {
            Addressables.LoadAssetAsync<DccsPool>("RoR2/Base/skymeadow/dpSkyMeadowMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC1/itskymeadow/dpITSkyMeadowMonsters.asset").WaitForCompletion(),
            Addressables.LoadAssetAsync<DccsPool>("RoR2/DLC2/helminthroost/dpHelminthRoostMonsters.asset").WaitForCompletion()
        };

        private List<string> scenesToProcess = new List<string>();
        private bool allowOnScuMaps;

        private void Awake()
        {
            allowOnScuMaps = Config.Bind("Settings", "Allow on SCU Maps", false, new ConfigDescription("Allow DLC3 enemies to spawn on maps with the Solus Control Unit.")).Value;

            RoR2Application.onLoad += RemoveRobots;
            On.RoR2.DCCSBlender.GetBlendedDCCS += DCCSBlender_GetBlendedDCCS;

            string sceneString = Config.Bind("Settings", "Manual Scene Blacklist", "", new ConfigDescription("Additional scenes to blacklist DLC3 enemies on. Use scene_list in debugtoolkit to get the internal scene names.")).Value;
            string[] split = sceneString.Split(',');
            foreach (string str in split)
            {
                var trim = str.Trim();
                if (trim.Length > 0)
                {
                    scenesToProcess.Add(trim);
                }
            }
        }

        private void RemoveRobots()
        {
            foreach (var dp in dccsPools)
            {
                foreach (var poolCat in dp.poolCategories)
                {
                    poolCat.includedIfConditionsMet = poolCat.includedIfConditionsMet.Where(p =>
                    {
                        if (!p.dccs || allOtherDccs.Contains(p.dccs)) return false;

                        return allowOnScuMaps || !scuMapDccs.Contains(p.dccs);
                    }).ToArray();
                }
            }
        }

        private DirectorCardCategorySelection DCCSBlender_GetBlendedDCCS(On.RoR2.DCCSBlender.orig_GetBlendedDCCS orig, DccsPool.Category dccsPoolCategory, ref Xoroshiro128Plus rng, ClassicStageInfo stageInfo, int contentSourceMixLimit, System.Collections.Generic.List<RoR2.ExpansionManagement.ExpansionDef> acceptableExpansionList)
        {
            var ret = orig(dccsPoolCategory, ref rng, stageInfo, contentSourceMixLimit, acceptableExpansionList);

            SceneDef current = SceneCatalog.GetSceneDefForCurrentScene();
            if (current && scenesToProcess.Contains(current.baseSceneName))
            {
                if (ret != null && ret.categories != null)
                {
                    for (int i = 0; i < ret.categories.Length; i++)
                    {
                        if (ret.categories[i].cards != null)
                        {
                            ret.categories[i].cards = ret.categories[i].cards.Where(card => !(card != null && solusCards.Contains(card.spawnCard))).ToArray();
                        }
                    }
                }
            }

            return ret;
        }
    }
}
