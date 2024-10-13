using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Infraestructure.Repositories
{
    public class ShareRepository : IShareRepository
    {

        private readonly BirthflowDbContext _context;

        public ShareRepository(BirthflowDbContext _context)
        {
            this._context = _context;
        }

        //Retorna los grupos creado por el usuario
        public async Task<IEnumerable<GroupEntity>> GetGroupsByUserId(Guid userId)
        {
            try
            {
                var result = await _context.GroupEntities
                    .Where(g => g.UserGroups.Any(ug => ug.UserId == userId && g.IsDeleted == false ))
                    .ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GroupEntity> GetGroupById(long groupId)
        {
            try
            {
                var result = await _context.GroupEntities.FirstOrDefaultAsync(g => g.Id == groupId && g.IsDeleted != true);

                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GroupEntity> CreateGroup(GroupEntity entity)
        {
            try
            {
                await _context.GroupEntities.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GroupEntity> UpdateGroup(GroupEntity entity)
        {
            try
            {
                _context.GroupEntities.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<GroupEntity> DeleteGroup(GroupEntity entity)
        {
            try
            {
                entity.DeletedAt = DateTime.UtcNow;
                entity.IsDeleted = true;
                _context.GroupEntities.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<PartographGroupItemEntity>> GetPartographGroupItemForUser(Guid userId, long groupId)
        {
            try
            {

                var result = await _context.Partographs
                    .Where(p => p.IsDelete == false &&
                                _context.PartographGroupShareEntities
                                    .Any(gs => gs.GroupId == groupId &&
                                               gs.PartographGroupId == groupId &&
                                               (gs.UserId == userId || _context.PartographShareEntities
                                                   .Any(ps => ps.PartographId == p.PartographId && ps.UserId == userId))))
                    .Select(p => new PartographGroupItemEntity
                    {
                        PartographId = p.PartographId,
                        PartographGroupId = groupId,
                        CreatedAt = DateTime.UtcNow, // Ajustar según el modelo de datos
                        Partograph = p,
                        PartographGroup = null // Ajustar si es necesario cargar los datos del grupo
                    })
                    .ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PartographGroupItemEntity> FindPartographGroupItem(Guid Partograph, long PartographGroupId)
        {
            try
            {
                var result =await _context.PartographGroupItemEntities.FirstOrDefaultAsync(pgi => pgi.PartographId == Partograph && pgi.PartographGroupId == PartographGroupId);
              

                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PartographGroupItemEntity> CreatePartographGroupItem(PartographGroupItemEntity partographGroupItemEntity)
        {
            try
            {
                await _context.PartographGroupItemEntities.AddAsync(partographGroupItemEntity);
                await _context.SaveChangesAsync();

                return partographGroupItemEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PartographGroupItemEntity> UpdatePartographGroupItem(PartographGroupItemEntity partographGroupItemEntity)
        {
            try
            {
                _context.PartographGroupItemEntities.Update(partographGroupItemEntity);
                await _context.SaveChangesAsync();

                return partographGroupItemEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PartographGroupItemEntity> DeletePartographGroupItem(PartographGroupItemEntity partographGroupItemEntity)
        {
            try
            {
                _context.PartographGroupItemEntities.Remove(partographGroupItemEntity);
                await _context.SaveChangesAsync();

                return partographGroupItemEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //SHARE Metodos
        public async Task<PartographGroupShareEntity> FindPartographGroupShare(long Id)
        {
            try
            {
                var result = await _context.PartographGroupShareEntities.FindAsync(Id);

                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PartographGroupShareEntity> CreatePartographGroupShare(PartographGroupShareEntity entity)
        {
            try
            {
                await _context.PartographGroupShareEntities.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception )
            {
                throw;
            }
        }
        public async Task<PartographGroupShareEntity> UpdatePartographGroupShare(PartographGroupShareEntity entity)
        {
            try
            {
                _context.PartographGroupShareEntities.Remove(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PartographGroupShareEntity> DeletePartographGroupShare(PartographGroupShareEntity entity)
        {
            try
            {
                _context.PartographGroupShareEntities.Remove(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<PartographShareEntity> FindPartographShare(long Id)
        {
            try
            {
                var result = await _context.PartographShareEntities.FindAsync(Id);

                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PartographShareEntity> CreatePartographShare(PartographShareEntity entity)
        {
            try
            {
                await _context.PartographShareEntities.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PartographShareEntity> DeletePartographShare(PartographShareEntity entity)
        {
            try
            {
                _context.PartographShareEntities.Remove(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public async  Task<PartographShareEntity> UpdatePartographShare(PartographShareEntity entity)
        {
            try
            {
                _context.PartographShareEntities.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Task<PermissionTypeEntity> GetUserAccessForGroup(Guid userId, long groupId)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<PermissionTypeEntity> GetUserAccessForPartograph(Guid userId, Guid partograph)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
