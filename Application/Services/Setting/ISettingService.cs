using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Setting;

public interface ISettingService
{
    Task<SettingDto> GetSettingAsync();
    Task UpdateSettingAsync(SettingDto setting);
}
