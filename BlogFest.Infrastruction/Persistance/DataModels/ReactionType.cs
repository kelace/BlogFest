using BlogFest.Infrastructure.Persistance.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogFest.Infrastruction.Persistance.DataModels
{
	public class ReactionTypeData : BaseDataModel
	{
		public new ReactionTypeId Id { get; set; }
        public string Description { get; set; }
		//public List<PostReactionData> Reactions { get; set; } 
	}

	public enum ReactionTypeId
	{
		Like = 0,
		Dislike = 1
	}
}
