using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain
{
    public enum UserRoleType
    {
        管理员 = 0,
        客服人员 = 1
    }

    /// <summary>
    /// 1,首页    --有uid是商家首页--有bid是品牌首页--都没有就是总站的
    /// 2,找商家    --只有总站的
    /// 3,品牌    --只有总站的
    /// 4,找产品     --没有bid就是总站的--同品牌下所有产品友情链接相同,所以产品内容页要加上bid条件
    /// 5,资讯    --只有总站的
    /// 6,论坛    --只有总站的
    /// 7,内页    --有uid就是商家内页--有bid就是品牌内页
    /// PS:内页就是只商家和品牌的导航里面除了首页的其它页面
    /// </summary>
    public enum LinksType
    { 
        首页 = 1,
        商家 = 2,
        品牌 = 3,
        产品 = 4,
        资讯 = 5,
        论坛 = 6,
        内页 = 7
    }

    public enum SystemCountEnum_CountType
    {
        会员资讯发布 = 1,
        顾客评论 = 2,
        顾客留言 = 3,
        论坛更新 = 4,
        顾客需求 = 5,
        注册人数 = 6,
        总站发布资讯 = 7,
        论坛发帖 = 8,
        论坛回帖 = 9
    }
    public enum SystemCountEnum_DateType
    {
        按天 = 1,
        按月 = 2
    }

    public enum KeyWordEnum_Type
    { 
        资讯关键字 = 1,
        产品关键字 = 2,
        品牌关键字 = 3,
        会员关键字 = 4
    }
}
