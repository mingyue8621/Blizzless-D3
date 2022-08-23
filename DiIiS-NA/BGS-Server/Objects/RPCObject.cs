﻿//Blizzless Project 2022
//Blizzless Project 2022 
using DiIiS_NA.Core.Logging;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.Base;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.Battle;
//Blizzless Project 2022 
using System;
//Blizzless Project 2022 
using System.Collections.Concurrent;
//Blizzless Project 2022 
using System.Collections.Generic;
//Blizzless Project 2022 
using System.Linq;
//Blizzless Project 2022 
using System.Text;

namespace DiIiS_NA.LoginServer.Objects
{
	public class RPCObject
	{
		protected static readonly Logger Logger = LogManager.CreateLogger("RPCTransfer");

		public ulong DynamicId { get; set; }
		public bgs.protocol.EntityId BnetEntityId;
		public ConcurrentDictionary<BattleClient, byte> Subscribers { get; private set; }
		protected RPCObject()
		{
			RPCObjectManager.Init(this);
			this.Subscribers = new ConcurrentDictionary<BattleClient, byte>();
		}

		/// <summary>
		/// Adds a client subscriber to object, which will eventually be notified whenever the object changes state.
		/// </summary>
		/// <param name="client">The client to add as a subscriber.</param>
		/// <param name="remoteObjectId">The client's dynamic ID.</param>
		public void AddSubscriber(BattleClient client, ulong remoteObjectId)
		{
			if (this.Subscribers.ContainsKey(client)) return;

			this.Subscribers.TryAdd(client, 0);
			client.MapLocalObjectID(this.DynamicId, remoteObjectId);

			if (client.SocketConnection.Active)
			{
				var operations = GetSubscriptionNotifications();
				if (operations.Count > 0)
					MakeRPC(client, operations);
			}
		}

		public void RemoveSubscriber(BattleClient client)
		{
			if (!this.Subscribers.ContainsKey(client)) return;

			client.UnmapLocalObjectId(this.DynamicId);
			this.Subscribers.TryRemove(client, out _);
		}

		public virtual List<bgs.protocol.presence.v1.FieldOperation> GetSubscriptionNotifications()
		{
			return new List<bgs.protocol.presence.v1.FieldOperation>();
		}

		public Helpers.FieldKeyHelper ChangedFields = new Helpers.FieldKeyHelper();

		protected void NotifySubscriptionAdded(BattleClient client)
		{
			var operations = GetSubscriptionNotifications();
			if (operations.Count > 0)
				MakeRPC(client, operations);
		}

		public virtual void NotifyUpdate() { }

		public void CheckSubscribers()
		{
			foreach (var subscriber in this.Subscribers)
			{
				if (!subscriber.Key.SocketConnection.Active)
				{
					Logger.Trace("Removing disconnected subscriber {0}", subscriber.Key);
					this.Subscribers.TryRemove(subscriber.Key, out _);
				}
			}
		}

		public void UpdateSubscribers(ConcurrentDictionary<BattleClient, byte> subscribers, List<bgs.protocol.presence.v1.FieldOperation> operations)
		{
			this.CheckSubscribers();

			foreach (var subscriber in subscribers.Where(c => c.Key.Account.GameAccount != null))
			{
				var gameAccount = subscriber.Key.Account.GameAccount;

				var state = bgs.protocol.presence.v1.ChannelState.CreateBuilder().SetEntityId(this.BnetEntityId);

				state = state.AddRangeFieldOperation(operations);

				var channelState = bgs.protocol.channel.v1.ChannelState.CreateBuilder().SetExtension(bgs.protocol.presence.v1.ChannelState.Presence, state.Build());
				var notification = bgs.protocol.channel.v1.UpdateChannelStateNotification.CreateBuilder().SetStateChange(channelState);
				var altnotification = bgs.protocol.channel.v1.JoinNotification.CreateBuilder().SetChannelState(channelState);
				if (gameAccount.LoggedInClient != null)
				{
					gameAccount.LoggedInClient.MakeTargetedRPC(this, (lid) => bgs.protocol.channel.v1.ChannelListener.CreateStub(gameAccount.LoggedInClient).OnUpdateChannelState(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));
					gameAccount.LoggedInClient.MakeTargetedRPC(this, (lid) =>
					bgs.protocol.channel.v1.ChannelListener.CreateStub(gameAccount.LoggedInClient).OnJoin(new HandlerController() { ListenerId = lid }, altnotification.Build(), callback => { }));
				}
			}
		}

		protected void MakeRPC(BattleClient client, List<bgs.protocol.presence.v1.FieldOperation> operations)
		{
			if (!client.SocketConnection.Active) return;
			var state = bgs.protocol.presence.v1.ChannelState.CreateBuilder().SetEntityId(this.BnetEntityId).AddRangeFieldOperation(operations).Build();
			var channelState = bgs.protocol.channel.v1.ChannelState.CreateBuilder().SetExtension(bgs.protocol.presence.v1.ChannelState.Presence, state);
			var builder = bgs.protocol.channel.v1.JoinNotification.CreateBuilder().SetChannelState(channelState);
			var notification = bgs.protocol.channel.v1.UpdateChannelStateNotification.CreateBuilder().SetStateChange(channelState);
			client.MakeTargetedRPC(this, (lid) =>
				bgs.protocol.channel.v1.ChannelListener.CreateStub(client).OnJoin(new HandlerController() { ListenerId = lid }, builder.Build(), callback => { }));

			client.MakeTargetedRPC(this, (lid) =>
				bgs.protocol.channel.v1.ChannelListener.CreateStub(client).OnUpdateChannelState(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));

		}

		#region de-ctor

		private bool _disposed = false;
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (this._disposed) return; 
			if (disposing) { } 

			RPCObjectManager.Release(this);
			_disposed = true;
		}

		~RPCObject()
		{
			Dispose(false);
		}

		#endregion
	}
}
