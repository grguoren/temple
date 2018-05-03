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
    /// MeritService 's.Mapping
    /// </summary>
	public class MeritServiceMapping : EntityTypeConfiguration<MeritService>
	{
		public MeritServiceMapping() 
        {
            //the TableName
            this.ToTable("MeritService");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
												        }
	}
}