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
    /// RecFri 's.Mapping
    /// </summary>
	public class RecFriMapping : EntityTypeConfiguration<RecFri>
	{
		public RecFriMapping() 
        {
            //the TableName
            this.ToTable("RecFri");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
															        }
	}
}