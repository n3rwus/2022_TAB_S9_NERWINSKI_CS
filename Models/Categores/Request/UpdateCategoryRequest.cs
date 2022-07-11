﻿using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Categores.Request
{
    public class UpdateCategoryRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
