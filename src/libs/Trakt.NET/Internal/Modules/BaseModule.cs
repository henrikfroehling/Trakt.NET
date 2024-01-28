namespace TraktNET
{
    public class BaseModule
    {
        internal readonly ITraktContext _context;

        internal BaseModule(ITraktContext context)
        {
            ArgumentValidator.ThrowIfNull(context);
            _context = context;
        }
    }
}
