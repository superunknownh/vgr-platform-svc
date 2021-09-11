using System;
using System.Collections.Generic;

using vgr_platform_svc.Repositories;
using vgr_platform_svc.Models;
using vgr_platform_svc.Exceptions;

namespace vgr_platform_svc.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _repository;

        public PlatformService(IPlatformRepository repository)
        {
            _repository = repository;
        }

        public List<Platform> List()
        {
            return _repository.List();
        }

        public Platform GetById(string id)
        {
            var platform = _repository.GetById(id);
            if (platform == null)
            {
                throw new NotFoundException();
            }
            return platform;
        }

        public Platform Create(Platform platform)
        {
            if (_repository.GetById(platform.Id) != null)
            {
                throw new ConflictException("ID already exists.");
            }
            if (_repository.GetByName(platform.Name) != null)
            {
                throw new ConflictException("Name already exists.");
            }
            platform.CreatedAt = DateTime.Now;
            platform.UpdatedAt = DateTime.Now;
            return _repository.Create(platform);
        }

        public Platform Update(Platform platform)
        {
            if (_repository.GetByName(platform.Name) != null)
            {
                throw new ConflictException("Name already exists.");
            }
            platform.UpdatedAt = DateTime.Now;
            platform = _repository.Update(platform);
            if (platform == null)
            {
                throw new NotFoundException();
            }
            return platform;
        }

        public void Delete(string id)
        {
            var platform = _repository.Delete(id);
            if (platform == null)
            {
                throw new NotFoundException();

            }
        }
    }
}
