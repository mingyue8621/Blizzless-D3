﻿//Blizzless Project 2022 
using DiIiS_NA.Core.Logging;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.GameSystem;
//Blizzless Project 2022 
using System;
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.AccountsSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.QuestSystem.QuestEvents;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.Math;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.QuestSystem.QuestEvents.Implementations;
//Blizzless Project 2022 
using System.Linq;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.PlayerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.AISystem.Brains;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Pet;
//Blizzless Project 2022 
using DiIiS_NA.Core.Helpers.Hash;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.ActorSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations.Hirelings;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations.ScriptObjects;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Hireling;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Base;

namespace DiIiS_NA.GameServer.GSSystem.QuestSystem
{
	public class ActII : QuestRegistry
	{
		static readonly Logger Logger = LogManager.CreateLogger();

		public int refugees = 0; //temp

		public ActII(Game game) : base(game)
		{
		}

		public override void SetQuests()
		{
			#region Shadows in the Desert
			this.Game.QuestManager.Quests.Add(80322, new Quest { RewardXp = 4400, RewardGold = 490, Completed = false, Saveable = true, NextQuest = 93396, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[80322].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 82,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
					//ListenProximity(151989, new Advance());
					ListenConversation(57401, new Advance());
					//Base world State
					this.Game.GetWorld(70885).GetActorBySNO(175810).SetUsable(false); //Khamsim_Gate
					this.Game.GetWorld(70885).GetActorBySNO(96132).Hidden = true; //Bezir
					this.Game.GetWorld(70885).ShowOnlyNumNPC(2928, 1); //Kadin
					this.Game.GetWorld(70885).ShowOnlyNumNPC(51291, 1); //Aleser
					this.Game.GetWorld(70885).ShowOnlyNumNPC(51292, 1); //Caliem
					this.Game.GetWorld(70885).ShowOnlyNumNPC(80980, -1); //Davyd
					foreach (var Door in this.Game.GetWorld(70885).GetActorsBySNO(175810))
						Door.SetUsable(false);//Khamsim_Gate
					
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(82, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 85,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //go to Caldeum
					ListenTeleport(55313, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(85, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 50,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Asheera (201085)
					this.Game.GetWorld(70885).GetActorBySNO(162378).SetUsable(false);
					this.Game.GetWorld(70885).ShowOnlyNumNPC(3205, 2);
					UnlockTeleport(0);
					//ListenProximity(3205, new LaunchConversation(201085));
					ListenConversation(201085, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(50, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 61,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //go through canyon
					try 
					{
						Door TDoor = (this.Game.GetWorld(70885).FindAt(169502, new Vector3D { X = 2905.62f, Y = 1568.82f, Z = 250.75f }, 6.0f) as Door);
						//ListenProximity(TDoor, )
						TDoor.Open();
					} catch { }
					//ListenProximity(85843, new LaunchConversation(169197));
					ListenConversation(169197, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(61, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 52,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill cultists
					AddFollower(this.Game.GetWorld(70885), 85843);
					//ListenProximity(85843, new SpawnCultists());
					script = new SpawnCultists();
					script.Execute(this.Game.GetWorld(70885));
					ListenKill(6027, 7, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(52, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 102,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with enchantress
					DestroyFollower(85843);
					//ListenProximity(85843, new LaunchConversation(85832));
					var EnchNPC = (this.Game.GetWorld(70885).GetActorBySNO(85843) as InteractiveNPC);
					EnchNPC.Conversations.Clear();
					EnchNPC.Conversations.Add(new ActorSystem.Interactions.ConversationInteraction(85832));
					ListenConversation(85832, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(102, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 106,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill Lakuni's
					this.Game.GetWorld(70885).GetActorBySNO(85843).Hidden = true;
					AddFollower(this.Game.GetWorld(70885), 85843);
					Open(this.Game.GetWorld(70885), 180225);
					ListenKill(4541, 5, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(106, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 91,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Steel Wolf's leader
					DestroyFollower(85843);
					AddFollower(this.Game.GetWorld(70885), 85843);
					//ListenProximity(164195, new LaunchConversation(164197));
					var Leader = (this.Game.GetWorld(70885).GetActorBySNO(164195) as InteractiveNPC);
					Leader.Conversations.Clear();
					Leader.Conversations.Add(new ActorSystem.Interactions.ConversationInteraction(164197));
					ListenConversation(164197, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(91, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 58,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 }, new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //break rituals (2 counters)
					DestroyFollower(85843);
					AddFollower(this.Game.GetWorld(70885), 85843);
					var Leader = (this.Game.GetWorld(70885).GetActorBySNO(164195) as InteractiveNPC);
					Leader.Conversations.Clear();
					ListenProximity(171329, new CompleteObjective(0));
					ListenProximity(3594, new CompleteObjective(1));
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(58, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 117,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //go to Canyon Bridge
					DestroyFollower(85843);
					AddFollower(this.Game.GetWorld(70885), 85843);
					ListenProximity(3665, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(117, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 10,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with enchantress
					DestroyFollower(85843);
					AddFollower(this.Game.GetWorld(70885), 85843);
					ListenProximity(85843, new LaunchConversation(86196));
					ListenConversation(86196, new Advance());
				})
			});

			this.Game.QuestManager.Quests[80322].Steps.Add(10, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
					DestroyFollower(85843);
					Open(this.Game.GetWorld(70885), 185949);
					if (!this.Game.Empty)
						foreach (var plr in this.Game.Players.Values)
						{
							if (!plr.HirelingEnchantressUnlocked)
							{
								plr.HirelingEnchantressUnlocked = true;
								plr.InGameClient.SendMessage(new HirelingNewUnlocked() { NewClass = 3 });
								plr.GrantAchievement(74987243307145);
							}
							if (this.Game.Players.Count > 1)
								plr.InGameClient.SendMessage(new HirelingNoSwapMessage() { NewClass = 3 }); //Призвать нельзя!
							else
								plr.InGameClient.SendMessage(new HirelingSwapMessage() { NewClass = 3 }); //Возможность призвать Храмовника
						}
				})
			});

			#endregion
			#region Road to Alcarnus
			this.Game.QuestManager.Quests.Add(93396, new Quest { RewardXp = 4600, RewardGold = 500, Completed = false, Saveable = true, NextQuest = 74128, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[93396].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 76,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});

			this.Game.QuestManager.Quests[93396].Steps.Add(76, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 58,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //go through Canyon bridge
					ListenProximity(6442, new Advance());
					
				})
			});

			this.Game.QuestManager.Quests[93396].Steps.Add(58, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 46,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find Khasim gate
					ListenProximity(145599, new Advance());
					this.Game.GetWorld(70885).GetActorBySNO(96132).Hidden = true; //Bezir
					this.Game.GetWorld(70885).ShowOnlyNumNPC(2928, 0); //Kadin
					this.Game.GetWorld(70885).ShowOnlyNumNPC(51291, 0); //Aleser
					this.Game.GetWorld(70885).ShowOnlyNumNPC(51292, 0); //Caliem
					this.Game.GetWorld(70885).ShowOnlyNumNPC(80980, -1); //Davyd

				})
			});

			this.Game.QuestManager.Quests[93396].Steps.Add(46, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 74,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with leutenant Vahem
					UnlockTeleport(2);
					UnlockTeleport(3);
					//ListenProximity(90959, new LaunchConversation(201369));
					ListenConversation(201369, new Advance());
				})
			});

			this.Game.QuestManager.Quests[93396].Steps.Add(74, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 30,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter HQ
					ListenTeleport(61066, new Advance());
				})
			});

			this.Game.QuestManager.Quests[93396].Steps.Add(30, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 4,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 }, new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill demons and open cell
					this.Game.AddOnLoadAction(60432, () =>
					{
						if ((Game.CurrentQuest == 93396 & Game.CurrentStep == 30) || (Game.CurrentQuest == 93396 & Game.CurrentStep == 74))
						{
							DisableEveryone(this.Game.GetWorld(60432), true);

							StartConversation(this.Game.GetWorld(60432), 195060);
							ListenConversation(195060, new LaunchConversation(195062));
							ListenConversation(195062, new KhasimHQ());

							//ListenKill(60583, 1, new CompleteObjective(0));
							ListenKill(5434, 6, new CompleteObjective(0));
							//5434
							ListenInteract(185284, 1, new CompleteObjective(1));
						}
					});
					

				})
			});

			this.Game.QuestManager.Quests[93396].Steps.Add(4, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 48,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill stealthed demons
					script = new SpawnSnakemans();
					script.Execute(this.Game.GetWorld(70885));
					ListenKill(60816, 3, new Advance());
				})
			});

			this.Game.QuestManager.Quests[93396].Steps.Add(48, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 10,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with captain David
					this.Game.GetWorld(70885).ShowOnlyNumNPC(80980, 1);
					//ListenProximity(80980, new LaunchConversation(60608));
					ListenConversation(81351, new Advance());
				})
			});

			this.Game.QuestManager.Quests[93396].Steps.Add(10, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
					Open(this.Game.GetWorld(70885), 175810);
				})
			});

			#endregion
			#region City on Blood
			this.Game.QuestManager.Quests.Add(74128, new Quest { RewardXp = 6600, RewardGold = 765, Completed = false, Saveable = true, NextQuest = 57331, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[74128].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 5,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});

			this.Game.QuestManager.Quests[74128].Steps.Add(5, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 54,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 }, new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //exit through Khasim east gates and find Alcarnus
					ListenProximity(80980, new CompleteObjective(0));
					ListenProximity(3410, new CompleteObjective(1));
				})
			});

			this.Game.QuestManager.Quests[74128].Steps.Add(54, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 26,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find Maghda's lair and optionally, free 8 cells
					var encW = this.Game.GetWorld(70885);
					encW.SpawnMonster(3628, new Vector3D(528.7084f,	 1469.1945f, 197.2559f));
					encW.SpawnMonster(3628, new Vector3D(475.812f,	 1554.7146f, 197.25589f));
					encW.SpawnMonster(3628, new Vector3D(463.88342f, 1542.4092f, 197.25587f));
					encW.SpawnMonster(3628, new Vector3D(399.93198f, 1485.7723f, 197.38196f));
					encW.SpawnMonster(3628, new Vector3D(509.43765f, 1254.6984f, 197.31921f));
					ListenInteract(3628, 8, new Dummy());
					ListenTeleport(195268, new Advance());
				})
			});

			this.Game.QuestManager.Quests[74128].Steps.Add(26, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 9,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill Maghda
					UnlockTeleport(4);
					ListenKill(6031, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[74128].Steps.Add(9, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 10,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //return to camp
					this.Game.CurrentEncounter.activated = false;
					this.Game.AddOnLoadAction(195200, () =>
					{
						Open(this.Game.GetWorld(195200), 214196);
					});
					ListenProximity(191492, new Advance());
				})
			});

			this.Game.QuestManager.Quests[74128].Steps.Add(10, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
					PlayCutscene(1);
				})
			});

			#endregion
			#region Audience with Emperor
			this.Game.QuestManager.Quests.Add(57331, new Quest { RewardXp = 1875, RewardGold = 260, Completed = false, Saveable = true, NextQuest = 78264, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[57331].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});

			this.Game.QuestManager.Quests[57331].Steps.Add(1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 38,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Asheera
											   //ListenProximity(3205, new LaunchConversation(201285));
					this.Game.GetWorld(70885).ShowOnlyNumNPC(3205, 0);
					ListenConversation(201285, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57331].Steps.Add(38, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 18,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Asheera for reach emperor's palace
											   //ListenConversation(165807, new Advance());
					ListenProximity(164057, new AskBossEncounter(162231));
					ListenTeleport(81178, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57331].Steps.Add(18, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 21,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Emperor
					this.Game.AddOnLoadAction(81715, () =>
					{
						//ID: 59447 Name: BelialBoyEmperor
						foreach (var plr in this.Game.Players.Values)
						{
							plr.InGameClient.SendMessage(new MessageSystem.Message.Definitions.Camera.CameraCriptedSequenceStartMessage() { Activate = true });
							plr.InGameClient.SendMessage(new MessageSystem.Message.Definitions.Camera.CameraFocusMessage() { ActorID = (int)this.Game.GetWorld(81715).GetActorBySNO(59447).DynamicID(plr), Duration = 1f, Snap = false });
						}
						foreach (var leah in this.Game.GetWorld(81715).GetActorsBySNO(4580))
							if (leah is TownLeah)
								(leah as TownLeah).Brain.DeActivate();
						setActorOperable(this.Game.GetWorld(81715), 190236, false);
						DisableEveryone(this.Game.GetWorld(81715), true);
						StartConversation(this.Game.GetWorld(81715), 160894);
					});
					//ListenTeleport(81178, new LaunchConversation(160894));
					ListenConversation(160894, new LaunchConversation(160896));
					ListenConversation(160896, new LaunchConversation(116036));
					ListenConversation(116036, new EndCutSceneWithAdvance());
				})
			});

			this.Game.QuestManager.Quests[57331].Steps.Add(21, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 2,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill demons
					int snakes = 0;
					this.Game.AddOnLoadAction(81715, () =>
					{
						if (this.Game.CurrentQuest == 57331 && this.Game.CurrentStep == 21)
						{
							DisableEveryone(this.Game.GetWorld(81715), false);
							AddFollower(this.Game.GetWorld(81715), 4580);
							foreach (var leah in this.Game.GetWorld(81715).GetActorsBySNO(4580))
								if (leah is TownLeah)
									(leah as TownLeah).Brain.Activate(); 
							script = new SpawnSnakemanGuards();
							script.Execute(this.Game.GetWorld(81715));

							foreach (var snake in this.Game.GetWorld(81715).GetActorsBySNO(60816))
								snakes++;
						}
					});
					
					ListenKill(60816, snakes, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57331].Steps.Add(2, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 31,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //escape the emperor's palace
					this.Game.AddOnLoadAction(81715, () =>
					{
						if (this.Game.CurrentQuest == 57331 && this.Game.CurrentStep == 2)
						{
							DestroyFollower(4580);
							AddFollower(this.Game.GetWorld(81715), 4580);
							Open(this.Game.GetWorld(81715), 190236);
						}
					});
					ListenTeleport(102964, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57331].Steps.Add(31, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 34,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //destroy 4 demon summoners
					this.Game.AddOnLoadAction(86594, () =>
					{
						if (this.Game.CurrentQuest == 57331 && this.Game.CurrentStep == 31)
						{
							this.Game.GetWorld(86594).ShowOnlyNumNPC(3205, -1); //Leave all Asheara
							this.Game.GetWorld(86594).ShowOnlyNumNPC(4580, -1); //Leave all Leah
							this.Game.GetWorld(86594).ShowOnlyNumNPC(4580, -1); //Leave all Adria
							DestroyFollower(4580);
							AddFollower(this.Game.GetWorld(81715), 4580);
							script = new SpawnSnakemanDefenders();
							script.Execute(this.Game.GetWorld(86594));

						}
					});
					ListenKill(174866, 4, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57331].Steps.Add(34, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 7,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //hide into Caldeum drains
					this.Game.AddOnLoadAction(86594, () =>
					{
						if (this.Game.CurrentQuest == 57331 && this.Game.CurrentStep == 34)
						{
							DestroyFollower(4580);
							AddFollower(this.Game.GetWorld(81715), 4580);

							foreach (var act in this.Game.GetWorld(86594).GetActorsBySNO(159846))
								act.Destroy();//TEMP_SnakePortal_Center
						}
					});
					ListenTeleport(19791, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57331].Steps.Add(7, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
					this.Game.AddOnLoadAction(86594, () =>
					{
						if (this.Game.CurrentQuest == 57331 && this.Game.CurrentStep == 7)
						{
							DestroyFollower(4580);
							this.Game.GetWorld(50588).ShowOnlyNumNPC(4580, -1); //Leave all Leah
							this.Game.GetWorld(50588).ShowOnlyNumNPC(87496, -1); //Leave all LeahSewer
						}
					});
					this.Game.CurrentEncounter.activated = false;
				})
			});

			#endregion
			#region Unexpected Help (Rescue Adria)
			this.Game.QuestManager.Quests.Add(78264, new Quest { RewardXp = 5200, RewardGold = 530, Completed = false, Saveable = true, NextQuest = 78266, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[78264].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 9,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});

			this.Game.QuestManager.Quests[78264].Steps.Add(9, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 2,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find Cursed Pit
					if (this.Game.Empty) UnlockTeleport(1);
					ListenTeleport(58494, new Advance());
				})
			});

			this.Game.QuestManager.Quests[78264].Steps.Add(2, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 15,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill guardians
					this.Game.AddOnLoadAction(58493, () =>
					{
						if (this.Game.CurrentQuest == 78264 && this.Game.CurrentStep == 2)
						{
							StartConversation(this.Game.GetWorld(58493), 81197);
							foreach (var plr in this.Game.Players.Values)
								plr.InGameClient.SendMessage(new MessageSystem.Message.Definitions.Camera.CameraCriptedSequenceStartMessage() { Activate = true });
							foreach (var plr in this.Game.Players.Values)
								plr.InGameClient.SendMessage(new MessageSystem.Message.Definitions.Camera.CameraFocusMessage() { ActorID = (int)this.Game.GetWorld(58493).GetActorBySNO(3095).DynamicID(plr), Duration = 1f, Snap = false });
							ListenConversation(81197, new EndCutScene());
						}
					});
					ListenKill(188400, 1, new Advance());
					UnlockTeleport(1);
				})
			});

			this.Game.QuestManager.Quests[78264].Steps.Add(15, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 21,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Adria in pit
					this.Game.AddOnLoadAction(58493, () =>
					{
						AddQuestConversation(this.Game.GetWorld(58493).GetActorBySNO(3095), 81674);
						ListenConversation(81674, new Advance());
					});
				})
			});

			this.Game.QuestManager.Quests[78264].Steps.Add(21, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 8,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Adria in camp
					this.Game.CurrentEncounter.activated = false;
					if (this.Game.GetWorld(58493).GetActorBySNO(3095) != null)
						RemoveConversations(this.Game.GetWorld(58493).GetActorBySNO(3095));

					var Adria = this.Game.GetWorld(58493).ShowOnlyNumNPC(3095, 0);
					var Portal = this.Game.GetWorld(58493).GetActorBySNO(203431);
					var AltPortal = this.Game.GetWorld(58493).SpawnMonster(203431, Portal.Position);


					Adria.Move(Portal.Position, ActorSystem.Movement.MovementHelpers.GetFacingAngle(Adria, Portal)); //Only Talk Adria
					Portal.SetVisible(true);
					Portal.Hidden = false;

                    System.Threading.Tasks.Task.Delay(3000).ContinueWith(delegate
					{
						this.Game.GetWorld(58493).ShowOnlyNumNPC(3095, -1); //Only Talk Adria
						Portal.Destroy();
						AltPortal.Destroy();
					});

						AddQuestConversation(this.Game.GetWorld(161472).GetActorBySNO(3095), 58139);
					//ListenProximity(6353, new LaunchConversation(58139));
					
					ListenConversation(58139, new Advance());
				})
			});

			this.Game.QuestManager.Quests[78264].Steps.Add(8, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
					PlayCutscene(2);
					this.Game.GetWorld(70885).GetActorBySNO(162378).SetUsable(true);

				})
			});

			#endregion
			#region Horadric traitor
			this.Game.QuestManager.Quests.Add(78266, new Quest { RewardXp = 7425, RewardGold = 810, Completed = false, Saveable = true, NextQuest = 57335, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[78266].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 2,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});
			this.Game.QuestManager.Quests[78266].Steps.Add(2, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 34,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find passage to Oasis
					if (Game.DestinationEnterQuest == 78266)
						if (Game.DestinationEnterQuestStep == -1 || Game.DestinationEnterQuestStep == 2)
						{
							this.Game.AddOnLoadAction(161472, () =>
							{
								ActiveArrow(this.Game.GetWorld(161472), 178304, 70885);
							});
							this.Game.AddOnLoadAction(70885, () =>
							{
								ActiveArrow(this.Game.GetWorld(70885), 176003, 174434);
							});
						}
					
					ListenProximity(177881, new Advance());
					
					//ListenInteract(177881, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[78266].Steps.Add(34, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 31,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Emperor
					ListenProximity(62522, new Advance());
				})
			});

			this.Game.QuestManager.Quests[78266].Steps.Add(31, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 4,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find Oasis
					ListenConversation(180063, new LaunchConversation(187093));
					ListenTeleport(175367, new Advance());
					this.Game.AddOnLoadAction(174434, () =>
					{
						if (this.Game.CurrentQuest == 78266 && this.Game.CurrentStep == 31)
						{
							StartConversation(this.Game.GetWorld(174434), 180063);
						}
					});
				})
			});

			this.Game.QuestManager.Quests[78266].Steps.Add(4, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 22,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter ruins in Oasis
					ListenTeleport(61632, new Advance());
					if (this.Game.Empty) UnlockTeleport(5);
				})
			});

			this.Game.QuestManager.Quests[78266].Steps.Add(22, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 24,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find Kulle's head
					UnlockTeleport(5);
					UnlockTeleport(6);
					ListenProximity(213907, new Advance());
				})
			});

			this.Game.QuestManager.Quests[78266].Steps.Add(24, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 26,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //get Kulle's head
					ListenInteract(213907, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[78266].Steps.Add(26, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 11,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Adria in camp
					ListenProximity(6353, new LaunchConversation(123146));
					ListenConversation(123146, new Advance());
				})
			});

			this.Game.QuestManager.Quests[78266].Steps.Add(11, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
				})
			});

			#endregion
			#region Blood and Sand
			this.Game.QuestManager.Quests.Add(57335, new Quest { RewardXp = 9650, RewardGold = 1090, Completed = false, Saveable = true, NextQuest = 57337, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[57335].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 34,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(34, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 40,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter to drain in Oasis
					ListenTeleport(62752, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(40, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 52,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 }, new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //turn east lever and turn west lever and open gates to drowned passage
											   //try {(this.Game.GetWorld(59486).FindAt(83629, new Vector3D{X = 175.1f, Y = 62.275f, Z = 50.17f}, 20.0f) as Door).Open();} catch {}
					this.Game.AddOnLoadAction(59486, () =>
					{
						(this.Game.GetWorld(59486).FindAt(83629, new Vector3D { X = 175.1f, Y = 62.275f, Z = 50.17f }, 20.0f) as Door).Open();
					});
					ListenInteract(76931, 1, new CompleteObjective(0));
					ListenInteract(83295, 1, new Advance());
					StartConversation(this.Game.GetWorld(59486), 186905);
					//ListenInteract(83295, 1, new CompleteObjective(2));
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(52, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 54,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter to drowned passage
					this.Game.AddOnLoadAction(59486, () =>
					{
						Open(this.Game.GetWorld(59486), 83629);
						Open(this.Game.GetWorld(59486), 131364);
						Open(this.Game.GetWorld(59486), 159419);
						(this.Game.GetWorld(59486).FindAt(83629, new Vector3D { X = 80.5f, Y = 155.631f, Z = 50.33f }, 20.0f) as Door).Open();
					});
					//try {(this.Game.GetWorld(59486).FindAt(83629, new Vector3D{X = 80.5f, Y = 155.631f, Z = 50.33f}, 20.0f) as Door).Open();} catch {}
					ListenTeleport(192694, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(54, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 56,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill Deceiveds
					this.Game.AddOnLoadAction(192687, () =>
					{
						setActorOperable(this.Game.GetWorld(192687), 168235, false);
						this.Game.GetWorld(192687).SpawnMonster(4104, new Vector3D { X = 75.209f, Y = 191.342f, Z = -1.5f });
						this.Game.GetWorld(192687).SpawnMonster(4104, new Vector3D { X = 44.703f, Y = 179.753f, Z = -1.56f });
						this.Game.GetWorld(192687).SpawnMonster(4104, new Vector3D { X = 43.304f, Y = 205.28f, Z = -0.34f });
					});
					ListenKill(4104, 3, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(56, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 58,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //break talking barrel
					this.Game.AddOnLoadAction(192687, () =>
					{
						setActorOperable(this.Game.GetWorld(192687), 168235, true);
					});
					ListenInteract(168235, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(58, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 60,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with jeweler
					this.Game.AddOnLoadAction(192687, () =>
					{
						this.Game.GetWorld(192687).SpawnMonster(61544, this.Game.GetWorld(192687).GetActorBySNO(168235, true).Position);
					});
					ListenProximity(61544, new LaunchConversation(168948));
					ListenConversation(168948, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(60, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 62,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find crucible
					this.Game.AddOnLoadAction(192687, () =>
					{
						if (this.Game.CurrentQuest == 57335 && this.Game.CurrentStep == 60)
						{
							AddFollower(this.Game.GetWorld(192687), 61544);
						}
					});
					ListenProximity(168240, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(62, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 64,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill Gevin
					this.Game.AddOnLoadAction(192687, () =>
					{
						if (this.Game.CurrentQuest == 57335 && this.Game.CurrentStep == 62)
						{
							DestroyFollower(61544);
							AddFollower(this.Game.GetWorld(192687), 61544);
						}
					});
					bool Killed = true;
					foreach (var act in this.Game.GetWorld(192687).Actors.Values)
						if (act.ActorSNO.Id == 168240)
							Killed = false;
					if (!Killed)
						ListenKill(168240, 1, new Advance());
					else
					{
						script = new Advance();
						script.Execute(this.Game.GetWorld(192687));
					}

				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(64, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 44,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //get crucible
					this.Game.AddOnLoadAction(192687, () =>
					{
						if (this.Game.CurrentQuest == 57335 && this.Game.CurrentStep == 64)
						{
							DestroyFollower(61544);
							AddFollower(this.Game.GetWorld(192687), 61544);
						}
					});
					ListenInteract(213514, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(44, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 24,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter the ancient passage
					this.Game.AddOnLoadAction(192687, () =>
					{
						if (this.Game.CurrentQuest == 57335 && this.Game.CurrentStep == 44)
						{
							DestroyFollower(61544);
							AddFollower(this.Game.GetWorld(192687), 61544);
						}
					});
					ListenTeleport(175330, new Advance());
					if (!this.Game.Empty)
						foreach (var plr in this.Game.Players.Values)
						{
							if (!plr.JewelerUnlocked)
							{
								plr.JewelerUnlocked = true;
								plr.GrantAchievement(74987243307780);
								//plr.UpdateAchievementCounter(403, 1, 1);
								plr.LoadCrafterData();
							}
						}
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(24, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 8,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 }, new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find blood in 2 caves
					if (this.Game.Empty) UnlockTeleport(7);
					DestroyFollower(61544);
					ListenInteract(213820, 1, new CompleteObjective(0));
					ListenInteract(213859, 1, new CompleteObjective(1));
				})
			});

			this.Game.QuestManager.Quests[57335].Steps.Add(8, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
					PlayCutscene(3);
				})
			});

			#endregion
			#region Black Soulstone
			this.Game.QuestManager.Quests.Add(57337, new Quest { RewardXp = 14515, RewardGold = 1675, Completed = false, Saveable = true, NextQuest = 121792, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[57337].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 25,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(25, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 39,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter the Kulle's archives				
					UnlockTeleport(7);
					UnlockTeleport(8);
					ListenTeleport(19800, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(39, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 35,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter the Limit
					ListenProximity(220114, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(35, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 41,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 }, new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //open Abyss lock and open Stormhalls lock
					if (this.Game.Empty) UnlockTeleport(9);
					this.Game.AddOnLoadAction(50613, () =>
					{
						if (this.Game.CurrentQuest == 57337 && this.Game.CurrentStep == 35)
						{
							StartConversation(this.Game.GetWorld(50613), 187015);
						}
					});
					this.Game.AddOnLoadAction(50610, () =>
					{
						(this.Game.GetWorld(50610).GetActorBySNO(74187) as Spawner).Spawn();
					});
					this.Game.AddOnLoadAction(50611, () =>
					{
						(this.Game.GetWorld(50611).GetActorBySNO(74187) as Spawner).Spawn();
					});
					ListenInteract(2975, 2, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(41, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 0,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter the shadows world
					this.Game.AddOnLoadAction(50613, () =>
					{
						Open(this.Game.GetWorld(50613), 205701);
					});
					UnlockTeleport(9);
					ListenTeleport(80592, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(0, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 3,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find Kulle's body
					ListenInteract(119685, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(3, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 26,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Leah
					ListenProximity(4580, new LaunchConversation(62505));
					foreach (var act in this.Game.GetWorld(50613).GetActorsBySNO(168333))
						act.Destroy();
					ListenConversation(62505, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(26, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 27,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter the soulstone storage
					ListenTeleport(60194, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(27, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 4,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Kulle
					this.Game.AddOnLoadAction(60193, () =>
					{
						if (this.Game.CurrentQuest == 57337 && this.Game.CurrentStep == 27)
						{
							StartConversation(this.Game.GetWorld(60193), 202697);
						}
					});
					ListenConversation(202697, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(4, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 31,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill Kulle
					ListenKill(80509, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(31, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 33,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //get Soulstone
					this.Game.AddOnLoadAction(60193, () =>
					{
						Open(this.Game.GetWorld(60193), 165415);
					});
					ListenInteract(156328, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(33, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 6,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Adria in camp
					ListenProximity(3095, new LaunchConversation(80513));
					ListenConversation(80513, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57337].Steps.Add(6, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
				})
			});

			#endregion
			#region Rush in Caldeum
			this.Game.QuestManager.Quests.Add(121792, new Quest { RewardXp = 0, RewardGold = 0, Completed = false, Saveable = true, NextQuest = 57339, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[121792].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 34,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});

			this.Game.QuestManager.Quests[121792].Steps.Add(34, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 23,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //find Asheara
					this.Game.AddOnLoadAction(70885, () =>
					{
						this.Game.GetWorld(70885).ShowOnlyNumNPC(3205, 1);
						script = new Advance();
						script.Execute(this.Game.GetWorld(70885));
					});
					//ListenProximity(3205, new Advance());
				})
			});

			this.Game.QuestManager.Quests[121792].Steps.Add(23, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 21,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Asheara
					foreach (var Ashe in this.Game.GetWorld(70885).GetActorsBySNO(3205))
						AddQuestConversation(Ashe, 121359);
					ListenConversation(121359, new Advance());
				})
			});

			this.Game.QuestManager.Quests[121792].Steps.Add(21, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 3,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //todo: timed event 115494
					try { (this.Game.GetWorld(70885).FindAt(169502, new Vector3D { X = 3135.3f, Y = 1546.1f, Z = 250.545f }, 15.0f) as Door).Open(); } catch { }
					foreach (var Ashe in this.Game.GetWorld(70885).GetActorsBySNO(3205))
						RemoveConversations(Ashe);
					StartConversation(this.Game.GetWorld(70885), 178852);
					ListenConversation(178852, new RefugeesRescue());
					//ListenProximity(162378, new RefugeesRescue());
				})
			});

			this.Game.QuestManager.Quests[121792].Steps.Add(3, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
				})
			});

			#endregion
			#region Lord of Lies
			this.Game.QuestManager.Quests.Add(57339, new Quest { RewardXp = 10850, RewardGold = 1160, Completed = false, Saveable = true, NextQuest = -1, Steps = new Dictionary<int, QuestStep> { } });

			this.Game.QuestManager.Quests[57339].Steps.Add(-1, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 10,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => {
				})
			});

			this.Game.QuestManager.Quests[57339].Steps.Add(10, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 12,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //enter the Caldeum palace
					AddFollower(this.Game.GetWorld(81715), 4580);
					AddFollower(this.Game.GetWorld(161472), 3095);
					ListenTeleport(210451, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57339].Steps.Add(12, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 29,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //go to emperor's palace
					foreach (var door in this.Game.GetWorld(109894).GetActorsBySNO(190844))
						door.Destroy();
					foreach (var guard in this.Game.GetWorld(109894).GetActorsBySNO(57470))
						guard.Destroy();
					DestroyFollower(4580);
					DestroyFollower(3095);
					AddFollower(this.Game.GetWorld(81715), 4580);
					AddFollower(this.Game.GetWorld(161472), 3095);
					this.Game.AddOnLoadAction(109894, () =>
					{
						script = new SpawnBelialDefenders();
						script.Execute(this.Game.GetWorld(109894));
						Open(this.Game.GetWorld(109894), 180254);
					});
					ListenTeleport(60757, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57339].Steps.Add(29, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 13,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //kill Belial
					DestroyFollower(4580);
					DestroyFollower(3095);
					this.Game.AddOnLoadAction(60756, () =>
					{
						setActorOperable(this.Game.GetWorld(60756), 169025, false);
						setActorOperable(this.Game.GetWorld(60756), 190236, false);
						setActorVisible(this.Game.GetWorld(60756), 191922, false);
						//stage 1
						if (this.Game.CurrentQuest == 57339 && this.Game.CurrentStep == 29)
						{
							DisableEveryone(this.Game.GetWorld(60756), true);
							foreach (var Adr in this.Game.GetWorld(60756).GetActorsBySNO(3095))
								(Adr as Minion).Brain.DeActivate();
							foreach (var Adr in this.Game.GetWorld(60756).GetActorsBySNO(4580))
								(Adr as TownLeah).Brain.DeActivate();
							//Старт катсцены
							System.Threading.Tasks.Task.Run(() => 
							{
								while (true)
									if (this.Game.Players.First().Value.World.WorldSNO.Id == 60756)
										break;

								while (true)
									if (this.Game.GetWorld(60756).GetActorBySNO(59447).IsRevealedToPlayer(this.Game.Players.First().Value))
										break;

								foreach (var plr in this.Game.Players.Values)
									plr.InGameClient.SendMessage(new MessageSystem.Message.Definitions.Camera.CameraCriptedSequenceStartMessage() { Activate = true });

								foreach (var plr in this.Game.Players.Values)
									plr.InGameClient.SendMessage(new MessageSystem.Message.Definitions.Camera.CameraFocusMessage() { ActorID = (int)this.Game.GetWorld(60756).GetActorBySNO(59447).DynamicID(plr), Duration = 1f, Snap = false });
								StartConversation(this.Game.GetWorld(60756), 61130);
							});
							
						}
					});
					ListenConversation(61130, new BelialStageOne());

					//stage 2
					ListenKill(60816, 4, new LaunchConversationWithCutScene(68408, 62975));
					ListenConversation(68408, new BelialStageTwo());

					//stage 3
					ListenKill(62975, 1, new LaunchConversationWithCutScene(62229, 62975));
					ListenConversation(62229, new BelialStageThree());
					ListenKill(3349, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57339].Steps.Add(13, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 27,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //get Belial's soul
					this.Game.CurrentEncounter.activated = false;
					this.Game.AddOnLoadAction(60756, () =>
					{
						(this.Game.GetWorld(60756).GetActorBySNO(169025) as BelialRoom).Rebuild();
					});
					//this.Game.GetWorld(60756).SpawnMonster(206391, this.Game.GetWorld(60756).GetStartingPointById(108).Position);
					ListenInteract(206391, 1, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57339].Steps.Add(27, new QuestStep
			{
				Completed = false,
				Saveable = false,
				NextStep = 14,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with Tyrael in camp
					this.Game.AddOnLoadAction(60756, () =>
					{
						setActorOperable(this.Game.GetWorld(60756), 190236, true);
						this.Game.GetWorld(60756).GetActorBySNO(206391, true).Destroy();
					});
					ListenProximity(146980, new LaunchConversation(80329));
					ListenConversation(80329, new Advance());
				})
			});

			this.Game.QuestManager.Quests[57339].Steps.Add(14, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = 3,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //talk with caravan leader
					ListenInteract(177544, 1, new LaunchConversation(177669));
					ListenConversation(177669, new ChangeAct(200));
					this.Game.GetWorld(161472).GetActorBySNO(177544, true).NotifyConversation(1);
				})
			});

			this.Game.QuestManager.Quests[57339].Steps.Add(3, new QuestStep
			{
				Completed = false,
				Saveable = true,
				NextStep = -1,
				Objectives = new List<Objective> { new Objective { Limit = 1, Counter = 0 } },
				OnAdvance = new Action(() => { //complete
				})
			});

			#endregion
		}

		public static void AddQuestConversation(Actor actor, int conversation)
		{
			var NPC = actor as InteractiveNPC;
			if (NPC != null)
			{ 
				NPC.Conversations.Clear();
				NPC.Conversations.Add(new ActorSystem.Interactions.ConversationInteraction(conversation));
				NPC.Attributes[GameAttribute.Conversation_Icon, 0] = 2;
				NPC.Attributes.BroadcastChangedIfRevealed(); 

			}
			else if (actor != null)
			{
				foreach (var N in actor.World.GetActorsBySNO(actor.ActorSNO.Id))
					if (N is InteractiveNPC)
					{
						NPC = N as InteractiveNPC;
						NPC.Conversations.Clear();
						NPC.Conversations.Add(new ActorSystem.Interactions.ConversationInteraction(conversation));
						NPC.Attributes[GameAttribute.Conversation_Icon, 0] = 2;
						NPC.Attributes.BroadcastChangedIfRevealed();
					} 
			}
			else
				Logger.Warn("Не удалось присвоить диалог для NPC.");
		}

		public static void RemoveConversations(Actor actor)
		{
			var NPC = actor as InteractiveNPC;
			if (NPC != null)
			{
				NPC.Conversations.Clear();
				NPC.Attributes[GameAttribute.Conversation_Icon, 0] = 1;
				NPC.Attributes.BroadcastChangedIfRevealed();
			}
		}

		public static void DisableEveryone(MapSystem.World world, bool disabled)
		{
			foreach (var actor in world.Actors.Values.Where(a => a is Monster || a is Player || a is Minion || a is Hireling))
			{
				actor.Disable = disabled;
			}
		}
	}
}