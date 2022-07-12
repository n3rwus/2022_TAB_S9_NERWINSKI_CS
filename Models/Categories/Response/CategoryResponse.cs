using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebAlbum.Helpers;

namespace WebAlbum.Models.Categores.Response
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
