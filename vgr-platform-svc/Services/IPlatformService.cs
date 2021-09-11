using System.Collections.Generic;

using vgr_platform_svc.Models;

namespace vgr_platform_svc.Services
{
    public interface IPlatformService
    {
        List<Platform> List();

        Platform GetById(string id);

        Platform Create(Platform platform);

        Platform Update(Platform platform);

        void Delete(string id);
    }
}
