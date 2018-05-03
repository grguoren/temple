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
    /// Maintain 's.Mapping
    /// </summary>
	public class MaintainMapping : EntityTypeConfiguration<Maintain>
	{
		public MaintainMapping() 
        {
            //the TableName
            this.ToTable("Maintain");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																		        }
	}
}