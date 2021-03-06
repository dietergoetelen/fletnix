﻿using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class MediaStreamMap : EntityTypeConfiguration<MediaStream>
    {
        public MediaStreamMap()
        {
            ToTable("MediaStream");

            HasMany(m => m.Genres).WithMany().Map(m => m.ToTable("MediaStreamGenre").MapLeftKey("MediaStreamId").MapRightKey("GenreId"));
            HasMany(m => m.Cast).WithRequired(c => c.MediaStream).HasForeignKey(c => c.MediaStreamId).WillCascadeOnDelete();

            HasOptional(m => m.ShowSeason).
                WithMany(s => s.Episodes).
                HasForeignKey(m => new { m.TvShowId, m.Season });
        }
    }
}