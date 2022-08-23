﻿//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.TagMap;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.MapSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.PlayerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Misc;
//Blizzless Project 2022 
using System;
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using System.Linq;
//Blizzless Project 2022 
using System.Text;
//Blizzless Project 2022 
using System.Threading.Tasks;

namespace DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations.Artisans
{
	[HandledSNO(56947 /* PT_Blacksmith.acr */)]
	public class Blacksmith : Artisan
	{
		public Blacksmith(World world, int snoId, TagMap tags)
			: base(world, snoId, tags)
		{
			// TODO add all blacksmith functionality? /fasbat
			//this.Attributes[GameAttribute.TeamID] = 0;
			//this.Attributes[GameAttribute.MinimapIconOverride] = 102320;
		}

		public override void OnCraft(Player player)
		{
			player.InGameClient.SendMessage(new ANNDataMessage(Opcodes.OpenArtisanWindowMessage) { ActorID = this.DynamicID(player) });
			player.ArtisanInteraction = "Blacksmith";
		}

		public override bool Reveal(Player player)
		{
			if (!player.BlacksmithUnlocked && player.InGameClient.Game.CurrentAct != 3000)
				return false;

			return base.Reveal(player);
		}
	}
}
