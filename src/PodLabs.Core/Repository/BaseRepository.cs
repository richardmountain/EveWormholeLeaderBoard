using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.Core.Repository
{
    public abstract class BaseRepository
    {
        protected PodLabsContext _DbContext;

        public BaseRepository(PodLabsContext context) => _DbContext = context;

    }
}
