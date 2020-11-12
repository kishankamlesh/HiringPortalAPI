using HiringPortalAPI.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiringPortalAPI.Application.Interfaces
{
    public interface IGetPanelistsBySearchString
    {
        GetPanelistsBySearchStringViewModel GetPanelistsBySearchString(string searchQuery);
    }
}
