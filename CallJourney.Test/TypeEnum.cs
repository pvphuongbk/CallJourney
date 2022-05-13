using System.ComponentModel;

namespace CallJourney.Test
{
    public enum TypeEnum
    {
        [Description("Super iPad")]
        ipd,
        [Description("MacBook Pro")]
        mbp,
        [Description("Apple TV")]
        atv,
        [Description("VGA adapter")]
        vga
    }
}
