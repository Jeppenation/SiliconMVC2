namespace SiliconMVC2.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Ultimate Task Manager Assistant";

    public ShowcaseViewModel Showcase { get; set; } = new ShowcaseViewModel
    {
        Id = "overview",
        ShowcaseImage = new() { ImageUrl = "images/Showcase-image.svg", AltText = "Task Management Assistant" },
        Title = "Task Managment Assistant You Gonna Love",
        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
        Link = new() { ControllerName = "downloads", ActionName = "index", Text = "Get started for free" },
        BrandsText = "Largest companies use our tool to work efficiently",
        Brands =
                    [
                        new() { ImageUrl = "images/logo1.svg", AltText = "Brand 1" },
                        new() { ImageUrl = "images/logo2.svg", AltText = "Brand 2" },
                        new() { ImageUrl = "images/logo3.svg", AltText = "Brand 3" },
                        new() { ImageUrl = "images/logo4.svg", AltText = "Brand 4" }
                    ],

    };


    public WorkToolsViewModel WorkTools { get; set; } = new()
    {
        WorkToolsItems =
        [
            new() { ImageUrl = "images/Logos/Google.svg", Text = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis." },
                    new() { ImageUrl = "images/Logos/Zoom.svg", Text = "In eget a mauris quis. Tortor dui tempus quis integer est sit natoque placerat dolor." },
                    new() { ImageUrl = "images/Logos/Slack.svg", Text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo." },
                    new() { ImageUrl = "images/Logos/gmail.svg", Text = "Rutrum interdum tortor, sed at nulla. A cursus bibendum elit purus cras praesent." },
                    new() { ImageUrl = "images/Logos/Trello.svg", Text = "Congue pellentesque amet, viverra curabitur quam diam scelerisque fermentum urna." },
                    new() { ImageUrl = "images/Logos/MailChimp.svg", Text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris." },
                    new() { ImageUrl = "images/Logos/Dropbox.svg", Text = "Ut in turpis consequat odio diam lectus elementum. Est faucibus blandit platea." },
                    new() { ImageUrl = "images/Logos/Evernote.svg", Text = "Faucibus cursus maecenas lorem cursus nibh. Sociis sit risus id. Sit facilisis dolor arcu." }
        ]
    };

    public SubscribeViewModel Subscribe { get; set; } = new();



}
