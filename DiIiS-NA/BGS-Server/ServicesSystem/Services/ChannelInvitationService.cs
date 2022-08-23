﻿//Blizzless Project 2022
//Blizzless Project 2022 
using bgs.protocol;
//Blizzless Project 2022 
using bgs.protocol.channel.v1;
//Blizzless Project 2022 
using DiIiS_NA.Core.Extensions;
//Blizzless Project 2022 
using DiIiS_NA.Core.Logging;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.AccountsSystem;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.Base;
//Blizzless Project 2022 
using DiIiS_NA.LoginServer.ChannelSystem;
//Blizzless Project 2022 
using System;

namespace DiIiS_NA.LoginServer.ServicesSystem.Services
{
    [Service(serviceID: 0x33, serviceName: "bnet.protocol.channel_invitation.ChannelInvitationService")]
	public class ChannelInvitationService : bgs.protocol.channel.v1.ChannelInvitationService, IServerService
	{
		private static readonly Logger Logger = LogManager.CreateLogger();

		public readonly ChannelInvitationManager _invitationManager = new ChannelInvitationManager();

		public override void Subscribe(Google.ProtocolBuffers.IRpcController controller, bgs.protocol.channel.v1.SubscribeRequest request, Action<NoData> done)
		{
			Logger.Trace("Subscribe() {0}", ((controller as HandlerController).Client));

			this._invitationManager.AddSubscriber(((controller as HandlerController).Client), request.ObjectId);
			
			done(NoData.DefaultInstance);
		}

		public override void AcceptInvitation(Google.ProtocolBuffers.IRpcController controller, AcceptInvitationRequest request, Action<AcceptInvitationResponse> done)
		{
			var channel = ChannelManager.GetChannelByEntityId(_invitationManager.GetInvitationById(request.InvitationId).GetExtension(ChannelInvitation.ChannelInvitationProp).ChannelDescription.ChannelId);
			var response = AcceptInvitationResponse.CreateBuilder().SetObjectId(channel.DynamicId).Build();
			done(response);

			this._invitationManager.HandleAccept(((controller as HandlerController).Client), request);
		}

		public override void DeclineInvitation(Google.ProtocolBuffers.IRpcController controller, DeclineInvitationRequest request, Action<NoData> done)
		{
			var respone = NoData.CreateBuilder();
			done(respone.Build());

			this._invitationManager.HandleDecline(((controller as HandlerController).Client), request);
		}

		public override void RevokeInvitation(Google.ProtocolBuffers.IRpcController controller, RevokeInvitationRequest request, Action<NoData> done)
		{
			var builder = NoData.CreateBuilder();
			done(builder.Build());

			this._invitationManager.Revoke(((controller as HandlerController).Client), request);
		}

		public override void SendInvitation(Google.ProtocolBuffers.IRpcController controller, SendInvitationRequest request, Action<NoData> done)
		{
			var invitee = GameAccountManager.GetAccountByPersistentID(request.TargetId.Low);
			
			if (invitee.Owner.IgnoreIds.Contains((controller as HandlerController).Client.Account.PersistentID))
			{
				((controller as HandlerController).Status) = 403;
				done(NoData.CreateBuilder().Build());
				return;
			}

			var extensionBytes = request.Params.UnknownFields.FieldDictionary[105].LengthDelimitedList[0].ToByteArray();
			var channelInvitationInfo = ChannelInvitationParams.ParseFrom(extensionBytes);

			var channel = ChannelManager.GetChannelByEntityId(channelInvitationInfo.ChannelId);

			var channelDescription = ChannelDescription.CreateBuilder()
				.SetChannelId(channelInvitationInfo.ChannelId)
				.SetCurrentMembers((uint)channel.Members.Count)
				.SetState(channel.State)
				;

			var channelInvitation = ChannelInvitation.CreateBuilder()
				.SetChannelDescription(channelDescription)
				.SetReserved(false)
				.SetServiceType(1)
				.SetRejoin(false)
				.Build();
			
			var invitation = Invitation.CreateBuilder();
			invitation.SetId(ChannelInvitationManager.InvitationIdCounter++)
				.SetInviterIdentity(Identity.CreateBuilder().SetGameAccountId((controller as HandlerController).Client.Account.GameAccount.BnetEntityId).Build())
				.SetInviterName((controller as HandlerController).Client.Account.GameAccount.Owner.BattleTag)
				.SetInviteeIdentity(Identity.CreateBuilder().SetGameAccountId(request.TargetId).Build())
				.SetInviteeName(invitee.Owner.BattleTag)
				.SetInvitationMessage(request.Params.InvitationMessage)
				.SetCreationTime(DateTime.Now.ToExtendedEpoch())
				.SetExpirationTime(DateTime.Now.ToUnixTime() + request.Params.ExpirationTime)
				.SetExtension(ChannelInvitation.ChannelInvitationProp, channelInvitation)
				;

			var respone = NoData.CreateBuilder();
			done(respone.Build());

			var notification = UpdateChannelStateNotification.CreateBuilder()
				.SetAgentId(EntityId.CreateBuilder().SetHigh(0).SetLow(1))
				.SetStateChange(ChannelState.CreateBuilder().AddInvitation(invitation.Clone()));

			var builder = JoinNotification.CreateBuilder().SetChannelState(ChannelState.CreateBuilder().AddInvitation(invitation.Clone()));

			(controller as HandlerController).Client.MakeTargetedRPC(channel, (lid) => ChannelListener.CreateStub((controller as HandlerController).Client)
			.OnUpdateChannelState(controller, notification.Build(), callback => { }));
			(controller as HandlerController).Client.MakeTargetedRPC(channel, (lid) =>
				ChannelListener.CreateStub((controller as HandlerController).Client).OnJoin(new HandlerController() { ListenerId = lid }, builder.Build(), callback => { }));

			this._invitationManager.HandleInvitation((controller as HandlerController).Client, invitation.Build());


		}
		public override void SuggestInvitation(Google.ProtocolBuffers.IRpcController controller, bgs.protocol.channel.v1.SuggestInvitationRequest request, Action<NoData> done)
		{
			var suggester = GameAccountManager.GetAccountByPersistentID(request.TargetId.Low); 
			var suggestee = GameAccountManager.GetAccountByPersistentID(request.ApprovalId.Low);
			if (suggestee == null) return;

			if (suggestee.Owner.IgnoreIds.Contains(suggester.Owner.PersistentID))
			{
				((controller as HandlerController).Status) = 403;
				done(NoData.CreateBuilder().Build());
				return;
			}

			Logger.Debug("{0}建议{1}邀请他.", suggester, suggestee);
			var respone = NoData.CreateBuilder();
			done(respone.Build());

			var suggestion = InvitationSuggestion.CreateBuilder()
				.SetChannelId(request.ChannelId)
				.SetSuggesterId(suggester.BnetEntityId)
				.SetSuggesterName(suggester.Owner.BattleTag)
				.SetSuggesteeId(suggester.BnetEntityId)
				.SetSuggesteeName(suggester.Owner.BattleTag)
				.Build();

			var notification = SuggestionAddedNotification.CreateBuilder().SetSuggestion(suggestion);

			suggestee.LoggedInClient.MakeTargetedRPC(this._invitationManager, (lid) =>
				ChannelInvitationListener.CreateStub(suggestee.LoggedInClient).OnReceivedSuggestionAdded(new HandlerController() { ListenerId = lid }, notification.Build(), callback => { }));
		}

		

		public override void ListChannelCount(Google.ProtocolBuffers.IRpcController controller, ListChannelCountRequest request, Action<ListChannelCountResponse> done)
		{

		}

	}
}
