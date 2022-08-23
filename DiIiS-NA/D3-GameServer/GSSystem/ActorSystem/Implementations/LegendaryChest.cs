﻿//Blizzless Project 2022 
using System;
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using System.Linq;
//Blizzless Project 2022 
using DiIiS_NA.Core.Helpers.Math;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.TagMap;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.ItemsSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.MapSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.PlayerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Animation;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Base;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Quest;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Text;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.World;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Fields;

namespace DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations
{
	[HandledSNO(96993)]
	class LegendaryChest : LootContainer
	{
		public bool ChestActive = false;

		public LegendaryChest(World world, int snoId, TagMap tags)
			: base(world, snoId, tags)
		{
			this.NameSNOId = 108122;
			this.Field7 = 1;
		}

		public override bool Reveal(PlayerSystem.Player player)
		{
			if (!this.ChestActive) return false;
			return base.Reveal(player);
		}


		public override void OnTargeted(PlayerSystem.Player player, TargetMessage message)
		{
			if (this.Attributes[GameAttribute.Disabled]) return;

			int chance = this.World.Game.IsHardcore ? 99 : 25; //S4 special
			/*
			if (!player.Inventory.HasItem(-110888638) || (!this.World.Game.IsHardcore && !player.Inventory.HasGold(250000)))
			{
				player.InGameClient.SendMessage(new BroadcastTextMessage() { Field0 = string.Format("You don't have a Chain Key {0}to open that chest!", (this.World.Game.IsHardcore ? "" : "and/or 250k gold ")) });
				return;
			}
			else
			//*/
			{
				//player.InGameClient.SendMessage(new BroadcastTextMessage() { Field0 = string.Format("Legendary Chest has been opened. 1 Chain Key {0}consumed.", (this.World.Game.IsHardcore ? "" : "and 250k gold ")) });

				player.Inventory.GetBag().GrabSomeItems(-110888638, 1);
				if (!this.World.Game.IsHardcore)
					player.Inventory.RemoveGoldAmount(250000);
				if (FastRandom.Instance.Next(100) < chance)
					this.World.SpawnRandomEquip(player, player, LootManager.Epic, player.Level);
				else
					this.World.SpawnRandomEquip(player, player, LootManager.Rare, player.Level);

				var toon = player.Toon.DBToon;
				toon.ChestsOpened++;
				this.World.Game.GameDBSession.SessionUpdate(toon);
			}

			base.OnTargeted(player, message);
		}
	}
}
