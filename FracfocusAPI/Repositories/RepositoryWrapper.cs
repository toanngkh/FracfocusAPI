using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FracfocusAPI.Interfaces;
using FracfocusAPI.Models;

namespace FracfocusAPI.Repositories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private FracfocusDBContext _fracfocusDBContext;
        private IFracfocusRepository _fracfocusRepository;

        public IFracfocusRepository Fracfocus
        {
            get
            {
                if (_fracfocusRepository == null)
                {
                    _fracfocusRepository = new FracfocusRepository(_fracfocusDBContext);
                }

                return _fracfocusRepository;
            }
        }

        public RepositoryWrapper(FracfocusDBContext fracfocusDBContext)
        {
            _fracfocusDBContext = fracfocusDBContext;
        }
    }
}
