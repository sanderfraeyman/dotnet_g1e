using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Data.Repositories
{
    public class SessionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Session> _sessions;

        public SessionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _sessions = dbContext.Sessions;
        }

        public Session GetBy(int sessionId)
        {
            return _sessions.Include(s => s.Name).SingleOrDefault(s => s.SessionId == sessionId);
        }

        public IEnumerable<Session> GetAll()
        {
            return _sessions.Include(s => s.Name).Include(s => s.Description).ToList();
        }

        public void Add(Session session)
        {
            _sessions.Add(session);
        }

        public void Delete(Session session)
        {
            _sessions.Remove(session);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
