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
    /// Worship_pictures 's.Mapping
    /// </summary>
	public class Worship_picturesMapping : EntityTypeConfiguration<Worship_pictures>
	{
		public Worship_picturesMapping() 
        {
            //the TableName
            this.ToTable("Worship_pictures");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																					        }
	}
}