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
    /// Sanctuary 's.Mapping
    /// </summary>
	public class SanctuaryMapping : EntityTypeConfiguration<Sanctuary>
	{
		public SanctuaryMapping() 
        {
            //the TableName
            this.ToTable("Sanctuary");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																											        }
	}
}