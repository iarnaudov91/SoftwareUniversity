﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Common.AutoMapper
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}