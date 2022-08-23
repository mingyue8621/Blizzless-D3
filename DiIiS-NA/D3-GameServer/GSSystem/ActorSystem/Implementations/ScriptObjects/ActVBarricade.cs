﻿//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.TagMap;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.MapSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.PlayerSystem;
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
	[HandledSNO(316567)]
	public class ActVBarricade : Gizmo
	{
		public ActVBarricade(World world, int snoId, TagMap tags)
			: base(world, snoId, tags)
		{
		}

		public override bool Reveal(Player player)
		{
			if (this.World.WorldSNO.Id == 304235) return false;
			return base.Reveal(player);
		}
	}
}
