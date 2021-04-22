using LegacyGT.Data;
using LegacyGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Services
{
    public class PlayerService
    {
        private readonly Guid _userId;

        public PlayerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlayer(PlayerCreate model)
        {
            var entity =
                new Player()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Handicap = model.Handicap,
                    ShirtSize = model.ShirtSize,
                    Dinner = model.Dinner,
                    Raffle = model.Raffle,
                    Mulligans = model.Mulligans,
                    Created = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Players
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new PlayerListItem
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Created = e.Created
                        }
                    );

                return query.ToArray();
            }
        }

        public PlayerDetail GetPlayerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == id && e.OwnerId == _userId);
                return
                    new PlayerDetail
                    {
                        PlayerId = entity.PlayerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Handicap = entity.Handicap,
                        ShirtSize = entity.ShirtSize,
                        Dinner = entity.Dinner,
                        Raffle = entity.Raffle,
                        Mulligans = entity.Mulligans,
                        Created = entity.Created,
                        Modified = entity.Modified
                    };
            }
        }

        public bool UpdatePlayer(PlayerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == model.PlayerId && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Handicap = model.Handicap;
                entity.ShirtSize = model.ShirtSize;
                entity.Dinner = model.Dinner;
                entity.Raffle = model.Raffle;
                entity.Mulligans = model.Mulligans;
                entity.Modified = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlayer(int playerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == playerId && e.OwnerId == _userId);

                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
