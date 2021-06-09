using Cleverbit.CodingTask.Data.DBProvider;
using Cleverbit.CodingTask.Data.Entities;
using Cleverbit.CodingTask.Utilities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Utilities.Services
{
    public class MatchService : IMatchService
    {
        private readonly CleverbitDBContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly Random _random = new Random();
        public MatchService(CleverbitDBContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> GetRandomNumberAsync()
        {
            var authHeader = AuthenticationHeaderValue.Parse(_contextAccessor.HttpContext.Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            var username = credentials[0];
            int number = await Task.Run(() => _random.Next(0, 100));
            await SaveNumberAsync(username, number);
            return number;
        }

        private async Task SaveNumberAsync(string username, int number)
        {
            User user = await _context.User.FirstOrDefaultAsync(x => x.Username == username);
            UserMatch userMatch = await _context.UserMatch.FirstOrDefaultAsync(x => x.FirstUserId == user.Id || x.SecondUserId == user.Id);
            if (userMatch != null)
            {
                if (!(userMatch.FirstUserAccepted && userMatch.SecondUserAccepted) && DateTime.Now < userMatch.MatchEndDate)
                {
                    if (userMatch.FirstUserId == user.Id)
                    {
                        userMatch.FirstUserAccepted = true;
                        userMatch.FirstUserPoint = number;
                    }
                    else
                    {
                        userMatch.SecondUserAccepted = true;
                        userMatch.SecondUserPoint = number;
                    }
                    if (userMatch.FirstUserAccepted && userMatch.SecondUserAccepted)
                    {
                        if (userMatch.FirstUserPoint > userMatch.SecondUserPoint)
                        {
                            userMatch.WinnerUserId = userMatch.FirstUserId;
                        }
                        else
                        {
                            userMatch.WinnerUserId = userMatch.SecondUserId;
                        }

                    }
                    _context.UserMatch.Update(userMatch);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new Exception("Time is Up!");
            }
        }

        public async Task<List<UserMatch>> GetUserMatchAsync()
        {
            var userMatches = await Task.Run(() => _context.UserMatch.Include(x => x.SecondUser).Include(x => x.FirstUser).Where(x=>x.FirstUserAccepted && x.SecondUserAccepted).ToList());
            return userMatches;
        }
    }
}
