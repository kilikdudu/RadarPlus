﻿using ClubManagement.IBLL;
using ClubManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClubManagement.Utils
{
    public static class MemoryUtils
    {
        private static IMemoryService _arquivo;

        public static MemoryInfo getInfo() 
        {
            if (_arquivo == null)
                _arquivo = DependencyService.Get<IMemoryService>();
            return _arquivo.getInfo();
        }
    }
}
