using Hahn.ApplicationProcess.February2021.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Domain.EntityConfiguration
{
    public class AssetEntityConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("Assets");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.AssetName)
                           .IsRequired(true)
                           .HasMaxLength(5);

            builder.Property(c => c.Broken)
                           .IsRequired(true);

            builder.Property(c => c.CountryOfDepartment)
                           .IsRequired(true)
                           .HasMaxLength(150);

            builder.Property(c => c.Department)
                           .IsRequired(true)
                           .HasMaxLength(100)
                           ;
            
                           

            builder.Property(c => c.EMailAdressOfDepartment)
                           .IsRequired(true)
                           .HasMaxLength(400);

            builder.Property(c => c.PurchaseDate)
                           .IsRequired(true)
                           .HasConversion(
                                v => v,
                                v => new DateTime(v.Ticks, DateTimeKind.Utc));


        }
    }
}