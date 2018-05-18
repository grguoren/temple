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
    /// Ｍobile_worship 's.Mapping
    /// </summary>
	public class Ｍobile_worshipMapping : EntityTypeConfiguration<Ｍobile_worship>
	{
		public Ｍobile_worshipMapping() 
        {
            //the TableName
            this.ToTable("Ｍobile_worship");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
												        }
	}
}