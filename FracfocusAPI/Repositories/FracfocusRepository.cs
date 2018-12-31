using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FracfocusAPI.Models;
using FracfocusAPI.Interfaces;

namespace FracfocusAPI.Repositories
{
    public class FracfocusRepository: FracfocusRepositoryBase<Fracfocus>, IFracfocusRepository
    {
        public FracfocusRepository(FracfocusDBContext fracfocusDBContext)
            :base(fracfocusDBContext)
        {
        }

        public IEnumerable<Fracfocus> GetAllInfo()
        {
            return FindAll()
                .OrderByDescending(ow => ow.JobStartDate);
        }

        public IEnumerable<Fracfocus> GetInfoByAPI(string api)
        {
            return FindByCondition(x => x.Apinumber.Equals(api))
                .OrderByDescending(ow => ow.JobStartDate);
        }
    }
}
