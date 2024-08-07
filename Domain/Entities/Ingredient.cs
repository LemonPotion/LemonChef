﻿namespace Domain.Entities;

public class Ingredient : BaseEntity
{
    public string Name { get; set; }
    public int? Quantity { get; set; }
    public string? Unit { get; set; }
}