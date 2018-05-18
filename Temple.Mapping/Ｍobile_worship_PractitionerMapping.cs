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
    /// Ｍobile_worship_Practitioner 's.Mapping
    /// </summary>
	public class Ｍobile_worship_PractitionerMapping : EntityTypeConfiguration<Ｍobile_worship_Practitioner>
	{
		public Ｍobile_worship_PractitionerMapping() 
        {
            //the TableName
            this.ToTable("Ｍobile_worship_Practitioner");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
												        }
	}
}