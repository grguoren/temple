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
    /// MobilePic 's.Mapping
    /// </summary>
	public class MobilePicMapping : EntityTypeConfiguration<MobilePic>
	{
		public MobilePicMapping() 
        {
            //the TableName
            this.ToTable("MobilePic");
									 //the PrimaryKey
            this.HasKey(x => x.Id);
            //the PrimaryKeyName +1
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
												        }
	}
}