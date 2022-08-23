﻿//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.Math;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.GSSystem.ActorSystem.Implementations.ScriptObjects;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Base;

namespace DiIiS_NA.GameServer.GSSystem.QuestSystem.QuestEvents.Implementations
{
	class BelialStageThree : QuestEvent
	{

		public BelialStageThree()
			: base(0)
		{
		}

		public override void Execute(MapSystem.World world)
		{
			foreach (var plr in world.Players.Values)
			{
				plr.InGameClient.SendMessage(new BoolDataMessage(Opcodes.CameraTriggerFadeToBlackMessage) { Field0 = true });
				plr.InGameClient.SendMessage(new SimpleMessage(Opcodes.CameraSriptedSequenceStopMessage) { });
				break;
			}
			foreach (var m in world.GetActorsBySNO(62975))
				m.Destroy();

			(world.GetActorBySNO(169025) as BelialRoom).Break();
			world.SpawnMonster(3349, new Vector3D { X = 780.8f, Y = 786.68f, Z = 5.1f });
			/*
			foreach (var plr in world.Players.Values)
				plr.InGameClient.SendMessage(new MessageSystem.Message.Definitions.Player.PlayerSetCameraObserverMessage()
				{
					Field0 = 95468,
					Field1 = new MessageSystem.Message.Fields.WorldPlace() { Position = new Vector3D(), WorldID = 0 }
				});
			//*/
		}

	}
}
