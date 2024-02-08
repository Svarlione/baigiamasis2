﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace baigiamasis2.Models
{
    public class Image
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public byte[] ImageBytes { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }
    }
}
