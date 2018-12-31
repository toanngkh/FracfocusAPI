using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FracfocusAPI.Models;

namespace FracfocusAPI.Interfaces
{
    public interface IRepositoryWrapper
    {
        IFracfocusRepository Fracfocus { get; }
    }
}
