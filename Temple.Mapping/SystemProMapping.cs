﻿using Temple.Domain;
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
    /// SystemPro 's.Mapping
    /// </summary>
	public class SystemProMapping : EntityTypeConfiguration<SystemPro>
	{
		public SystemProMapping() 
        {
            //the TableName
            this.ToTable("SystemPro");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																		        }
	}
}