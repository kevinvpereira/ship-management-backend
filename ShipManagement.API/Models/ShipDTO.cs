﻿namespace ShipManagement.API.Models
{
    public class ShipDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}
