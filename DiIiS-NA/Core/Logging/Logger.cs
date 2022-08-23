﻿//Blizzless Project 2022
//Blizzless Project 2022 
using System;
//Blizzless Project 2022 
using System.Globalization;
//Blizzless Project 2022 
using System.Text;
//Blizzless Project 2022 
using DiIiS_NA.Core.Extensions;
//Blizzless Project 2022 
using DiIiS_NA.GameServer.MessageSystem;

namespace DiIiS_NA.Core.Logging
{
	public class Logger
	{
		public string Name { get; protected set; }

		/// <param name="name">Name of the logger.</param>
		public Logger(string name)
		{
			Name = name;
		}

		public enum Level
		{
			RenameAccountLog,
			ChatMessage,
			BotCommand,
			Trace,
			Debug,
			Info,
			Warn,
			Error,
			Fatal,
			PacketDump,
		}

		#region message loggers

		/// <param name="message">The log message.</param>
		public void ChatMessage(string message) { Log(Level.ChatMessage, message, null); }
		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void ChatMessage(string message, params object[] args) { Log(Level.ChatMessage, message, args); }

		/// <param name="message">The log message.</param>
		public void BotCommand(string message) { Log(Level.BotCommand, message, null); }

		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void BotCommand(string message, params object[] args) { Log(Level.BotCommand, message, args); }

		/// <param name="message">The log message.</param>
		public void RenameAccount(string message) { Log(Level.RenameAccountLog, message, null); }

		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void RenameAccount(string message, params object[] args) { Log(Level.RenameAccountLog, message, args); }

		/// <param name="message">The log message.</param>
		public void Trace(string message) { Log(Level.Trace, message, null); }

		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void Trace(string message, params object[] args) { Log(Level.Trace, message, args); }

		/// <param name="message">The log message.</param>
		public void Debug(string message) { Log(Level.Debug, message, null); }

		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void Debug(string message, params object[] args) { Log(Level.Debug, message, args); }

		/// <param name="message">The log message.</param>
		public void Info(string message) { Log(Level.Info, message, null); }

		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void Info(string message, params object[] args) { Log(Level.Info, message, args); }

		/// <param name="message">The log message.</param>
		public void Warn(string message) { Log(Level.Warn, message, null); }

		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void Warn(string message, params object[] args) { Log(Level.Warn, message, args); }

		/// <param name="message">The log message.</param>
		public void Error(string message) { Log(Level.Error, message, null); }

		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void Error(string message, params object[] args) { Log(Level.Error, message, args); }

		/// <param name="message">The log message.</param>
		public void Fatal(string message) { Log(Level.Fatal, message, null); }

		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void Fatal(string message, params object[] args) { Log(Level.Fatal, message, args); }

		#endregion

		#region message loggers with additional exception info included

		/// <summary>
		/// Logs a trace message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		public void TraceException(Exception exception, string message) { LogException(Level.Trace, message, null, exception); }

		/// <summary>
		/// Logs a trace message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void TraceException(Exception exception, string message, params object[] args) { LogException(Level.Trace, message, args, exception); }

		/// <summary>
		/// Logs a debug message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		public void DebugException(Exception exception, string message) { LogException(Level.Debug, message, null, exception); }

		/// <summary>
		/// Logs a debug message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void DebugException(Exception exception, string message, params object[] args) { LogException(Level.Debug, message, args, exception); }

		/// <summary>
		/// Logs an info message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		public void InfoException(Exception exception, string message) { LogException(Level.Info, message, null, exception); }

		/// <summary>
		/// Logs an info message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void InfoException(Exception exception, string message, params object[] args) { LogException(Level.Info, message, args, exception); }

		/// <summary>
		/// Logs a warning message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		public void WarnException(Exception exception, string message) { LogException(Level.Warn, message, null, exception); }

		/// <summary>
		/// Logs a warning message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void WarnException(Exception exception, string message, params object[] args) { LogException(Level.Warn, message, args, exception); }

		/// <summary>
		/// Logs an error message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		public void ErrorException(Exception exception, string message) { LogException(Level.Error, message, null, exception); }

		/// <summary>
		/// Logs an error message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void ErrorException(Exception exception, string message, params object[] args) { LogException(Level.Error, message, args, exception); }

		/// <summary>
		/// Logs a fatal error message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		public void FatalException(Exception exception, string message) { LogException(Level.Fatal, message, null, exception); }

		/// <summary>
		/// Logs a fatal error message with an exception included.
		/// </summary>
		/// <param name="exception">The exception to include in log line.</param>
		/// <param name="message">The log message.</param>
		/// <param name="args">Additional arguments.</param>
		public void FatalException(Exception exception, string message, params object[] args) { LogException(Level.Fatal, message, args, exception); }

		#endregion

		#region packet loggers

		/// <summary>
		/// Logs an incoming moonet (protocol-buffer) packet.
		/// </summary>
		/// <param name="message">Incoming protocol-buffer packet.</param>
		/// <param name="header"><see cref="bgs.protocol.Header"/> header</param>
		public void LogIncomingPacket(Google.ProtocolBuffers.IMessage message, bgs.protocol.Header header)
		{
			Log(Level.PacketDump, ShortHeader(header) + "[I(M)] " + message.AsText(), null);
		}
		//*
		/// <summary>
		/// Logs an incoming game-server packet.
		/// </summary>
		/// <param name="message">Gameserver packet to log.</param>
		public void LogIncomingPacket(GameMessage message)
		{
			Log(Level.PacketDump, "[I(G)] " + message.AsText(), null);
		}
		//*/
		/// <summary>
		/// Logs an incoming moonet (protocol-buffer) packet.
		/// </summary>
		/// <param name="message">Outgoing protocol-buffer packet.</param>
		/// <param name="header"><see cref="bgs.protocol.Header"/> header</param>
		public void LogOutgoingPacket(Google.ProtocolBuffers.IMessage message, bgs.protocol.Header header)
		{
			Log(Level.PacketDump, ShortHeader(header) + "[O(M)] " + message.AsText(), null);
		}
		//*
		/// <summary>
		/// Logs an outgoing game-server packet.
		/// </summary>
		/// <param name="message">Gameserver packet to log.</param>
		public void LogOutgoingPacket(GameMessage message)
		{
			Log(Level.PacketDump, "[O(G)] " + message.AsText(), null);
		}
		//*/
		#endregion


		#region utility functions

		private void Log(Level level, string message, object[] args) // sends logs to log-router.
		{
			LogRouter.RouteMessage(level, this.Name, args == null ? message : string.Format(CultureInfo.InvariantCulture, message, args));
		}

		private void LogException(Level level, string message, object[] args, Exception exception) // sends logs to log-router.
		{
			LogRouter.RouteException(level, this.Name, args == null ? message : string.Format(CultureInfo.InvariantCulture, message, args), exception);
		}

		private StringBuilder ShortHeader(bgs.protocol.Header header)
		{
			var result = new StringBuilder("service_id: " + header.ServiceId);
			result.Append(header.HasMethodId ? " method_id: " + header.MethodId.ToString() : "");
			result.Append(header.HasToken ? " token: " + header.Token.ToString() : "");
			result.Append(header.HasObjectId ? " object_id: " + header.ObjectId.ToString() : "");
			result.Append(header.HasSize ? " size: " + header.Size.ToString() : "");
			result.Append(header.HasStatus ? " status: " + header.Status.ToString() : "");
			result.AppendLine();
			return result;
		}

		#endregion
	}
}
