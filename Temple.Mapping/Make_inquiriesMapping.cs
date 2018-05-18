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
    /// Make_inquiries 's.Mapping
    /// </summary>
	public class Make_inquiriesMapping : EntityTypeConfiguration<Make_inquiries>
	{
		public Make_inquiriesMapping() 
        {
            //the TableName
            this.ToTable("Make_inquiries");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																											        }
	}
}