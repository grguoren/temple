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
    /// Service_name 's.Mapping
    /// </summary>
	public class Service_nameMapping : EntityTypeConfiguration<Service_name>
	{
		public Service_nameMapping() 
        {
            //the TableName
            this.ToTable("Service_name");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(x => x.Account)
              .WithMany()
              .HasForeignKey(x => x.Accounting_unit_id)
              .WillCascadeOnDelete(false);

		}
	}
}