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
    /// Practitioner 's.Mapping
    /// </summary>
	public class PractitionerMapping : EntityTypeConfiguration<Practitioner>
	{
		public PractitionerMapping() 
        {
            //the TableName
            this.ToTable("Practitioner");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
																																																																								        }
	}
}