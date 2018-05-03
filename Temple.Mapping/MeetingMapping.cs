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
    /// Meeting 's.Mapping
    /// </summary>
	public class MeetingMapping : EntityTypeConfiguration<Meeting>
	{
		public MeetingMapping() 
        {
            //the TableName
            this.ToTable("Meeting");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																					        }
	}
}