﻿using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace TeacherDiary.Clients.Mvc
{
    [ExcludeFromCodeCoverage]
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
