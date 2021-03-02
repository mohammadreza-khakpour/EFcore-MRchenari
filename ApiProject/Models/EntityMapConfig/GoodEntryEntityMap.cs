using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Models.EntityMapConfig
{
    public class GoodEntryEntityMap : IEntityTypeConfiguration<GoodEntry>
    {
        public void Configure(EntityTypeBuilder<GoodEntry> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(y => y.Id).ValueGeneratedOnAdd();

            builder.Property(z => z.EntryDate).IsRequired();
        }
    }
}
