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
    /// Payment_item 's.Mapping
    /// </summary>
	public class Payment_itemMapping : EntityTypeConfiguration<Payment_item>
	{
		public Payment_itemMapping() 
        {
            //the TableName
            this.ToTable("Payment_item");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
															        }
	}
}