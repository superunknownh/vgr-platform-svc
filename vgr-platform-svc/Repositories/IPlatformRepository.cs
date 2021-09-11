using System.Collections.Generic;

using vgr_platform_svc.Models;

namespace vgr_platform_svc.Repositories
{
    public interface IPlatformRepository
    {
        List<Platform> List();

        Platform GetById(string id);

        Platform GetByName(string name);

        Platform Create(Platform platform);

        Platform Update(Platform platform);

        Platform Delete(string id);
    }
}
