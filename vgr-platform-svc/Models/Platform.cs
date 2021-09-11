using System;
using System.ComponentModel.DataAnnotations;

namespace vgr_platform_svc.Models
{
    public class Platform
    {
        public Platform(string id, string name, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public Platform(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public Platform()
        {
        }


        [Required]
        [StringLength(6, MinimumLength = 2)]
        public string Id { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class UpdatePlatform
    {
        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string Name { get; set; }
    }
}
