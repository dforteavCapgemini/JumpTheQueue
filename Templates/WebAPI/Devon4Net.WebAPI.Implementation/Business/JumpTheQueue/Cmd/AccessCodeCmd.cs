using System;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd
{
	/// <summary>
	/// /AccessCode plain text
	/// </summary>
	public class AccessCodeCmd
	{
		public int VisitorId { get; set; }
		public int QueueId {get; set;}
	}
}
