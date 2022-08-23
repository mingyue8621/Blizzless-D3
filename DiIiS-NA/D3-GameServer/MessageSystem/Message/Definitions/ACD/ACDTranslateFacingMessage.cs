﻿//Blizzless Project 2022 
using System;
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using System.Linq;
//Blizzless Project 2022 
using System.Text;
//Blizzless Project 2022 
using System.Threading.Tasks;

namespace DiIiS_NA.GameServer.MessageSystem.Message.Definitions.ACD
{
    [Message(new[] { Opcodes.ACDTranslateFacingMessage })]
    public class ACDTranslateFacingMessage : GameMessage
    {
        /// <summary>
        /// Id of the player actor
        /// </summary>
        public uint ActorId;

        /// <summary>
        /// Angle between actor X axis and world X axis in radians
        /// </summary>
        public float Angle;

        /// <summary>
        /// Sets whether the player turned immediatly or smoothly
        /// </summary>
        public bool TurnImmediately;

        public ACDTranslateFacingMessage() : base(Opcodes.ACDTranslateFacingMessage) { }

        public override void Parse(GameBitBuffer buffer)
        {
            ActorId = buffer.ReadUInt(32);
            Angle = buffer.ReadFloat32();
            TurnImmediately = buffer.ReadBool();
        }

        public override void Encode(GameBitBuffer buffer)
        {
            buffer.WriteUInt(32, ActorId);
            buffer.WriteFloat32(Angle);
            buffer.WriteBool(TurnImmediately);
        }

        public override void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("ACDTranslateFacingMessage:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad); b.AppendLine("ActorID: 0x" + ActorId.ToString("X8"));
            b.Append(' ', pad); b.AppendLine("Angle: " + Angle.ToString("G"));
            b.Append(' ', pad); b.AppendLine("Immediately: " + (TurnImmediately ? "true" : "false"));
            b.Append(' ', --pad);
            b.AppendLine("}");
        }

    }
}
