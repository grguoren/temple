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
    /// GoodDeed 's.Mapping
    /// </summary>
	public class GoodDeedMapping : EntityTypeConfiguration<GoodDeed>
	{
		public GoodDeedMapping() 
        {
            //the TableName
            this.ToTable("GoodDeed");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																		        }
	}
}