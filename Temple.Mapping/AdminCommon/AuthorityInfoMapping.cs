using Temple.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Mapping
{
    public class AuthorityInfoMapping : EntityTypeConfiguration<AuthorityInfo>
    {
        public AuthorityInfoMapping() 
        {
            //指定表
            this.ToTable("admin_AuthorityInfo");

            //指定主键
            this.HasKey(x => x.ID);

            //设置ID不自增
            //this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //设置ID自增
            this.Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
