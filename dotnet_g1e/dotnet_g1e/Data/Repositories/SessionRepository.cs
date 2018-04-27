using dotnet_g1e.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Data.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Session> _sessions;

        public SessionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _sessions = _dbContext.Sessions;
        }

        public Session GetBy(int sessionId)
        {
            return _sessions.SingleOrDefault(s => s.SessionId == sessionId);
        }

        public IEnumerable<Session> GetAll()
        {
            return _sessions.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
