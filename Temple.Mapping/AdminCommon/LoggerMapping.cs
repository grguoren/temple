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
    public class LoggerMapping : EntityTypeConfiguration<Logger>
    {
        public LoggerMapping() 
        {
            //指定表
            this.ToTable("admin_Logger");

            //指定主键
            this.HasKey(x => x.Id);

            //设置ID自增
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
