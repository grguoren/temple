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
    /// Good_project 's.Mapping
    /// </summary>
	public class Good_projectMapping : EntityTypeConfiguration<Good_project>
	{
		public Good_projectMapping() 
        {
            //the TableName
            this.ToTable("Good_project");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																		        }
	}
}