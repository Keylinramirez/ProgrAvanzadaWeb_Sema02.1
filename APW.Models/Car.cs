﻿namespace APW.Models;

public class Car
{
    public Guid Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string Guid { get { return Id.ToString(); } }
}
