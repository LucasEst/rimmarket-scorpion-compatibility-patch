RimMarket - Scorpion Stall Block
===============================

FRANCAIS
Petit contournement pour RimMarket + Vanilla Factions Expanded - Classical.
Bloque uniquement VFEC_Weapon_Scorpion et VFEC_Turret_Scorpion dans les
etals de colonie : selection de vente, acceptation et capacite de stockage.
Les armes et tourelles restent utilisables ailleurs.

INSTALLATION
1. Avant d'activer : sortir tous les Scorpions des etals et annuler leurs
   commandes de vente. Ce patch ne deplace pas les objets deja stockes.
2. Extraire Scorpion_MarketStall_Block dans RimWorld/Mods.
3. Activer le mod APRES Harmony, RimMarket et VFE Classical. Redemarrer le jeu.
4. Verifier que le Scorpion n'est plus propose a la vente, puis retester
   le clic droit sur l'etabli de sculpture.

Ne modifie pas automatiquement votre liste de mods. Pour retirer le patch,
le desactiver et redemarrer. Aucun nouveau type d'objet n'est ajoute aux saves.

ENGLISH
Workaround for RimMarket + VFE Classical. Blocks the Scorpion weapon and
turret from colony-stall sale selection, acceptance and storage capacity.
Remove all existing Scorpions from stalls and cancel their sale orders FIRST.
Extract this folder into RimWorld/Mods, enable after Harmony, RimMarket and
VFE Classical, then restart. The weapon remains usable outside market stalls.
This does not automatically eject existing stock or change the active mod list.

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
