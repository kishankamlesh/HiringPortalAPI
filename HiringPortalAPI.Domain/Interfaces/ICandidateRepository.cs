﻿using HiringPortalAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiringPortalAPI.Domain.Interfaces
{
    public interface ICandidateRepository
    {
        List<HiringInfoModel> GetCandidates();
    }
}