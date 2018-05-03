using Temple.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain
{
	/// <summary>
    /// FriendSer 's.Mapping
    /// </summary>
	public class FriendSerMapping : EntityTypeConfiguration<FriendSer>
	{
		public FriendSerMapping() 
        {
            //the TableName
            this.ToTable("FriendSer");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																																																																																																						        }
	}
}