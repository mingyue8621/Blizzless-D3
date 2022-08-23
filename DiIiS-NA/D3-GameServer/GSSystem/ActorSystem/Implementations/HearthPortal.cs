﻿//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.Math;
//Blizzless Project 2022 
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

namespace DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations
{
	class HearthPortal : Gizmo
	{
		public int ReturnWorld = -1;

		public Vector3D ReturnPosition = null;

		public Player Owner = null;

		public HearthPortal(World world, int snoId, TagMap tags)
			: base(world, snoId, tags)
		{
			this.Attributes[GameAttribute.MinimapActive] = true;
			this.SetVisible(false);
		}

		public override void OnTargeted(Player player, TargetMessage message)
		{
			Logger.Trace("(OnTargeted) HearthPortal has been activated ");

			var world = this.World.Game.GetWorld(this.ReturnWorld);

			if (world == null)
			{
				Logger.Warn("HearthPortal's world does not exist (WorldSNO = {0})", this.ReturnWorld);
				return;
			}

			if (this.World.Game.QuestManager.SideQuests.ContainsKey(120396) && this.World.Game.QuestManager.SideQuests[120396].Completed && this.ReturnWorld == 50596) return;

			Vector3D exCheckpoint = player.CheckPointPosition;

			if (world == this.World)
				player.Teleport(ReturnPosition);
			else
				player.ChangeWorld(world, ReturnPosition);

			player.CheckPointPosition = exCheckpoint;
			this.SetVisible(false);
		}

		public override bool Reveal(Player player)
		{
			if (player != this.Owner) return false;
			return base.Reveal(player);
		}
	}
}
