﻿namespace SiliconMVC2.ViewModels;

public class LinkViewModel
{
    public string ControllerName { get; set; } = null!;
    public string ActionName { get; set; } = null!;
    public string? Text { get; set; }
}
