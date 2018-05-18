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
    /// Ｍobile_worship_pictures 's.Mapping
    /// </summary>
	public class Ｍobile_worship_picturesMapping : EntityTypeConfiguration<Ｍobile_worship_pictures>
	{
		public Ｍobile_worship_picturesMapping() 
        {
            //the TableName
            this.ToTable("Ｍobile_worship_pictures");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
												        }
	}
}