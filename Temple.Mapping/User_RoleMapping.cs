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
    /// User_Role 's.Mapping
    /// </summary>
	public class User_RoleMapping : EntityTypeConfiguration<User_Role>
	{
		public User_RoleMapping() 
        {
            //the TableName
            this.ToTable("User_Role");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
									        }
	}
}