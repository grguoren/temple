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
    /// SerMetting 's.Mapping
    /// </summary>
	public class SerMettingMapping : EntityTypeConfiguration<SerMetting>
	{
		public SerMettingMapping() 
        {
            //the TableName
            this.ToTable("SerMetting");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
									        }
	}
}