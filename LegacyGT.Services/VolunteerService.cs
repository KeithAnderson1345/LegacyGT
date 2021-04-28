﻿using LegacyGT.Data;
using LegacyGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Services
{
    public class VolunteerService
    {
        private readonly Guid _userId;

        public VolunteerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateVolunteer(VolunteerCreate model)
        {
            var entity =
                new Volunteer()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,                    
                    ShirtSize = model.ShirtSize,
                    Dinner = model.Dinner,
                    Created = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Volunteers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VolunteerListItem> GetVolunteers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Volunteers
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new VolunteerListItem
                        {
                            VolunteerId = e.VolunteerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Created = e.Created
                        }
                    );

                return query.ToArray();
            }
        }

        public VolunteerDetail GetVolunteerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Volunteers
                    .Single(e => e.VolunteerId == id && e.OwnerId == _userId);
                return
                    new VolunteerDetail
                    {
                        VolunteerId = entity.VolunteerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        ShirtSize = entity.ShirtSize,
                        Dinner = entity.Dinner,
                        Created = entity.Created,
                        Modified = entity.Modified
                    };
            }
        }

        public bool UpdateVolunteer(VolunteerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Volunteers
                    .Single(e => e.VolunteerId == model.VolunteerId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;                
                entity.ShirtSize = model.ShirtSize;
                entity.Dinner = model.Dinner;                
                entity.Modified = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVolunteer(int volunteerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Volunteers
                    .Single(e => e.VolunteerId == volunteerId && e.OwnerId == _userId);

                ctx.Volunteers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
