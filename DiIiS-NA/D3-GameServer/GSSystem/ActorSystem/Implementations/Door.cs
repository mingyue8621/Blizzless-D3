﻿//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.TagMap;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.MapSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.PlayerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.ACD;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Animation;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.World;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Fields;
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
	[HandledSNO(175810)]
	class Door : Gizmo
	{
		public bool isOpened = false;
		public Portal NearestPortal = null;
		public Door(World world, int snoId, TagMap tags)
			: base(world, snoId, tags)
		{
			var Portals = GetObjectsInRange<Portal>(10f);
			if (Portals.Count > 0)
				NearestPortal = Portals[0];
			if (NearestPortal != null)
			{
				NearestPortal.SetVisible(false);
				foreach (var plr in this.World.Players.Values)
					NearestPortal.Unreveal(plr);
			}
		}

		public override bool Reveal(Player player)
		{
			if (this.ActorSNO.Id == 167185) return false;
			if (this.ActorSNO.Id == 207615 && this.World.WorldSNO.Id != 158593) return false; //dakab door
			if (this.ActorSNO.Id == 153836 && this.World.WorldSNO.Id == 158593) return false; //not dakab door

			if (this.ActorSNO.Id == 220337) //Treasure Room door
				this.isOpened = true;

			if (this.ActorSNO.Id == 178161 && (float)DiIiS_NA.Core.Helpers.Math.FastRandom.Instance.NextDouble() < 0.3f) //Mysterious Cave door
				this.isOpened = true;

			if (!base.Reveal(player))
				return false;

			if (this.isOpened == true)
			{
				player.InGameClient.SendMessage(new SetIdleAnimationMessage
				{
					ActorID = this.DynamicID(player),
					AnimationSNO = AnimationSetKeys.Open.ID
				});
			}

			if (NearestPortal == null)
			{
				var Portals = GetObjectsInRange<Portal>(10f);
				if (Portals.Count > 0)
					NearestPortal = Portals[0];
				if (NearestPortal != null)
				{
					NearestPortal.SetVisible(false);
					foreach (var plr in this.World.Players.Values)
						NearestPortal.Unreveal(plr);
				}
			}
			return true;
		}

		public void Open()
		{
			World.BroadcastIfRevealed(plr => new PlayAnimationMessage
			{
				ActorID = this.DynamicID(plr),
				AnimReason = 5,
				UnitAniimStartTime = 0,
				tAnim = new PlayAnimationMessageSpec[]
				{
					new PlayAnimationMessageSpec()
					{
						Duration = 500,
						AnimationSNO = AnimationSet.TagMapAnimDefault[AnimationSetKeys.Opening],
						PermutationIndex = 0,
						AnimationTag = 0,
						Speed = 1
					}
				}

			}, this);

			World.BroadcastIfRevealed(plr => new ACDCollFlagsMessage
			{
				ActorID = DynamicID(plr),
				CollFlags = 0
			}, this);

			World.BroadcastIfRevealed(plr => new SetIdleAnimationMessage
			{
				ActorID = this.DynamicID(plr),
				AnimationSNO = AnimationSetKeys.Open.ID
			}, this);

			this.Attributes[GameAttribute.Gizmo_Has_Been_Operated] = true;
			//this.Attributes[GameAttribute.Gizmo_Operator_ACDID] = unchecked((int)player.DynamicID);
			this.Attributes[GameAttribute.Gizmo_State] = 1;
			this.CollFlags = 0;
			this.isOpened = true;

			TickerSystem.TickTimer Timeout = new TickerSystem.SecondsTickTimer(this.World.Game, 1.8f);
			if (NearestPortal != null)
			{
				var Boom = System.Threading.Tasks.Task<bool>.Factory.StartNew(() => WaitToSpawn(Timeout));
				Boom.ContinueWith(delegate
				{
					NearestPortal.SetVisible(true);
					foreach (var plr in this.World.Players.Values)
						NearestPortal.Unreveal(plr);
				});
			}

			Attributes.BroadcastChangedIfRevealed();
		}

		public override void OnTargeted(Player player, TargetMessage message)
		{
			if (this.Attributes[GameAttribute.Disabled]) return;
			this.Open();
            
			base.OnTargeted(player, message);
			this.Attributes[GameAttribute.Disabled] = true;
		}

		private bool WaitToSpawn(TickerSystem.TickTimer timer)
		{
			while (timer.TimedOut != true)
			{

			}
			return true;
		}
	}

	//175810

}
