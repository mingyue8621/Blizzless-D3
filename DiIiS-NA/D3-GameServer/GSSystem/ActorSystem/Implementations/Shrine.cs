﻿//Blizzless Project 2022 
using System;
//Blizzless Project 2022 
using System.Linq;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.MapSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.TagMap;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.PlayerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.World;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.TickerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Misc;

namespace DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations
{
	class Shrine : Gizmo
	{
		public Shrine(World world, int snoId, TagMap tags)
			: base(world, snoId, tags)
		{
			Attributes[GameAttribute.MinimapActive] = true;
		}

		private bool Activated = false;
		private object taskLock = new object();

		public override void OnTargeted(Player player, TargetMessage message)
		{
			lock (this.taskLock)
			{
				if (this.Activated) return;
				this.Activated = true;
				World.BroadcastIfRevealed(plr => new ANNDataMessage(Opcodes.ShrineActivatedMessage) { ActorID = this.DynamicID(plr) }, this);
				switch (this.ActorSNO.Id)
				{
					case 176074: //blessed
						foreach (var plr in this.GetPlayersInRange(100f))
						{
							this.World.BuffManager.AddBuff(this, plr, new PowerSystem.Implementations.ShrineBlessedBuff(TickTimer.WaitSeconds(this.World.Game, 120.0f)));
							plr.GrantCriteria(74987243307423);
						}
						break;
					case 176075: //enlightened
						foreach (var plr in this.GetPlayersInRange(100f))
						{
							this.World.BuffManager.AddBuff(this, plr, new PowerSystem.Implementations.ShrineEnlightenedBuff(TickTimer.WaitSeconds(this.World.Game, 120.0f)));
							plr.GrantCriteria(74987243307424);
						}
						break;
					case 176076: //fortune
						foreach (var plr in this.GetPlayersInRange(100f))
						{
							this.World.BuffManager.AddBuff(this, plr, new PowerSystem.Implementations.ShrineFortuneBuff(TickTimer.WaitSeconds(this.World.Game, 120.0f)));
							plr.GrantCriteria(74987243307425);
						}
						break;
					case 176077: //frenzied
						foreach (var plr in this.GetPlayersInRange(100f))
						{
							this.World.BuffManager.AddBuff(this, plr, new PowerSystem.Implementations.ShrineFrenziedBuff(TickTimer.WaitSeconds(this.World.Game, 120.0f)));
							plr.GrantCriteria(74987243307426);
						}
						break;
					default:
						foreach (var plr in this.GetPlayersInRange(100f))
						{
							this.World.BuffManager.AddBuff(this, plr, new PowerSystem.Implementations.ShrineEnlightenedBuff(TickTimer.WaitSeconds(this.World.Game, 120.0f)));
						}
						break;
				}

				this.Attributes[GameAttribute.Gizmo_Has_Been_Operated] = true;
				//this.Attributes[GameAttribute.Gizmo_Operator_ACDID] = unchecked((int)player.DynamicID);
				this.Attributes[GameAttribute.Gizmo_State] = 1;
				Attributes.BroadcastChangedIfRevealed();
			}
		}
	}
}
