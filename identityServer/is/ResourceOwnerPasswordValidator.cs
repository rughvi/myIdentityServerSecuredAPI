﻿using System;
using System.Threading.Tasks;
using identityServer.db;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace identityServer.@is
{
	public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
	{
		IAuthRepository _rep;

		public ResourceOwnerPasswordValidator(IAuthRepository rep)
		{
			this._rep = rep;
		}

		public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
		{
			if (_rep.ValidatePassword(context.UserName, context.Password))
			{
				context.Result = new GrantValidationResult(_rep.GetUserByUsername(context.UserName).Id, "password", null, "local", null);
				return Task.FromResult(context.Result);
			}
			context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
			return Task.FromResult(context.Result);
		}
	}
}
