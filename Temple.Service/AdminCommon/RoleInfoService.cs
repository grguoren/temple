﻿using Temple.Core.Data;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service
{
    public partial class RoleInfoService : IRoleInfoService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<User_Role> _roleuserRepository;

        public RoleInfoService(IUnitOfWork unitofwork)
        {
            this._roleRepository = unitofwork.Repository<Role>();
            this._roleuserRepository = unitofwork.Repository<User_Role>();
        }

        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public List<Domain.Role> GetAllRoleList(int status = 1)
        {
            var query = this._roleRepository.Entities;
            if (status == 1)
            {
                query = query.Where(x => x.Status == true);
            }
            else if (status == 0)
            {
                query = query.Where(x => x.Status == false);
            }
           
            return query.ToList();
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool AddRole(Domain.Role info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("角色对象不能为空");
            }
            if (string.IsNullOrEmpty(info.Name))
            {
                throw new ArgumentNullException("角色名称不能为空");
            }
            return this._roleRepository.Insert(info) > 0;
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRole(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("角色ID不能小于等于0");
            }
            return this._roleRepository.Delete(id) > 0;
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool UpdateRole(Domain.Role info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("角色对象不能为空");
            }
            
            return this._roleRepository.Update(info) > 0;
        }
        /// <summary>
        /// 根据ID获取角色信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Domain.Role GetRoleInfoByID(int ID)
        {
            return this._roleRepository.GetByKey(ID);
        }

        /// <summary>
        /// 添加角色用户关联
        /// </summary>
        /// <param name="RoleIDs"></param>
        /// <param name="UserID"></param>
        public void AddRoleUser(string[] RoleIDs, int UserID)
        {
            var query = this._roleuserRepository.Entities;
            query = query.Where(x => x.User_Id == UserID);
            if (query.ToList() != null && query.Count() > 0)
            {
                this._roleuserRepository.Delete(query);
            }
            foreach (var item in RoleIDs)
            {
                User_Role info = new User_Role();
                info.Role_Id = Convert.ToInt32(item);
                info.User_Id = UserID;
                this._roleuserRepository.Insert(info);
            }
        }
        /// <summary>
        /// 根据用户ID查询该用户的角色
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<User_Role> GetRole_UserListByUserID(int UserID)
        {
            var query = this._roleuserRepository.Entities;
            query = query.Where(x => x.User_Id == UserID);
            return query.ToList();
        }
        /// <summary>
        /// 删除用户下关联的角色
        /// </summary>
        /// <param name="UserID"></param>
        public void DeleteRoleUser(int UserID)
        {
            var query = this._roleuserRepository.Entities;
            query = query.Where(x => x.User_Id == UserID);
            if (query.ToList() != null && query.Count() > 0)
            {
                this._roleRepository.Delete(query);
            }
        }

    }
}
