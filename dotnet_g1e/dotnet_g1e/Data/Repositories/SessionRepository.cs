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
            return _sessions.Include(s => s.Classgroup).Include(s => s.SessionPlayGroups).ThenInclude(sp => sp.PlayGroup).ThenInclude(p => p.PlayGroupPupils).ThenInclude(pp => pp.Pupil).SingleOrDefault(s => s.SessionId == sessionId);
        }

        public IEnumerable<Session> GetAll()
        {
            return _sessions.Include(s => s.Classgroup).Include(s => s.SessionPlayGroups).ThenInclude(sg => sg.PlayGroup).ThenInclude(sg => sg.PlayGroupPupils).ThenInclude(sp => sp.Pupil).ToList();
        }

        public IEnumerable<PlayGroup> GetPlaygroupsFromSession(int id)
        {
            return _sessions.Where(s => s.SessionId == id)
                .SelectMany(s => s.SessionPlayGroups)
                .Select(sg => sg.PlayGroup).Include(t => t.PlayGroupPupils).ThenInclude(t => t.Pupil).ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
