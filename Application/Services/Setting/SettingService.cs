using Application.Common.Extension;
using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Setting;

public class SettingService : ISettingService
{
    readonly IContext _context;
    public SettingService(IContext context)
    {
        _context = context;
    }
    public async Task<SettingDto> GetSettingAsync()
    {
        SettingEntity? setting = await _context.Entity<SettingEntity>()
            .FirstOrDefaultAsync();
        return setting.Adapt<SettingDto>();
    }

    public async Task UpdateSettingAsync(SettingDto setting)
    {
        SettingEntity? entity = await _context.Entity<SettingEntity>()
            .FirstOrDefaultAsync(); 
        setting.Adapt(entity);

        entity!.Image = setting!.ImageFile!.UploadImage("Setting");

        _context.Entity<SettingEntity>().Update(entity!);
        await _context.SaveChangesAsync();
    }
}
