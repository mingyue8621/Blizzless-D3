﻿//Blizzless Project 2022
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using CrystalMpq;
//Blizzless Project 2022 
using Gibbed.IO;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.Core.Types.SNO;
//Blizzless Project 2022 
using DiIiS_NA.Core.MPQ.FileFormats.Types;
//Blizzless Project 2022 
using DiIiS_NA.Core.Storage;

namespace DiIiS_NA.Core.MPQ.FileFormats
{
    [FileFormat(SNOGroup.ConversationList)]
    public class ConversationList : FileFormat
    {
        [PersistentProperty("ConversationList")]
        public List<ConversationListEntry> ConversationListEntries { get; set; }
        public List<ConversationListEntry> AmbientConversationListEntries { get; set; }

        public ConversationList() 
        {
            if (this.ConversationListEntries == null) this.ConversationListEntries = new List<ConversationListEntry>();
            if (this.AmbientConversationListEntries == null) this.AmbientConversationListEntries = new List<ConversationListEntry>();
        }
    }


    public class ConversationListEntry
    { 
        public ConversationTypes Type
        {
            get
            {
                return (ConversationTypes)this.Flags;
            }
            set
            {
                this.Flags = (int)value;
            }
        }

        [PersistentProperty("SNOConversation")]
        public int SNOConversation { get; private set; }

        [PersistentProperty("I0")]
        public int ConditionReqs { get; private set; }

        [PersistentProperty("I1")]
        public int Flags { get; private set; }

        [PersistentProperty("I2")]
        public int CrafterType { get; private set; }

        [PersistentProperty("GbidItem")]
        public int GbidItem { get; private set; }

        [PersistentProperty("Noname1")]
        public string Label { get; private set; }

        [PersistentProperty("Noname2")]
        public string PlayerFlag { get; private set; }

        [PersistentProperty("SNOQuestCurrent")]
        public int SNOQuestCurrent { get; private set; }

        [PersistentProperty("I3")]
        public int StepUIDCurrent { get; private set; }

        [PersistentProperty("Act")]
        public int SpecialEventFlag { get; private set; }
        
        [PersistentProperty("SNOQuestAssigned")]
        public int SNOQuestAssigned { get; private set; }

        [PersistentProperty("SNOQuestActive")]
        public int SNOQuestActive { get; private set; }

        [PersistentProperty("SNOQuestComplete")]
        public int SNOQuestComplete { get; private set; }

        [PersistentProperty("SNOQuestRange")]
        public int SNOQuestRange { get; private set; }

        [PersistentProperty("SNOLevelArea")]
        public int SNOLevelArea { get; private set; }

        public ConversationListEntry() { }
        //*
        public ConversationListEntry(ConversationTypes type, int i0, int questId, int convId, int questStep, int act)
        {
            this.SNOConversation = convId;
            this.SpecialEventFlag = act;
            this.Type = type;
            this.SNOQuestCurrent = -1;
            this.SNOQuestAssigned = -1;
            this.SNOQuestComplete = -1;
            this.SNOQuestRange = -1;
            this.SNOLevelArea = -1;
            this.SNOQuestActive = questId;
            this.ConditionReqs = i0;
            //this.I1 = -1;
            this.CrafterType = -1;
            this.StepUIDCurrent = questStep;
            this.GbidItem = -1;
            this.Label = "";
            this.PlayerFlag = "";
        }
    }
}
