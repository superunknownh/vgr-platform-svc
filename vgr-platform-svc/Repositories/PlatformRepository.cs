using System;
using System.Collections.Generic;

using vgr_platform_svc.Models;

namespace vgr_platform_svc.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private static readonly List<Platform> _cache = new()
        {
            new Platform("NES", "Nintendo Entertainment System", DateTime.Now, DateTime.Now),
            new Platform("SNES", "Super Nintendo Entertainment System", DateTime.Now, DateTime.Now),
            new Platform("GB", "Gameboy", DateTime.Now, DateTime.Now),
            new Platform("GBC", "Gameboy Color", DateTime.Now, DateTime.Now),
            new Platform("GBA", "Gameboy Advance", DateTime.Now, DateTime.Now),
            new Platform("N64", "Nintendo 64", DateTime.Now, DateTime.Now),
            new Platform("PS2", "Play Station 2", DateTime.Now, DateTime.Now),
            new Platform("NDS", "Nintendo DS", DateTime.Now, DateTime.Now),
            new Platform("N3DS", "Nintendo 3DS", DateTime.Now, DateTime.Now),
        };

        public List<Platform> List()
        {
            return _cache;
        }

        public Platform GetById(string id)
        {
            foreach (var platform in _cache)
            {
                if (platform.Id.Equals(id))
                {
                    return platform;
                }
            }
            return null;
        }

        public Platform GetByName(string name)
        {
            foreach (var platform in _cache)
            {
                if (platform.Id.Equals(name))
                {
                    return platform;
                }
            }
            return null;
        }

        public Platform Create(Platform platform)
        {
            _cache.Add(platform);
            return platform;
        }

        public Platform Update(Platform platform)
        {
            for (int i = 0; i < _cache.Count; i++)
            {
                if (_cache[i].Id.Equals(platform.Id))
                {
                    _cache[i].Name = platform.Name;
                    _cache[i].UpdatedAt = platform.UpdatedAt;
                    return _cache[i];
                }
            }
            return null;
        }

        public Platform Delete(string id)
        {
            for (int i = 0; i < _cache.Count; i++)
            {
                if (_cache[i].Id.Equals(id))
                {
                    var platform = _cache[i];
                    _cache.RemoveAt(i);
                    return platform;
                }
            }
            return null;
        }
    }
}
