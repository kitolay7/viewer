using viewwerXF.ApiServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace viewwerXF.Models
{
    public class Tour : Entity
    {
        public string Name { get; set; }
        public Entity Entity { get; set; }
        public string Image { get; set; }
        public Uri ProductImage
        {
            get; set;
        }
    }

    public class Entity
    {
        public string FavoriteId { get; set; }
        public string EntityId { get; set; }
        public string EntityType { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        public string TypeName { get { return Type.Replace("0", ""); } }
        public string Url { get; set; }
        public string FullUrl { get { return $"{WebApiService.BaseURL}{Url}"; } }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double? Area { get; set; }
        public double? Price { get; set; }
        public string SaleType { get; set; }
        public string ThumbnailUrl { get { return $"{WebApiService.BaseURL}{Thumbnail}"; } }
        public string Thumbnail { get; set; }
        public string ModerationStatus { get; set; }
        public string ModerationMessage { get; set; }
        public string GasClass { get; set; }
        public string EnergyClass { get; set; }
        [JsonProperty("counterRating")]
        public int Rating { get; set; }
        public bool IsSold { get; set; }
        public bool IsFavorite { get; set; }
        [JsonProperty("house")]
        public bool IsHouse { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreateDate { get; set; }
    }
}
