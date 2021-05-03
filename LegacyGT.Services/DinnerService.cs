using LegacyGT.Data;
using LegacyGT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyGT.Services
{
    public class DinnerService
    {
        private readonly Guid _userId;

        public DinnerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlayerDinner(PlayerCreate model)
        {
            var entity =
                new Dinner()
                {
                    DinnerChosen = model.Dinner,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dinners.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
