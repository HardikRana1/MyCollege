using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ProHardikV1.Configuration.Dto;

namespace ProHardikV1.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ProHardikV1AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
