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
    /// Education_course 's.Mapping
    /// </summary>
	public class Education_courseMapping : EntityTypeConfiguration<Education_course>
	{
		public Education_courseMapping() 
        {
            //the TableName
            this.ToTable("Education_course");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																											        }
	}
}