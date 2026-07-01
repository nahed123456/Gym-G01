using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Gym_G01.Models; // عشان يشوف كلاس Plan

namespace Gym_G01.NewFolder1
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            // هنا بتكتبي الإعدادات بتاعتك (الـ Fluent API)
            // مثال لو حابة تحددي الـ Primary Key:
            builder.HasKey(p => p.Id);

            // مثال لو حابة تخلي الاسم مطلوب وطوله 50:
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}