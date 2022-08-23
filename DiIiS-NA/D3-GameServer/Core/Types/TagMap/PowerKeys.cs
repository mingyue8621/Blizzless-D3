﻿//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using System.Reflection;

namespace DiIiS_NA.GameServer.Core.Types.TagMap
{
	public class PowerKeys
	{
		#region compile a dictionary to access keys from ids. If you need a readable name for a TagID, look up its key and get its name
		private static Dictionary<int, TagKey> tags = new Dictionary<int, TagKey>();

		public static TagKey GetKey(int index)
		{
			return tags.ContainsKey(index) ? tags[index] : null;
		}

		static PowerKeys()
		{
			foreach (FieldInfo field in typeof(PowerKeys).GetFields())
			{
				TagKey key = field.GetValue(null) as TagKey;
				key.Name = field.Name;
				tags.Add(key.ID, key);
			}
		}
		#endregion

		public static TagKeyInt TurnsIntoBasicMeleeAttack = new TagKeyInt(328386);
		public static TagKeyInt ReuseScriptState = new TagKeyInt(274432);
		public static TagKeyInt CastTargetEnemies = new TagKeyInt(328113);
		public static TagKeyInt CustomTargetUnaffectedOnly = new TagKeyInt(328800);
		public static TagKeyInt IsUsableInTown = new TagKeyInt(328080);
		public static TagKeyInt TurnsIntoBasicRangedAttack = new TagKeyInt(328385);
		public static TagKeyInt IsPrimary = new TagKeyInt(327776);
		public static TagKeyScript IsInvulnerableDuring = new TagKeyScript(328609);
		public static TagKeyInt OffhandAnimationTag_fordualwield = new TagKeyInt(262663);
		public static TagKeyInt IsPassive = new TagKeyInt(328592);
		public static TagKeyInt AnimationTag2 = new TagKeyInt(262658);
		public static TagKeyInt AnimationTag = new TagKeyInt(262656);
		public static TagKeyScript IsUntargetableDuring = new TagKeyScript(633616);
		public static TagKeyScript IsUninterruptableDuring = new TagKeyScript(328610);
		public static TagKeyScript BaseDamageScalar = new TagKeyScript(329840);
		public static TagKeyInt AlwaysHits = new TagKeyInt(327904);
		public static TagKeySNO CastingEffectGroup_Female = new TagKeySNO(264273);
		public static TagKeySNO CastingEffectGroup_Male = new TagKeySNO(262660);
		public static TagKeyInt Buff0ShowDuration = new TagKeyInt(271104);
		public static TagKeyScript CooldownTime = new TagKeyScript(327768);
		public static TagKeySNO Buff1EffectGroup = new TagKeySNO(270337);
		public static TagKeySNO Buff0EffectGroup = new TagKeySNO(270336);
		public static TagKeyInt CastTargetAllies = new TagKeyInt(328097);
		public static TagKeyInt RequiresTarget = new TagKeyInt(328432);
		public static TagKeyInt Buff3IsHarmful = new TagKeyInt(270851);
		public static TagKeyScript ResourceCost = new TagKeyScript(329616);
		public static TagKeyInt IconMouseover = new TagKeyInt(329488);
		public static TagKeyInt IconNormal = new TagKeyInt(329472);
		public static TagKeyInt IconPushed = new TagKeyInt(329504);
		public static TagKeyInt Buff3Icon = new TagKeyInt(270595);
		public static TagKeyInt Buff2ShowDuration = new TagKeyInt(271106);
		public static TagKeyInt IsMouseAssignable = new TagKeyInt(328048);
		public static TagKeyInt IsHotbarAssignable = new TagKeyInt(328064);
		public static TagKeyInt IsOffensive = new TagKeyInt(327840);
		public static TagKeyInt IsDisplayed = new TagKeyInt(327824);
		public static TagKeyInt Template = new TagKeyInt(327680);
		public static TagKeyInt CannotLMBAssign = new TagKeyInt(327920);
		public static TagKeyInt Buff2Icon = new TagKeyInt(270594);
		public static TagKeyInt Buff1Icon = new TagKeyInt(270593);
		public static TagKeyScript ScriptFormula10 = new TagKeyScript(266752);
		public static TagKeyScript ScriptFormula11 = new TagKeyScript(266768);
		public static TagKeyScript ScriptFormula12 = new TagKeyScript(266784);
		public static TagKeyScript ScriptFormula13 = new TagKeyScript(266800);
		public static TagKeyScript ScriptFormula14 = new TagKeyScript(266816);
		public static TagKeyInt Buff0PlayerCanCancel = new TagKeyInt(271360);
		public static TagKeyInt IconInactive = new TagKeyInt(329512);
		public static TagKeyInt Buff0Icon = new TagKeyInt(270592);
		public static TagKeyScript ScriptFormula0 = new TagKeyScript(266496);
		public static TagKeyScript ScriptFormula2 = new TagKeyScript(266528);
		public static TagKeyScript ScriptFormula3 = new TagKeyScript(266544);
		public static TagKeyScript ScriptFormula4 = new TagKeyScript(266560);
		public static TagKeyScript ScriptFormula5 = new TagKeyScript(266576);
		public static TagKeyScript ScriptFormula7 = new TagKeyScript(266608);
		public static TagKeyInt Buff3ShowDuration = new TagKeyInt(271107);
		public static TagKeyInt Buff2PlayerCanCancel = new TagKeyInt(271362);
		public static TagKeyScript FailsIfStunned = new TagKeyScript(328322);
		public static TagKeyScript BreaksFear = new TagKeyScript(681987);
		public static TagKeyScript BreaksStun = new TagKeyScript(681986);
		public static TagKeyScript BreaksSnare = new TagKeyScript(681985);
		public static TagKeyScript BreaksRoot = new TagKeyScript(681984);
		public static TagKeyScript FailsIfFeared = new TagKeyScript(328325);
		public static TagKeySNO ContactFrameEffectGroup_Male = new TagKeySNO(264192);
		public static TagKeySNO ContactFrameEffectGroup_Female = new TagKeySNO(264275);
		public static TagKeyInt SpellFunc0 = new TagKeyInt(327712);
		public static TagKeyInt CastTargetMustBeInTeleportableArea = new TagKeyInt(328083);
		public static TagKeySNO GenericEffectGroup0 = new TagKeySNO(262661);
		public static TagKeyScript ConcentrationDuration = new TagKeyScript(333088);
		public static TagKeyScript SlowTimeDuration = new TagKeyScript(332928);
		public static TagKeyScript RingofFrostRingLifetime = new TagKeyScript(332896);
		public static TagKeyScript DodgeDuration = new TagKeyScript(332848);
		public static TagKeyScript DamageAuraDuration = new TagKeyScript(332832);
		public static TagKeyScript RootDuration = new TagKeyScript(332816);
		public static TagKeyScript CurseDuration = new TagKeyScript(332800);
		public static TagKeyScript PaladinDeadTimeUntilResurrect = new TagKeyScript(332784);
		public static TagKeyScript BuffDurationMin = new TagKeyScript(332736);
		public static TagKeyScript ThunderingCryBuffDuration = new TagKeyScript(332720);
		public static TagKeyScript ThunderstormDuration = new TagKeyScript(332704);
		public static TagKeyScript TornadoLifeDurationMin = new TagKeyScript(332656);
		public static TagKeySNO EndingEffectGroup = new TagKeySNO(262662);
		public static TagKeyScript AttackSpeed = new TagKeyScript(329824);
		public static TagKeyScript ScriptFormula23 = new TagKeyScript(267056);
		public static TagKeyScript ScriptFormula22 = new TagKeyScript(267040);
		public static TagKeyScript ScriptFormula20 = new TagKeyScript(267008);
		public static TagKeyScript ScriptFormula21 = new TagKeyScript(267024);
		public static TagKeyScript EscapeAttackRadius = new TagKeyScript(329744);
		public static TagKeyScript AttackRadius = new TagKeyScript(329808);
		public static TagKeyInt IgnoresRangeOnShiftClick = new TagKeyInt(328600);
		public static TagKeyInt AutoAssignLocation = new TagKeyInt(328049);
		public static TagKeyInt CanSteer = new TagKeyInt(327937);
		public static TagKeyInt TurnsIntoBasicAttack = new TagKeyInt(328384);
		public static TagKeyInt ItemTypeRequirement = new TagKeyInt(328960);
		public static TagKeyInt SpecialDeathType = new TagKeyInt(328534);
		public static TagKeyScript ResourceCostMinToCast = new TagKeyScript(329617);
		public static TagKeyInt ControllerAutoTargets = new TagKeyInt(622592);
		public static TagKeyScript ControllerMinRange = new TagKeyScript(622593);
		public static TagKeyInt TargetGroundOnly = new TagKeyInt(328160);
		public static TagKeyInt TurnsIntoWalk = new TagKeyInt(327936);
		public static TagKeyInt IsAimedAtGround = new TagKeyInt(327888);
		public static TagKeyScript ScriptFormula19 = new TagKeyScript(266896);
		public static TagKeyScript ScriptFormula18 = new TagKeyScript(266880);
		public static TagKeyScript ScriptFormula17 = new TagKeyScript(266864);
		public static TagKeyScript ScriptFormula16 = new TagKeyScript(266848);
		public static TagKeyScript ScriptFormula15 = new TagKeyScript(266832);
		public static TagKeyInt UsesAttackWarmupTime = new TagKeyInt(328606);
		public static TagKeyInt AlternatesAnims = new TagKeyInt(328501);
		public static TagKeyFloat SpecialDeathChance = new TagKeyFloat(328532);
		public static TagKeyScript ScriptFormula9 = new TagKeyScript(266640);
		public static TagKeyScript ScriptFormula8 = new TagKeyScript(266624);
		public static TagKeyScript ScriptFormula1 = new TagKeyScript(266512);
		public static TagKeyScript ScriptFormula6 = new TagKeyScript(266592);
		public static TagKeyInt ContactFrameType = new TagKeyInt(328224);
		public static TagKeyScript PayloadParam0 = new TagKeyScript(329776);
		public static TagKeyInt PayloadType = new TagKeyInt(329760);
		public static TagKeyInt TargetEnemies = new TagKeyInt(328112);
		public static TagKeyInt SpellFunc1 = new TagKeyInt(327728);
		public static TagKeyScript ProjectileSpeed = new TagKeyScript(331184);
		public static TagKeyScript ChargedBoltNumBolts = new TagKeyScript(331056);
		public static TagKeySNO ProjectileActor = new TagKeySNO(262400);
		public static TagKeyScript ProcCooldownTime = new TagKeyScript(680768);
		public static TagKeyScript LightningDamageDelta = new TagKeyScript(330128);
		public static TagKeyScript LightningDamageMin = new TagKeyScript(330112);
		public static TagKeyInt CastTargetIgnoreWreckables = new TagKeyInt(328169);
		public static TagKeyInt TargetIgnoreWreckables = new TagKeyInt(328168);
		public static TagKeyScript ColdDamageMin = new TagKeyScript(330176);
		public static TagKeyScript ColdDamageDelta = new TagKeyScript(330192);
		public static TagKeyInt Buff1ShowDuration = new TagKeyInt(271105);
		public static TagKeyInt AutoPurchaseLevel = new TagKeyInt(329520);
		public static TagKeyInt Buff1PlayerCanCancel = new TagKeyInt(271361);
		public static TagKeyScript ImmuneToKnockback = new TagKeyScript(328352);
		public static TagKeyScript ImmuneToRecoil = new TagKeyScript(328336);
		public static TagKeyInt NeverUpdatesFacing = new TagKeyInt(328000);
		public static TagKeyInt ContactFreezesFacing = new TagKeyInt(327984);
		public static TagKeyInt IsBasicAttack = new TagKeyInt(327808);
		public static TagKeyInt SpellFuncBegin = new TagKeyInt(327696);
		public static TagKeyInt SpellFuncInterrupted = new TagKeyInt(327745);
		public static TagKeyScript NumCryptKidsToSpawnOnCorpulentExplosion = new TagKeyScript(332480);
		public static TagKeyInt TargetAllies = new TagKeyInt(328096);
		public static TagKeyInt NeverCausesRecoil = new TagKeyInt(327968);
		public static TagKeyScript MonsterCritDamageScalar = new TagKeyScript(684918);
		public static TagKeyScript PlayerCritDamageScalar = new TagKeyScript(684917);
		public static TagKeyInt Buff0IsHarmful = new TagKeyInt(270848);
		public static TagKeyInt DoesntCenter = new TagKeyInt(328032);
		public static TagKeyInt IsTranslate = new TagKeyInt(327856);
		public static TagKeyInt SpellFuncEnd = new TagKeyInt(327744);
		public static TagKeyScript SpecialWalkTrajectoryHeight = new TagKeyScript(332320);
		public static TagKeyScript SpecialWalkTrajectoryGravity = new TagKeyScript(332336);
		public static TagKeyInt SpecialWalkPerturbDestination = new TagKeyInt(332360);
		public static TagKeyInt IsChannelled = new TagKeyInt(328400);
		public static TagKeyInt InfiniteAnimTiming = new TagKeyInt(328208);
		public static TagKeyInt CustomTargetFunc = new TagKeyInt(328736);
		public static TagKeyInt CustomTargetPlayersOnly = new TagKeyInt(328752);
		public static TagKeyScript CustomTargetMinRange = new TagKeyScript(328768);
		public static TagKeyInt SnapsToFacing = new TagKeyInt(328021);
		public static TagKeyScript ManaPercentToReserve = new TagKeyScript(331600);
		public static TagKeyInt ComboAnimation1 = new TagKeyInt(262912);
		public static TagKeyScript ScriptFormula26 = new TagKeyScript(267104);
		public static TagKeyScript ScriptFormula28 = new TagKeyScript(267136);
		public static TagKeyScript ScriptFormula29 = new TagKeyScript(267152);
		public static TagKeyScript EscapeAttackAngle = new TagKeyScript(329745);
		public static TagKeyScript ComboAttackRadius1 = new TagKeyScript(329809);
		public static TagKeyInt ComboAnimation2 = new TagKeyInt(262913);
		public static TagKeyScript ComboAttackSpeed1 = new TagKeyScript(329825);
		public static TagKeySNO Buff3EffectGroup = new TagKeySNO(270339);
		public static TagKeyScript ComboAttackRadius2 = new TagKeyScript(329810);
		public static TagKeyScript ComboAttackSpeed2 = new TagKeyScript(329826);
		public static TagKeySNO Buff2EffectGroup = new TagKeySNO(270338);
		public static TagKeyScript ComboAttackRadius3 = new TagKeyScript(329811);
		public static TagKeyScript ComboAttackSpeed3 = new TagKeyScript(329827);
		public static TagKeyInt IsComboPower = new TagKeyInt(264448);
		public static TagKeyInt Buff3PlayerCanCancel = new TagKeyInt(271363);
		public static TagKeyInt ComboAnimation3 = new TagKeyInt(262914);
		public static TagKeySNO Combo1CastingEffectGroup_Male = new TagKeySNO(264289);
		public static TagKeySNO Combo1CastingEffectGroup_Female = new TagKeySNO(264321);
		public static TagKeyInt AffectedByDualWield = new TagKeyInt(328448);
		public static TagKeySNO Combo0CastingEffectGroup_Male = new TagKeySNO(264288);
		public static TagKeySNO Combo0CastingEffectGroup_Female = new TagKeySNO(264320);
		public static TagKeySNO Combo2CastingEffectGroup_Male = new TagKeySNO(264290);
		public static TagKeySNO Combo2CastingEffectGroup_Female = new TagKeySNO(264322);
		public static TagKeyScript ScriptFormula30 = new TagKeyScript(267264);
		public static TagKeyScript ScriptFormula31 = new TagKeyScript(267280);
		public static TagKeyScript ScriptFormula32 = new TagKeyScript(267296);
		public static TagKeyScript ScriptFormula33 = new TagKeyScript(267312);
		public static TagKeyScript ScriptFormula34 = new TagKeyScript(267328);
		public static TagKeyScript ScriptFormula35 = new TagKeyScript(267344);
		public static TagKeyScript ScriptFormula36 = new TagKeyScript(267360);
		public static TagKeyScript ScriptFormula37 = new TagKeyScript(267376);
		public static TagKeyScript ScriptFormula58 = new TagKeyScript(267904);
		public static TagKeyScript ScriptFormula59 = new TagKeyScript(267920);
		public static TagKeyScript SpiritGained = new TagKeyScript(684928);
		public static TagKeyScript CurseDamageAmplifyPercent = new TagKeyScript(331536);
		public static TagKeyInt Buff4Icon = new TagKeyInt(270596);
		public static TagKeyInt Buff4ShowDuration = new TagKeyInt(271108);
		public static TagKeySNO Buff4EffectGroup = new TagKeySNO(270340);
		public static TagKeyScript FailsIfSilenced = new TagKeyScript(328321);
		public static TagKeyInt Buff4PlayerCanCancel = new TagKeyInt(271364);
		public static TagKeyInt IsPhysical = new TagKeyInt(328624);
		public static TagKeyInt HitsoundOverride = new TagKeyInt(262433);
		public static TagKeyScript ScriptFormula25 = new TagKeyScript(267088);
		public static TagKeyInt Requires2HItem = new TagKeyInt(328992);
		public static TagKeyInt Buff2IsHarmful = new TagKeyInt(270850);
		public static TagKeyInt RequiresActorTarget = new TagKeyInt(328240);
		public static TagKeyInt ClipsTargetToAttackRadius = new TagKeyInt(684848);
		public static TagKeyInt CastTargetNeutral = new TagKeyInt(328145);
		public static TagKeyInt LOSCheck = new TagKeyInt(328720);
		public static TagKeyScript AttackRating = new TagKeyScript(329888);
		public static TagKeyScript DestructableObjectDamageDelay = new TagKeyScript(618496);
		public static TagKeyInt TargetNeutral = new TagKeyInt(328144);
		public static TagKeySNO ExplosionActor = new TagKeySNO(262401);
		public static TagKeyScript StunChance = new TagKeyScript(330816);
		public static TagKeyScript StunDurationMin = new TagKeyScript(330784);
		public static TagKeyScript PhysicalDamageDelta = new TagKeyScript(330000);
		public static TagKeyScript PhysicalDamageMin = new TagKeyScript(329984);
		public static TagKeyInt IsItemPower = new TagKeyInt(328601);
		public static TagKeyInt CastTargetCorpse = new TagKeyInt(328129);
		public static TagKeyScript SummonedActorLevel = new TagKeyScript(331136);
		public static TagKeyInt TargetContactPlaneOnly = new TagKeyInt(328162);
		public static TagKeyInt DontWalkCloserIfOutOfRange = new TagKeyInt(328256);
		public static TagKeyScript ResourceGainedOnFirstHit = new TagKeyScript(329627);
		public static TagKeyInt LocksActorsWhileSweeping = new TagKeyInt(328420);
		public static TagKeyInt Buff1IsHarmful = new TagKeyInt(270849);
		public static TagKeyScript FailsIfImmobilized = new TagKeyScript(328320);
		public static TagKeyInt StartWalkAfterIntro = new TagKeyInt(328288);
		public static TagKeyInt RollToDestination = new TagKeyInt(328368);
		public static TagKeyInt PickupItemsWhileMoving = new TagKeyInt(655984);
		public static TagKeyScript WalkingSpeedMultiplier = new TagKeyScript(331952);
		public static TagKeyScript SpecialWalkPlayerEndAnimScalar = new TagKeyScript(328536);
		public static TagKeyInt NeverUpdatesFacingStarting = new TagKeyInt(328016);
		public static TagKeyInt RequiresSkillPoint = new TagKeyInt(328248);
		public static TagKeyInt IsKnockbackMovement = new TagKeyInt(327860);
		public static TagKeyInt SpecialWalkIsKnockback = new TagKeyInt(332362);
		public static TagKeyScript BreaksImmobilize = new TagKeyScript(328304);
		public static TagKeyScript ImmunetoFearduring = new TagKeyScript(682243);
		public static TagKeyScript ImmunetoRootduring = new TagKeyScript(682240);
		public static TagKeyScript ImmunetoSnareduring = new TagKeyScript(682241);
		public static TagKeyScript ImmunetoStunduring = new TagKeyScript(682242);
		public static TagKeyInt CastTargetNormalMonstersOnly = new TagKeyInt(328617);
		public static TagKeyInt CausesClosingCooldown = new TagKeyInt(328632);
		public static TagKeyInt CastTargetIgnoreLargeMonsters = new TagKeyInt(328616);
		public static TagKeyScript CustomTargetMaxRange = new TagKeyScript(328784);
		public static TagKeySNO CustomTargetBuffPowerSNO = new TagKeySNO(328802);
		public static TagKeyScript FireDamageDelta = new TagKeyScript(330064);
		public static TagKeyScript FireDamageMin = new TagKeyScript(330048);
		public static TagKeyInt DisplaysNoDamage = new TagKeyInt(327829);
		public static TagKeyScript SkillPointCost = new TagKeyScript(329312);
		public static TagKeyInt CannotLockOntoActors = new TagKeyInt(328416);
		public static TagKeyInt ChannelledLocksActors = new TagKeyInt(328401);
		public static TagKeyInt NoAffectedACD = new TagKeyInt(328176);
		public static TagKeyScript ResourceCostReductionCoefficient = new TagKeyScript(329625);
		public static TagKeyInt TargetNavMeshOnly = new TagKeyInt(328163);
		public static TagKeySNO HitEffect = new TagKeySNO(684034);
		public static TagKeyInt OverrideHitEffects = new TagKeyInt(684032);
		public static TagKeyInt AnimationTagRuneE = new TagKeyInt(262677);
		public static TagKeyScript LifestealPercent = new TagKeyScript(331224);
		public static TagKeyScript CritChance = new TagKeyScript(331008);
		public static TagKeyScript GhostSoulsiphonMaxChannellingDistance = new TagKeyScript(365056);
		public static TagKeySNO Source_DestEffectGroup = new TagKeySNO(262659);
		public static TagKeyScript GhostSoulsiphonMaxChannellingTime = new TagKeyScript(364800);
		public static TagKeyScript GhostSoulsiphonSlowMultiplier = new TagKeyScript(364544);
		public static TagKeyScript GhostSoulsiphonDamagePerSecond = new TagKeyScript(365312);
		public static TagKeyInt CastTargetAllowDeadTargets = new TagKeyInt(328620);
		public static TagKeyScript BuffDurationDelta = new TagKeyScript(332752);
		public static TagKeyScript SlowMovementSpeedMultiplier = new TagKeyScript(692224);
		public static TagKeyScript FireDuration = new TagKeyScript(329976);
		public static TagKeyInt IsCancellable = new TagKeyInt(328544);
		public static TagKeyScript StunDurationDelta = new TagKeyScript(330800);
		public static TagKeySNO Rope = new TagKeySNO(262432);
		public static TagKeyScript LoopingAnimationTime = new TagKeyScript(263296);
		public static TagKeyInt ClassRestriction = new TagKeyInt(329648);
		public static TagKeyInt AlwaysKnown = new TagKeyInt(329536);
		public static TagKeyScript ScriptFormula38 = new TagKeyScript(267392);
		public static TagKeyScript ScriptFormula39 = new TagKeyScript(267408);
		public static TagKeyInt GenericBuffAttribute2 = new TagKeyInt(655648);
		public static TagKeyInt GenericBuffAttribute3 = new TagKeyInt(655664);
		public static TagKeyInt GenericBuffAttribute1 = new TagKeyInt(655632);
		public static TagKeyInt GenericBuffAttribute0 = new TagKeyInt(655616);
		public static TagKeyScript GenericBuffAttribute2Formula = new TagKeyScript(655649);
		public static TagKeyScript GenericBuffAttribute3Formula = new TagKeyScript(655665);
		public static TagKeyScript GenericBuffAttribute1Formula = new TagKeyScript(655633);
		public static TagKeyScript GenericBuffAttribute0Formula = new TagKeyScript(655617);
		public static TagKeyInt CallAIUpdateImmediatelyUponTermination = new TagKeyInt(328604);
		public static TagKeyInt ChecksVerticalMovement = new TagKeyInt(327864);
		public static TagKeyInt DoesntPreplayAnimation = new TagKeyInt(328611);
		public static TagKeyInt IsCompletedWhenWalkingStops = new TagKeyInt(328608);
		public static TagKeyScript DelayBeforeSettingTarget = new TagKeyScript(328539);
		public static TagKeyScript KnockbackMagnitude = new TagKeyScript(331696);
		public static TagKeyScript WhirlwindKnockbackMagnitude = new TagKeyScript(331664);
		public static TagKeyScript RetaliationKnockbackMagnitude = new TagKeyScript(331648);
		public static TagKeyInt ScaledAnimTiming = new TagKeyInt(328192);
		public static TagKeyInt IsADodgePower = new TagKeyInt(328480);
		public static TagKeyScript DodgeTravelDistanceMin = new TagKeyScript(332384);
		public static TagKeyScript DodgeTravelSpeed = new TagKeyScript(331936);
		public static TagKeyScript DodgeTravelAngleOffset = new TagKeyScript(332544);
		public static TagKeyInt TargetDoesntRequireActor = new TagKeyInt(328615);
		public static TagKeyInt CancelsOtherPowers = new TagKeyInt(328560);
		public static TagKeyInt NoInterruptTimer = new TagKeyInt(684880);
		public static TagKeyScript FuryCoefficient = new TagKeyScript(332180);
		public static TagKeyInt BrainActionType = new TagKeyInt(328704);
		public static TagKeyScript AIActionDurationMin = new TagKeyScript(332864);
		public static TagKeyScript WhirlwindDurationMin = new TagKeyScript(361504);
		public static TagKeyScript WhirlwindMovementSpeed = new TagKeyScript(361521);
		public static TagKeyScript KnockbackGravityMin = new TagKeyScript(331708);
		public static TagKeyScript KnockbackHeightMin = new TagKeyScript(331704);
		public static TagKeyScript HitpointsGrantedByHeal = new TagKeyScript(331264);
		public static TagKeySNO ChildPower = new TagKeySNO(327760);
		public static TagKeyScript HearthTime = new TagKeyScript(643072);
		public static TagKeyScript MovementSpeedPercentIncreaseMin = new TagKeyScript(332000);
		public static TagKeyScript AttackSpeedPercentIncreaseMin = new TagKeyScript(331968);
		public static TagKeyScript DamagePercentAll = new TagKeyScript(330752);
		public static TagKeySNO ProjectileWallFloorExplosion = new TagKeySNO(262410);
		public static TagKeyInt OnlyFreeCast = new TagKeyInt(329633);
		public static TagKeyInt ProcTargetsSelf = new TagKeyInt(328440);
		public static TagKeyScript ScriptFormula24 = new TagKeyScript(267072);
		public static TagKeyScript HealthCost = new TagKeyScript(329632);
		public static TagKeyScript WalkingDistanceMin = new TagKeyScript(331960);
		public static TagKeyInt AnimationTagRuneC = new TagKeyInt(262675);
		public static TagKeyScript IsInvisibleDuring = new TagKeyScript(340141);
		public static TagKeyInt SetTargetAfterIntro = new TagKeyInt(328292);
		public static TagKeyScript MinWalkDuration = new TagKeyScript(328535);
		public static TagKeyScript ScriptFormula27 = new TagKeyScript(267120);
		public static TagKeyInt AnimationTagRuneB = new TagKeyInt(262674);
		public static TagKeyInt AnimationTagRuneA = new TagKeyInt(262673);
		public static TagKeyScript AIActionDurationDelta = new TagKeyScript(332880);
		public static TagKeyInt UsesWeaponRange = new TagKeyInt(328607);
		public static TagKeySNO Combo1ContactFrameEffectGroup_Male = new TagKeySNO(264305);
		public static TagKeySNO Combo1ContactFrameEffectGroup_Female = new TagKeySNO(264337);
		public static TagKeySNO Combo0ContactFrameEffectGroup_Male = new TagKeySNO(264304);
		public static TagKeySNO Combo0ContactFrameEffectGroup_Female = new TagKeySNO(264336);
		public static TagKeySNO Combo2ContactFrameEffectGroup_Male = new TagKeySNO(264306);
		public static TagKeySNO Combo2ContactFrameEffectGroup_Female = new TagKeySNO(264338);
		public static TagKeyInt Requires1HItem = new TagKeyInt(328976);
		public static TagKeyScript SkeletonSummonMaxTotalCount = new TagKeyScript(332450);
		public static TagKeyScript SkeletonSummonCountPerSummon = new TagKeyScript(332448);
		public static TagKeyInt PlaySummonedByMonsterAnimation = new TagKeyInt(331137);
		public static TagKeyScript SkeletonSummonMaxCount = new TagKeyScript(332449);
		public static TagKeyScript SummonedActorLifeDuration = new TagKeyScript(331120);
		public static TagKeySNO ContactFrameEffectGroup_Male2 = new TagKeySNO(264194);
		public static TagKeySNO ContactFrameEffectGroup_Female2 = new TagKeySNO(264277);
		public static TagKeyInt ArcMoveUntilDestHeight = new TagKeyInt(328296);
		public static TagKeyScript RunInFrontDistance = new TagKeyScript(565248);
		public static TagKeyScript SpecialWalkHeightIsRelativeToMax = new TagKeyScript(332338);
		public static TagKeyScript SpecialWalkTrajectoryGravityDelta = new TagKeyScript(332337);
		public static TagKeyScript SpecialWalkTrajectoryHeightDelta = new TagKeyScript(332321);
		public static TagKeyScript PierceChance = new TagKeyScript(331040);
		public static TagKeyInt CanPathDuringWalk = new TagKeyInt(328272);
		public static TagKeyScript UseSpecialWalkSteering = new TagKeyScript(328538);
		public static TagKeyInt UsesAnimTag2IfBuffExists = new TagKeyInt(266240);
		public static TagKeyInt IsEmote = new TagKeyInt(264704);
		public static TagKeySNO EmoteConversationSNO = new TagKeySNO(264720);
		public static TagKeyInt SpellFuncCreate = new TagKeyInt(327697);
		public static TagKeyScript NovaDelay = new TagKeyScript(655985);
		public static TagKeyScript AuraAffectedRadius = new TagKeyScript(331840);
		public static TagKeyScript BuffDurationBetweenPulses = new TagKeyScript(332768);
		public static TagKeyScript PowerGainedPerSecond = new TagKeyScript(700435);
		public static TagKeyScript ManaGainedPerSecond = new TagKeyScript(331520);
		public static TagKeyScript FuryGenerationBonusPercent = new TagKeyScript(700434);
		public static TagKeyScript SpiritGenerationBonusPercent = new TagKeyScript(700433);
		public static TagKeyScript ArcanumGainedPerSecond = new TagKeyScript(700432);
		public static TagKeyScript PoisonDamageDelta = new TagKeyScript(330256);
		public static TagKeyScript PoisonDamageMin = new TagKeyScript(330240);
		public static TagKeyScript PoisonCloudNumIntervals = new TagKeyScript(330992);
		public static TagKeyScript PoisonCloudIntervalDuration = new TagKeyScript(330976);
		public static TagKeySNO TargetImpactParticle = new TagKeySNO(262405);
		public static TagKeyInt IsPunch = new TagKeyInt(327792);
		public static TagKeyInt Buff5ShowDuration = new TagKeyInt(271109);
		public static TagKeyInt Buff5PlayerCanCancel = new TagKeyInt(271365);
		public static TagKeyInt Buff6ShowDuration = new TagKeyInt(271110);
		public static TagKeyInt Buff6PlayerCanCancel = new TagKeyInt(271366);
		public static TagKeyInt Buff6Icon = new TagKeyInt(270598);
		public static TagKeyInt Buff5Icon = new TagKeyInt(270597);
		public static TagKeyInt SnapsToGround = new TagKeyInt(328496);
		public static TagKeyInt CanUseWhenDead = new TagKeyInt(328528);
		public static TagKeyScript BlindDurationMin = new TagKeyScript(684577);
		public static TagKeyScript PayloadParam1 = new TagKeyScript(329792);
		public static TagKeyScript BlindDurationDelta = new TagKeyScript(684578);
		public static TagKeyScript CanUseWhenFeared = new TagKeyScript(328512);
		public static TagKeyScript ResurrectionBuffTime = new TagKeyScript(647168);
		public static TagKeyScript ResurrectionHealthMultiplierToStart = new TagKeyScript(651264);
		public static TagKeyScript ProjectileCount = new TagKeyScript(331193);
		public static TagKeyScript ProjectileJitter = new TagKeyScript(331196);
		public static TagKeySNO RootGrabPower = new TagKeySNO(606208);
		public static TagKeyScript RootTimerModificationPerStruggle = new TagKeyScript(360960);
		public static TagKeyScript PercentofDamageThatShieldCanAbsorb = new TagKeyScript(332641);
		public static TagKeyScript AnatomyCritBonusPercent = new TagKeyScript(413696);
		public static TagKeyScript VanishDuration = new TagKeyScript(458752);
		public static TagKeyScript HitpointsThatShieldCanAbsorb = new TagKeyScript(332640);
		public static TagKeyScript ShrineBuffRadius = new TagKeyScript(633603);
		public static TagKeyInt ShrineBuffAllies = new TagKeyInt(633602);
		public static TagKeyScript ScaleBonus = new TagKeyScript(332024);
		public static TagKeyScript DefensePercentAll = new TagKeyScript(330768);
		public static TagKeyScript BonusHitpointPercent = new TagKeyScript(331568);
		public static TagKeyScript ShrineBuffBonus = new TagKeyScript(633601);
		public static TagKeyInt SummonedAnimationTag = new TagKeyInt(332451);
		public static TagKeyScript ArcaneDamageMin = new TagKeyScript(330304);
		public static TagKeyScript ArcaneDamageDelta = new TagKeyScript(330320);
		public static TagKeyScript BlizzardInitialImpactDelay = new TagKeyScript(332080);
		public static TagKeySNO ChainRope = new TagKeySNO(262403);
		public static TagKeyScript ImmobilizeDurationDelta = new TagKeyScript(330880);
		public static TagKeyScript WebDurationDelta = new TagKeyScript(330848);
		public static TagKeyScript ImmobilizeDurationMin = new TagKeyScript(330864);
		public static TagKeyScript WebDurationMin = new TagKeyScript(330832);
		public static TagKeyInt IsToggleable = new TagKeyInt(327952);
		public static TagKeyScript SlowDurationMin = new TagKeyScript(330896);
		public static TagKeyInt IsUsableInCombat = new TagKeyInt(328081);
		public static TagKeyInt CastTargetGroundOnly = new TagKeyInt(328161);
		public static TagKeyInt CausesKnockback = new TagKeyInt(331697);
		public static TagKeyInt ClientControlsFacing = new TagKeyInt(328022);
		public static TagKeyScript DisintegrateBeamWidth = new TagKeyScript(332304);
		public static TagKeyScript DisintegrateTimeBetweenUpdates = new TagKeyScript(332688);
		public static TagKeyInt CustomTargetBuffPowerSNOBuffIndex = new TagKeyInt(328801);
		public static TagKeyInt ProjectileThrowOverGuys = new TagKeyInt(262408);
		public static TagKeyInt IsLobbed = new TagKeyInt(327872);
		public static TagKeyScript DurationDelta = new TagKeyScript(684930);
		public static TagKeyScript DurationMin = new TagKeyScript(684929);
		public static TagKeyInt UsesWeaponProjectile = new TagKeyInt(262480);
		public static TagKeyScript ModalCursorRadius = new TagKeyScript(328069);
		public static TagKeyFloat ProjectileGravity = new TagKeyFloat(329872);
		public static TagKeyInt ProjectileScaleVelocity = new TagKeyInt(262435);
		public static TagKeyScript HeightAboveSource = new TagKeyScript(329880);
		public static TagKeyScript ProjectileSpreadAngle = new TagKeyScript(331194);
		public static TagKeyFloat CustomTargetNeedsHealHPPercent = new TagKeyFloat(328804);
		public static TagKeyScript EnergyShieldManaCostPerDamage = new TagKeyScript(332576);
		public static TagKeySNO SynergyPower = new TagKeySNO(327764);
		public static TagKeyInt IsUpgrade = new TagKeyInt(329216);
		public static TagKeyFloat AnimationTurnThreshold = new TagKeyFloat(263426);
		public static TagKeyInt AnimationTagTurnRight = new TagKeyInt(263425);
		public static TagKeyInt AnimationTagTurnLeft = new TagKeyInt(263424);
		public static TagKeyInt IsOnlyUsableInTownPortalAreas = new TagKeyInt(328082);
		public static TagKeyInt IsCancellableByWalking = new TagKeyInt(328546);
		public static TagKeyInt FollowWalkAnimTag = new TagKeyInt(561424);
		public static TagKeyInt FollowMatchTargetSpeed = new TagKeyInt(561408);
		public static TagKeyScript RunNearbyDistanceMin = new TagKeyScript(332416);
		public static TagKeyScript RunNearbyDistanceDelta = new TagKeyScript(332432);
		public static TagKeyScript FollowStartDistance = new TagKeyScript(561152);
		public static TagKeyScript FollowStopDistance = new TagKeyScript(557056);
		public static TagKeyInt Buff5IsHarmful = new TagKeyInt(270853);
		public static TagKeySNO Buff5EffectGroup = new TagKeySNO(270341);
		public static TagKeyInt Buff4IsHarmful = new TagKeyInt(270852);
		public static TagKeyScript HolyDamageMin = new TagKeyScript(330496);
		public static TagKeyScript HolyDamageDelta = new TagKeyScript(330512);
		public static TagKeyScript DestinationJitterAttempts = new TagKeyScript(360704);
		public static TagKeyScript DestinationJitterRadius = new TagKeyScript(360448);
		public static TagKeyInt RootEndFunc = new TagKeyInt(606464);
		public static TagKeySNO ConsumesItem = new TagKeySNO(329088);
		public static TagKeyScript DebuffDurationMin = new TagKeyScript(655680);
		public static TagKeyScript ProcChance = new TagKeyScript(680704);
		public static TagKeySNO Upgrade2 = new TagKeySNO(329264);
		public static TagKeySNO Upgrade1 = new TagKeySNO(329248);
		public static TagKeySNO Upgrade0 = new TagKeySNO(329232);
		public static TagKeyScript FreezeDamageDoneMin = new TagKeyScript(331232);
		public static TagKeyScript AttackRatingPercent = new TagKeyScript(329904);
		public static TagKeyScript SummoningMachineNodeIsInvulnerable = new TagKeyScript(704512);
		public static TagKeySNO DamageDisplayPower = new TagKeySNO(627456);
		public static TagKeySNO Buff6EffectGroup = new TagKeySNO(270342);
		public static TagKeyInt Buff6IsHarmful = new TagKeyInt(270854);
		public static TagKeyScript DodgeTravelDistanceDelta = new TagKeyScript(332400);
		public static TagKeySNO Buff7EffectGroup = new TagKeySNO(270343);
		public static TagKeyInt ComboAnimation1RuneA = new TagKeyInt(263185);
		public static TagKeyScript KnockbackGravityDelta = new TagKeyScript(331709);
		public static TagKeyScript KnockbackHeightDelta = new TagKeyScript(331705);
		public static TagKeyScript FuryAddPerInterval = new TagKeyScript(332178);
		public static TagKeyScript FuryDegenerationOutofCombat_persecond = new TagKeyScript(332177);
		public static TagKeyScript FuryGainedPerSecondOfAttack = new TagKeyScript(332097);
		public static TagKeyScript FuryTimeBetweenUpdates = new TagKeyScript(333056);
		public static TagKeyScript FuryDegenerationStart_inseconds = new TagKeyScript(332181);
		public static TagKeyScript FuryGainedPerPercentHealthLost = new TagKeyScript(332096);
		public static TagKeyScript FuryMaxDamageBonus = new TagKeyScript(332185);
		public static TagKeyScript SlowTimeAmount = new TagKeyScript(330944);
		public static TagKeyScript SlowAmount = new TagKeyScript(330928);
		public static TagKeyInt ComboAnimation1RuneC = new TagKeyInt(263187);
		public static TagKeyInt ComboAnimation1RuneE = new TagKeyInt(263189);
		public static TagKeyInt ComboAnimation1RuneD = new TagKeyInt(263188);
		public static TagKeyInt ComboAnimation1RuneB = new TagKeyInt(263186);
		public static TagKeyInt ComboAnimation3RuneC = new TagKeyInt(263219);
		public static TagKeyInt AnimationTagRuneD = new TagKeyInt(262676);
		public static TagKeyScript GenericBuffAttribute0AndParameter = new TagKeyScript(655618);
		public static TagKeyScript GenericBuffAttribute1AndParameter = new TagKeyScript(655634);
		public static TagKeyInt SpecialWalkGoThroughOccluded = new TagKeyInt(332341);
		public static TagKeyScript ProcCoefficient = new TagKeyScript(329983);
	}
}
