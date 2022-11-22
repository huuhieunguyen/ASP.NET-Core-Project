﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text;
using System.Collections.Generic;

namespace Furniture_Project.Areas.Admin.Models
{
    public class AdminSideBarService
    {
        private readonly IUrlHelper UrlHelper;
        public List<SideBarItem> Items { get; set; } = new List<SideBarItem>();
        public string renderHtml()
        {
            var html = new StringBuilder();
            foreach(var item in Items)
            {
                html.Append(item.RenderHtml(UrlHelper));
            }

            return html.ToString(); 
        }
        public AdminSideBarService(IUrlHelperFactory factory, IActionContextAccessor action)
        {
            UrlHelper = factory.GetUrlHelper(action.ActionContext);
            //Khởi tạo các mục sidebar

            Items.Add(new SideBarItem() { Type = SideBarItemType.Divider });
            Items.Add(new SideBarItem() { 
                Type = SideBarItemType.Heading,
                Title="Quản lý"
            });
            Items.Add(new SideBarItem() { 
                Type = SideBarItemType.NavItem,
                Title="Quản lý Users",
                AwesomeIcon= "fas fa-users",
                collapseID= "collapseTwo",
                Items = new List<SideBarItem>()
                {
                    new SideBarItem()
                    {
                        Type = SideBarItemType.NavItem,
                        Controller = "NhanVien",
                        Action = "Index",
                        Area = "Admin",
                        Title = "Nhân viên",
                        
                    },
                    new SideBarItem()
                    {
                        Type = SideBarItemType.NavItem,
                        Controller = "KhachHang",
                        Action = "Index",
                        Area = "Admin",
                        Title = "Khách hàng",

                    }
                }

            });
            Items.Add(new SideBarItem()
            {
                Type = SideBarItemType.NavItem,
                Controller = "SanPham",
                Action = "Index",
                Area = "Admin",
                Title = "Quản lý sản phẩm",
                AwesomeIcon= "fas fa-tags"

            });

            Items.Add(new SideBarItem()
            {
                Type = SideBarItemType.NavItem,
                Controller = "KhuyenMai",
                Action = "Index",
                Area = "Admin",
                Title = "Quản lý khuyến mãi",
                AwesomeIcon = "fas fa-percentage"

            });
            Items.Add(new SideBarItem()
            {
                Type = SideBarItemType.NavItem,
                Controller = "DanhMuc",
                Action = "Index",
                Area = "Admin",
                Title = "Quản lý danh mục",
                AwesomeIcon = "fas fa-boxes"

            });

            Items.Add(new SideBarItem() { Type = SideBarItemType.Divider });
            Items.Add(new SideBarItem()
            {
                Type = SideBarItemType.Heading,
                Title = "Chức năng khác"
            });

        }
        public void setActive(string Controller, string Action, string Area)
        {
            foreach (var item in Items)
            {
               if((item.Controller==Controller) && (item.Action==Action) && (item.Area == Area))
                {
                    item.IsActive = true;
                    return;
                }
                else
                {
                    if (item.Items != null)
                    {
                        foreach (var childItem in item.Items)
                        {
                            if ((childItem.Controller == Controller) && (childItem.Action == Action) && (childItem.Area == Area))
                            {
                                childItem.IsActive = true;
                                item.IsActive = true;
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
