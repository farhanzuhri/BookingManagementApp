namespace API.Utilities.Enums
{
    public enum StatusLevel
    {
        Requested = 2,
        Approved = 1,
        Rejected = -1,
        Canceled = 0,
        Completed = 4,
        [Display(Name = "On Going")] OnGoing = 3,
    }
}
