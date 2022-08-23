﻿//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.TickerSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
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

namespace DiIiS_NA.GameServer.GSSystem.PowerSystem.Implementations
{
	[ImplementsPowerSNO(30476)]
	[ImplementsPowerBuff(0)]
	public class ShrineBlessedBuff : PowerBuff
	{
		public ShrineBlessedBuff(TickTimer timeout)
		{
			//-25% incoming damage
			Timeout = timeout;
		}
	}

	[ImplementsPowerSNO(30477)]
	[ImplementsPowerBuff(0)]
	public class ShrineEnlightenedBuff : PowerBuff
	{
		public ShrineEnlightenedBuff(TickTimer timeout)
		{
			//+25% exp
			Timeout = timeout;
		}

		public override bool Apply()
		{
			if (!base.Apply())
				return false;
			Target.Attributes[GameAttribute.Experience_Bonus_Percent] += 0.25f;
			Target.Attributes.BroadcastChangedIfRevealed();
			return true;
		}

		public override void Remove()
		{
			base.Remove();
			Target.Attributes[GameAttribute.Experience_Bonus_Percent] -= 0.25f;
			Target.Attributes.BroadcastChangedIfRevealed();
		}
	}

	[ImplementsPowerSNO(30478)]
	[ImplementsPowerBuff(0)]
	public class ShrineFortuneBuff : PowerBuff
	{
		public ShrineFortuneBuff(TickTimer timeout)
		{
			//+25% magic & gold find
			Timeout = timeout;
		}
	}

	[ImplementsPowerSNO(30479)]
	[ImplementsPowerBuff(0)]
	public class ShrineFrenziedBuff : PowerBuff
	{
		public ShrineFrenziedBuff(TickTimer timeout)
		{
			Timeout = timeout;
		}
	}
}
