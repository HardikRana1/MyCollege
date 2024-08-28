using ProHardikV1.Debugging;

namespace ProHardikV1
{
    public class ProHardikV1Consts
    {
        public const string LocalizationSourceName = "ProHardikV1";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "988fd742807e4db5bfef7bce72a47051";
    }
}
