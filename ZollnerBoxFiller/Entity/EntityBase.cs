using SqlSugar;
using System;

namespace Passion.Entity
{

    /// <summary>
    /// 框架实体基类Id
    /// </summary>
    public abstract class EntityBaseId
    {
        /// <summary>
        /// 雪花Id
        /// </summary>
        [SugarColumn(ColumnName = "Id", ColumnDescription = "主键Id", IsPrimaryKey = true, IsIdentity = false)]
        public virtual long Id { get; set; }
    }

    /// <summary>
    /// 框架实体基类
    /// </summary>
    [SugarIndex("index_{table}_CT", nameof(CreateTime), OrderByType.Asc)]
    public abstract class ZollnerEntityBase : EntityBaseId
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnDescription = "创建时间", IsOnlyIgnoreUpdate = true)]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(ColumnDescription = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        [SugarColumn(ColumnDescription = "创建者Id", IsOnlyIgnoreUpdate = true)]
        public virtual long? CreateUserId { get; set; }

        ///// <summary>
        ///// 创建者
        ///// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        //[System.Text.Json.Serialization.JsonIgnore]
        //[Navigate(NavigateType.OneToOne, nameof(CreateUserId))]
        //public virtual SysUser CreateUser { get; set; }

        /// <summary>
        /// 创建者姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "创建者姓名", Length = 64, IsOnlyIgnoreUpdate = true)]
        public virtual string CreateUserName { get; set; }

        /// <summary>
        /// 修改者Id
        /// </summary>
        [SugarColumn(ColumnDescription = "修改者Id")]
        public virtual long? UpdateUserId { get; set; }

        ///// <summary>
        ///// 修改者
        ///// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        //[System.Text.Json.Serialization.JsonIgnore]
        //[Navigate(NavigateType.OneToOne, nameof(UpdateUserId))]
        //public virtual SysUser UpdateUser { get; set; }

        /// <summary>
        /// 修改者姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "修改者姓名", Length = 64)]
        public virtual string UpdateUserName { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除", DefaultValue = "false")]
        public virtual bool IsDelete { get; set; } = false;

        /// <summary>
        /// 创建人账号
        /// </summary>
        [SugarColumn(ColumnDescription = "创建人", Length = 20, IsOnlyIgnoreUpdate = true)]
        public virtual string CreateId { get; set; }

        /// <summary>
        /// 更新人账号
        /// </summary>
        [SugarColumn(ColumnDescription = "更新人", Length = 20)]
        public virtual string UpdateId { get; set; }
    }

    /// <summary>
    /// 框架实体基类
    /// </summary>
    [SugarIndex("index_{table}_CT", nameof(CreateTime), OrderByType.Asc)]
    public abstract class EntityBase : EntityBaseId
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnDescription = "创建时间", IsOnlyIgnoreUpdate = true)]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(ColumnDescription = "更新时间")]
        public virtual DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        [SugarColumn(ColumnDescription = "创建者Id", IsOnlyIgnoreUpdate = true)]
        public virtual long? CreateUserId { get; set; }

        ///// <summary>
        ///// 创建者
        ///// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        //[System.Text.Json.Serialization.JsonIgnore]
        //[Navigate(NavigateType.OneToOne, nameof(CreateUserId))]
        //public virtual SysUser CreateUser { get; set; }

        /// <summary>
        /// 创建者姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "创建者姓名", Length = 64, IsOnlyIgnoreUpdate = true)]
        public virtual string CreateUserName { get; set; }

        /// <summary>
        /// 修改者Id
        /// </summary>
        [SugarColumn(ColumnDescription = "修改者Id")]
        public virtual long? UpdateUserId { get; set; }

        ///// <summary>
        ///// 修改者
        ///// </summary>
        //[Newtonsoft.Json.JsonIgnore]
        //[System.Text.Json.Serialization.JsonIgnore]
        //[Navigate(NavigateType.OneToOne, nameof(UpdateUserId))]
        //public virtual SysUser UpdateUser { get; set; }

        /// <summary>
        /// 修改者姓名
        /// </summary>
        [SugarColumn(ColumnDescription = "修改者姓名", Length = 64)]
        public virtual string UpdateUserName { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnDescription = "软删除", DefaultValue = "false")]
        public virtual bool IsDelete { get; set; } = false;

        ///// <summary>
        ///// 创建人账号
        ///// </summary>
        //[SugarColumn(ColumnDescription = "创建人", Length = 20, IsOnlyIgnoreUpdate = true)]
        //[MaxLength(20)]
        //public virtual string CreateId { get; set; }

        ///// <summary>
        ///// 更新人账号
        ///// </summary>
        //[SugarColumn(ColumnDescription = "更新人", Length = 20), AllowNull]
        //[MaxLength(20)]
        //public virtual string UpdateId { get; set; }
    }




}