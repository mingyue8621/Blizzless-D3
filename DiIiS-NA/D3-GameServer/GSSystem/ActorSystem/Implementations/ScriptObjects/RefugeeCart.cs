﻿//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.TagMap;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.MapSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.PlayerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.World;
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

namespace DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations.ScriptObjects
{
	[HandledSNO(163800)]
	public class RefugeeCart : Gizmo
	{
		public RefugeeCart(World world, int snoId, TagMap tags)
			: base(world, snoId, tags)
		{
			//this.Attributes[GameAttribute.MinimapActive] = true;
		}


		public override bool Reveal(Player player)
		{
			if (!base.Reveal(player))
				return false;

			return true;
		}

		public override bool Unreveal(Player player)
		{
			if (!base.Unreveal(player))
				return false;

			return true;
		}

		public override void OnTargeted(Player player, TargetMessage message)
		{
			if (this.World.Game.CurrentQuest == 121792 && this.World.Game.CurrentStep == 21)
			{
				base.OnTargeted(player, message);
				player.AddFollower(this.World.GetActorBySNO(201583));
				this.Attributes[GameAttribute.Gizmo_Has_Been_Operated] = true;
				this.Attributes[GameAttribute.Disabled] = true;
				Attributes.BroadcastChangedIfRevealed();
			}
		}
	}
}
