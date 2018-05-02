using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Models.Domain
{
    public interface ISessionRepository
    {
        Session GetBy(int sessionId);

        IEnumerable<Session> GetAll();
        IEnumerable<PlayGroup> GetPlaygroupsFromSession(int id);
        void SaveChanges();
    }
}
