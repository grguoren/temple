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
    /// Practitioner_ member_Relation 's.Mapping
    /// </summary>
	public class Practitioner_member_RelationMapping : EntityTypeConfiguration<Practitioner_member_Relation>
	{
		public Practitioner_member_RelationMapping() 
        {
            //the TableName
            this.ToTable("Practitioner_ member_Relation");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
															        }
	}
}