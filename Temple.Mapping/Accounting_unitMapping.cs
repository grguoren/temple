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
    /// Accounting_unit 's.Mapping
    /// </summary>
	public class Accounting_unitMapping : EntityTypeConfiguration<Accounting_unit>
	{
		public Accounting_unitMapping() 
        {
            //the TableName
            this.ToTable("Accounting_unit");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
															        }
	}
}