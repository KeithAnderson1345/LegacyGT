using LegacyGT.Data;
using LegacyGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Services
{
    public class SponsorService
    {
        private readonly Guid _userId;

        public SponsorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSponsor(SponsorCreate model)
        {
            var entity =
                new Sponsor()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Created = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sponsors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SponsorListItem> GetSponsors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Sponsors
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new SponsorListItem
                        {
                            SponsorId = e.SponsorId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Created = e.Created
                        }
                    );

                return query.ToArray();
            }
        }

        public SponsorDetail GetSponsorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sponsors
                    .Single(e => e.SponsorId == id && e.OwnerId == _userId);
                return
                    new SponsorDetail
                    {
                        SponsorId = entity.SponsorId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Created = entity.Created,
                        Modified = entity.Modified
                    };
            }
        }

        public bool UpdateSponsor(SponsorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sponsors
                    .Single(e => e.SponsorId == model.SponsorId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Modified = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSponsor(int sponsorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sponsors
                    .Single(e => e.SponsorId == sponsorId && e.OwnerId == _userId);

                ctx.Sponsors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
