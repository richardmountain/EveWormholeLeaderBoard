using System;
using System.Collections.Generic;
using System.Text;

namespace PodLabs.Core.Repository
{
    public abstract class BaseRepository
    {
        protected PodLabsContext _DbContext;
        protected NLog.Logger logger = Classes.Local.Log.InitLogger();

        public BaseRepository(PodLabsContext context) => _DbContext = context;

        protected bool PrintError(Exception e)
        {
            logger.Error(e.Message);

            if (e.InnerException != null)
                logger.Error(e.InnerException.Message);

            return false;
        }

    }
}
