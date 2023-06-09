﻿using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.Interfaces;

namespace WebAPIExample.Business.Models
{
    public class AuthorizeUserResponseModel : ResponseModelHelper
    {
        public AuthorizedStatus? Status;
        public string? UserId;
        public string? Token;
    }
}