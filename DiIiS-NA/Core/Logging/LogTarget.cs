﻿//Blizzless Project 2022
//Blizzless Project 2022 
using System;

namespace DiIiS_NA.Core.Logging
{
	public class LogTarget
	{
		public Logger.Level MinimumLevel { get; protected set; }
		public Logger.Level MaximumLevel { get; protected set; }
		public bool IncludeTimeStamps { get; protected set; }

		public virtual void LogMessage(Logger.Level level, string logger, string message)
		{
			throw new NotSupportedException("不支持原版日志目标！ 而是使用 log-target 实现.");
		}

		public virtual void LogException(Logger.Level level, string logger, string message, Exception exception)
		{
			throw new NotSupportedException("不支持原版日志目标！ 而是使用 log-target 实现.");
		}
	}
}
