using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduOne.Data.Fr;

namespace EduOne.Repositories.Fr
{
    public class ApplicationRolesRepository:IRepository<ApplicationRoles>
    {
        private EduOne_FrEntities db = new EduOne_FrEntities();

        /// <summary>Gets all roles</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IList<ApplicationRoles> GetAll()
        {
            IList<ApplicationRoles> result = new List<ApplicationRoles>();
            result = db.ApplicationRoles.ToList();
            return result;
        }

        public async Task<IList<ApplicationRoles>> GetAllAsync()
        {
            IList<ApplicationRoles> result = new List<ApplicationRoles>();
            result =await db.ApplicationRoles.ToListAsync().ConfigureAwait(false);
            return result;
        }

        public ApplicationRoles Find(ApplicationRoles entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRoles> FindAsync(ApplicationRoles entity)
        {
            throw new NotImplementedException();
        }

        public ApplicationRoles AddOrUpdate(ApplicationRoles entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRoles> AddOrUpdateAsync(ApplicationRoles entity)
        {
            throw new NotImplementedException();
        }

        public ApplicationRoles Delete(ApplicationRoles entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRoles> DeleteAsync(ApplicationRoles entity)
        {
            throw new NotImplementedException();
        }
    }
}
