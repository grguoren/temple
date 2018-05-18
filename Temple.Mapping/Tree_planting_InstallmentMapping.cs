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
    /// Tree_planting_Installment 's.Mapping
    /// </summary>
	public class Tree_planting_InstallmentMapping : EntityTypeConfiguration<Tree_planting_Installment>
	{
		public Tree_planting_InstallmentMapping() 
        {
            //the TableName
            this.ToTable("Tree_planting_Installment");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																								        }
	}
}