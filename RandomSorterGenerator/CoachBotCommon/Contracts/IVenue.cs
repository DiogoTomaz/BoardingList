using System;
namespace CoachBot.Common
{
    public interface IVenue
    {
        Uri AssociatedLink { get; set; }
        string Description { get; set; }
        string Location { get; set; }
    }
}
