using System;
using System.Runtime.Serialization;

namespace WebApiService
{
	[DataContract]
	public class Todo
	{
		[DataMember]
		public Guid Id { get; set; }
		[DataMember]
		public int Order { get; set; }
		[DataMember]
		public string Title { get; set; }
		[DataMember]
		public TodoStatus Status { get; set; }
	}

	[DataContract]
	public enum TodoStatus
	{
		[DataMember]
		Active,
		[DataMember]
		Postponed,
		[DataMember]
		Completed
	}
}
