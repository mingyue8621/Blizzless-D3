﻿//Blizzless Project 2022 
using DiIiS_NA.Core.Logging;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.ActorSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations.Hirelings;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.GameSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.PlayerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
//Blizzless Project 2022 
using System.Linq;
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
using DiIiS_NA.Core.Helpers.Math;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.TagMap;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Animation;

namespace DiIiS_NA.GameServer.GSSystem.QuestSystem.QuestEvents.Implementations
{
	class CellarZombies : QuestEvent
	{
		//ActorID: 0x7A3100DD  
		//ZombieSkinny_A_LeahInn.acr (2050031837)
		//ActorSNOId: 0x00031971:ZombieSkinny_A_LeahInn.acr

		//private static readonly Logger Logger = LogManager.CreateLogger();

		public CellarZombies()
			: base(151123)
		{
		}

		public override void Execute(MapSystem.World world)
		{
			if (world.Game.Empty) return;

			List<ActorSystem.Actor> actorstotarget = new List<ActorSystem.Actor> { };

			var spawner = world.GetActorBySNO(204605);
			while (spawner != null)
			{
				actorstotarget.Add(world.SpawnMonster(203121, spawner.Position));
				spawner.Destroy();
				spawner = world.GetActorBySNO(204605);
			}

			spawner = world.GetActorBySNO(204606);
			while (spawner != null)
			{
				actorstotarget.Add(world.SpawnMonster(203121, spawner.Position));
				spawner.Destroy();
				spawner = world.GetActorBySNO(204606);
			}

			spawner = world.GetActorBySNO(204607);
			while (spawner != null)
			{
				actorstotarget.Add(world.SpawnMonster(203121, spawner.Position));
				spawner.Destroy();
				spawner = world.GetActorBySNO(204607);
			}

			spawner = world.GetActorBySNO(204608);
			while (spawner != null)
			{
				actorstotarget.Add(world.SpawnMonster(203121, spawner.Position));
				spawner.Destroy();
				spawner = world.GetActorBySNO(204608);
			}

			spawner = world.GetActorBySNO(204615);
			while (spawner != null)
			{
				actorstotarget.Add(world.SpawnMonster(203121, spawner.Position));
				spawner.Destroy();
				spawner = world.GetActorBySNO(204615);
			}

			spawner = world.GetActorBySNO(204616);
			while (spawner != null)
			{
				actorstotarget.Add(world.SpawnMonster(203121, spawner.Position));
				spawner.Destroy();
				spawner = world.GetActorBySNO(204616);
			}

			spawner = world.GetActorBySNO(174023);
			while (spawner != null)
			{
				actorstotarget.Add(world.SpawnMonster(203121, spawner.Position));
				spawner.Destroy();
				spawner = world.GetActorBySNO(174023);
			}

			foreach (var actor in actorstotarget)
			{
				actor.Attributes[GameAttribute.Quest_Monster] = true;
				actor.Attributes.BroadcastChangedIfRevealed();
			}
			StartConversation(world, 131339);
		}

		private bool StartConversation(MapSystem.World world, Int32 conversationId)
		{
			foreach (var player in world.Players)
			{
				player.Value.Conversations.StartConversation(conversationId);
			}
			return true;
		}
	}
}
