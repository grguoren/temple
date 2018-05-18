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
    /// Tree_maintenance 's.Mapping
    /// </summary>
	public class Tree_maintenanceMapping : EntityTypeConfiguration<Tree_maintenance>
	{
		public Tree_maintenanceMapping() 
        {
            //the TableName
            this.ToTable("Tree_maintenance");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																		        }
	}
}