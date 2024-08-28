using System.Threading.Tasks;
using ProHardikV1.Configuration.Dto;

namespace ProHardikV1.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
