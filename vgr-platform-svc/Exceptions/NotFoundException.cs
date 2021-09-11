using System;

namespace vgr_platform_svc.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException() : base()
        {
        }
    }
}
