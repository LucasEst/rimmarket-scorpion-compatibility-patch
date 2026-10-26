RimMarket - Scorpion Compatibility Patch
=======================================

HOW TO INSTALL (GITHUB DOWNLOAD)
1. Open https://github.com/LucasEst/rimmarket-scorpion-compatibility-patch
   and click Code -> Download ZIP.
2. Extract the downloaded ZIP into your RimWorld/Mods folder.
3. Make sure the folder structure is:
   RimWorld/Mods/rimmarket-scorpion-compatibility-patch-main/About/About.xml
   If there is another folder between the mod folder and About, move the
   inner mod folder directly into Mods.
4. Before enabling the patch, remove any Scorpions already stored in market
   stalls and cancel their sale orders. Existing stock is not moved by the patch.
5. Open RimWorld's Mods menu and enable the patch AFTER these required mods:
   - Harmony
   - RimMarket
   - Vanilla Factions Expanded - Classical
6. Restart RimWorld, load your save and check that Scorpions can no longer
   be stocked in colony stalls. Retry the art bench interaction that failed.

No compilation is needed: the download includes DLLs for RimWorld 1.6 and 1.7.
The patch prevents Scorpions from being stocked in colony stalls. You can still
use them as weapons and turrets. Gameplay testing in the affected save is pending.

SCOPE AND REMOVAL
This workaround blocks only VFEC_Weapon_Scorpion and VFEC_Turret_Scorpion
from colony-stall sale selection, acceptance and storage-capacity checks.
It also detects a minified object containing the turret.
It does not automatically eject existing stock or change the active mod list.
To remove the patch, disable it and restart RimWorld. It adds no new save objects.

VALIDATION
Compiled for RimWorld 1.6 (net48) and 1.7 (net10.0), zero compiler warnings.
All four Harmony patches applied against the inspected RimMarket 1.7 DLL;
both Scorpion definitions returned blocked results; unrelated Steel passed
through the guard unchanged. Not tested inside a running colony/save.
RimMarket 1.6: compiled and target signatures checked, no gameplay test.

BUILD
dotnet build Source/ScorpionStallBlock.csproj -c Release -p:GameVersion=1.6
dotnet build Source/ScorpionStallBlock.csproj -c Release -p:GameVersion=1.7
Override GameDir and HarmonyRoot with -p: if installed elsewhere.
Game DLLs, Harmony and original mod DLLs are not redistributed.

See DIAGNOSTIC.txt for the source references and limitations.
See PUBLISHING.txt for Workshop publishing instructions.
